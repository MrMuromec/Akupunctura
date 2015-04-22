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
      }

      public List<Int32> read_current() // Чтение
      {
          return Currents;
      }
      public List<Int32> read_voltage() // Чтение
      {
          return Voltages;
      }
      public DateTime read_id_measurement() // Чтение id
      {
          return id_measurement;
      }
      private void folder(string str) // Создание папки для врачей
      {
        System.IO.Directory.CreateDirectory(str + @"\" + name_folder);
        System.IO.Directory.CreateDirectory(str + @"\" + name_folder + @"\" + name_folder_ID);
        System.IO.Directory.CreateDirectory(str + @"\" + name_folder + @"\" + name_folder_CV);
      }
      public void save_disk(measurement meas, string str) // Сохранение на диск
      {
          folder(str);
          formatter = new BinaryFormatter(); // Для сериализации
          using (FileStream f = new FileStream(str + @"\" + name_folder + @"\" + name_folder_ID + @"\" + id_str(id_measurement), FileMode.OpenOrCreate))
              formatter.Serialize(f, meas);
          using (StreamWriter sw = new StreamWriter(str + @"\" + name_folder + @"\" + name_folder_CV + @"\" + id_str(id_measurement) + ".txt"))
          {
              List<Int32> C = meas.read_current();
              List<Int32> V = meas.read_voltage();
              for (int i = 0; i < C.Count(); i++)
                  sw.WriteLine(" " + C[i].ToString() + " " + V[i].ToString()); // А потому что так было раньше, но не совсем так
              sw.Close();
          }
      }
      public void loading_(out measurement meas, DateTime id, string str) // Загрузка с диска
      {
          folder(str);
          formatter = new BinaryFormatter(); // Для сериализации
          using (FileStream f = new FileStream(str + @"\" + name_folder + @"\" + name_folder_ID + @"\" + id_str(id), FileMode.OpenOrCreate))
              meas = (measurement)formatter.Deserialize(f);
          using (StreamReader sr = new StreamReader(str + @"\" + name_folder + @"\" + name_folder_CV + @"\" + id_str(id) + ".txt"))
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
      }
      private string id_str(DateTime id) // Перевод в строку названия файла
      {
          return id.ToString("u").Replace(':', ';') + ".txt";
      }

  }
}
