using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Akupunctura.Logik.Files
{
  [Serializable]
  public class measurement
  {
      const string name_folder = "measurement"; // Название директории 
      const string name_folder_CV = "CV"; // Название директории
      const string name_folder_ID = "ID"; // Название директории 
      const string name_folder_CG = "CG"; // Название директории 
      private DateTime id_measurement; // Дата создания записи
      private DateTime id_doctor; // id врача
      private DateTime id_patient; //  id пациента
      [NonSerialized] private BinaryFormatter formatter; // Для сериализации
      [NonSerialized] private List<Int32> Currents = new List<Int32>();
      [NonSerialized] private List<Int32> Voltages = new List<Int32>();

      public void Clear()
      {
        Currents.Clear();
        Voltages.Clear();
      }

      public void save_dimension(Int32 Current, Int32 Voltage) // сохранение (по точкам)
      {
          Currents.Add(Current);
          Voltages.Add(Voltage);
      }
      public void save_id(DateTime id_doctor, DateTime id_patient) // сохранение id
      {
          id_measurement = DateTime.Now.ToUniversalTime();
          this.id_doctor = id_doctor;
          this.id_patient = id_patient;
      }

      private void folder(string str) // Создание папки для врачей
      {
        System.IO.Directory.CreateDirectory(str + @"\" + name_folder);
        System.IO.Directory.CreateDirectory(str + @"\" + name_folder + @"\" + name_folder_ID);
        System.IO.Directory.CreateDirectory(str + @"\" + name_folder + @"\" + name_folder_CV);
        System.IO.Directory.CreateDirectory(str + @"\" + name_folder + @"\" + name_folder_CG);
      }
      public void save_disk(measurement meas, string str) // Сохранение на диск
      {
          kost();
          folder(str);
          save_seraalize(meas,str);
          save_tip(meas, str);
          save_CG(meas, str);
      }
      private void save_CG(measurement meas, string str)  // сохранение  нелинейной проводимости и ёмкость кожи 
      {
          double[] X = _CG();
          using (StreamWriter sw = new StreamWriter(str + @"\" + name_folder + @"\" + name_folder_CG + @"\" + id_str(id_measurement)))
          {
              for (int i = 0; i < Currents.Count(); i++)
                  sw.WriteLine(X.ToString()); 
              sw.Close();
          }
      }
      private double[] _CG() // рассчёт нелинейной проводимости и ёмкость кожи 
      {
          List<double> currents = new List<double>(); 
          List<double> voltages = new List<double>();
          const double T = 1953;  
          const int kr = 10; // сдвиг от края
          const int size = 5 ; // размер ситемы (кол-во ур.)
          // A*X=B ищем X
          double[] X = new double[size];
          double[,] A = new double[size, size];
          double[] B = new double[size];

          for (int ij = 0; ij < Voltages.Count(); ij++)
              voltages.Add((double)Voltages[ij] * 1677721.6);

          for (int ij = 0; ij < Currents.Count(); ij++)
              currents.Add((double)Currents[ij] * 33554431999999.996);

          // Заполнение А
          for (int i = 0; i< size -1 ;i++ )
              for (int j = 0; j < size - 1; j++)
                  for (int ij = kr; ij < voltages.Count() - kr; ij++)
                      A[i, j] += Math.Pow(voltages[ij], i + j + 2);

          for (int i = 0; i < size ; i++)
          {
              for (int ij = kr; ij < voltages.Count() - kr; ij++)
                  if (i != size - 1)
                      A[i, 5] += Math.Pow(voltages[ij], i + 1) * (voltages[ij + 1] - voltages[ij - 1]) / (2 * T);
                  else
                      A[i, 5] += Math.Pow((voltages[ij + 1] - voltages[ij - 1]) / (2 * T), i + 1);
              A[5, i] = A[i, 5];
          }

          // Заполнение B
          for (int i = 0; i < size - 1; i++)
              for (int ij = kr; ij < voltages.Count() - kr; ij++)
                  B[i] += currents[ij] * Math.Pow(voltages[ij], i + 1);

          for (int ij = kr; ij < voltages.Count() - kr; ij++)
              B[size - 1] += currents[ij] * (voltages[ij + 1] - voltages[ij - 1]) / (2 * T);

          // A*X=B ищем X
          int info = 0;
          alglib.densesolverreport rep;
          alglib.rmatrixsolve(A, size, B, out info, out rep, out X);

          return X;
      }
      private void kost ()
      {         
          // Фильтр среднего
          int c = 7;
          Int32[] v = new Int32[c];
          // Костыль
          for (int i = 0; i < Voltages.Count() - c; i++)
          {
              Voltages.CopyTo(i,v,0,c);
              Array.Sort(v);
              Voltages[i] = v[3];
          }
          // 
          for (int i = 0; i < Currents.Count() - c; i++)
          {
              Currents.CopyTo(i, v, 0, c);
              Array.Sort(v);
              Currents[i] = v[3];
          }
      }
      private void save_seraalize(measurement meas, string str) // сохранение сереализуемых id
      {
          formatter = new BinaryFormatter(); // Для сериализации
          using (FileStream f = new FileStream(str + @"\" + name_folder + @"\" + name_folder_ID + @"\" + id_str(id_measurement), FileMode.OpenOrCreate))
              formatter.Serialize(f, meas);
      }
      private void save_tip(measurement meas, string str) // сохранение самих измерений
      {
          using (StreamWriter sw = new StreamWriter(str + @"\" + name_folder + @"\" + name_folder_CV + @"\" + id_str(id_measurement)))
          {
              for (int i = 0; i < Currents.Count(); i++)
                  sw.WriteLine(" " + Currents[i].ToString() + " " + Voltages[i].ToString()); // А потому что так было раньше, но не совсем так
              sw.Close();
          }
      }
      public void loading_(out measurement meas, DateTime id, string str) // Загрузка с диска
      {
          folder(str);
          loading_seraalize(out meas, id, str);
          meas = loading_tip(meas, id, str);

      }
      private measurement loading_tip(measurement meas, DateTime id, string str) // загрузка типизированного файла
      {
          using (StreamReader sr = new StreamReader(str + @"\" + name_folder + @"\" + name_folder_CV + @"\" + id_str(id) ))
          {
              String line;
              line = sr.ReadLine();
              while (line != null)
              {
                  meas.save_dimension(Convert.ToInt32(line.Split(' ')[1]), Convert.ToInt32(line.Split(' ')[2])); // Разбор типизированного файла
                  line = sr.ReadLine();
              }
              sr.Close();
          }
          return meas;
      }
      private void loading_seraalize(out measurement meas, DateTime id, string str) // загрузка id
      {
          formatter = new BinaryFormatter(); // Для сериализации
          using (FileStream f = new FileStream(str + @"\" + name_folder + @"\" + name_folder_ID + @"\" + id_str(id), FileMode.OpenOrCreate))
              meas = (measurement)formatter.Deserialize(f);
      }
      private string id_str(DateTime id) // Перевод в строку названия файла
      {
          return id.ToString("u").Replace(':', ';') + ".txt";
      }

  }
}
