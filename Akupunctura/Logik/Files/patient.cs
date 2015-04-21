using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Akupunctura.Logik.Files
{
  [Serializable]
  public class patient
  {
      const string name_folder = "patient"; // Название директории 
      private DateTime id_patient;// Дата создания записи
      private DateTime data_patient; // Дата рождения 
      private List<string> FIO = new List<string>();
      [NonSerialized]
      private BinaryFormatter formatter; // Для сериализации

      public string get_folder(string str) // Получение названия подкаталога
      {
          folder(str);
          return (@"\" + name_folder);
      }

      private void folder(string str) // Создание папки для врачей
      {
          System.IO.Directory.CreateDirectory(str + @"\" + name_folder);
      }
      private string id_str(DateTime id) // Перевод в строку названия файла
      {
          return id.ToString("u").Replace(':', ';') + ".txt";
      }

      public void save_disk(patient pat, string str) // Сохранение на диск
      {
          formatter = new BinaryFormatter(); // Для сериализации
          folder(str);
          using (FileStream f = new FileStream(str + @"\" + name_folder + @"\" + id_str(id_patient), FileMode.OpenOrCreate))
              formatter.Serialize(f, pat);
      }
      public void read_disk(out patient pat, DateTime id, string str) // Загрузка с диска
      {
          formatter = new BinaryFormatter(); // Для сериализации
          folder(str);
          using (FileStream f = new FileStream(str + @"\" + name_folder + @"\" + id_str(id), FileMode.Open))
              pat = (patient)formatter.Deserialize(f);
      }

      public List<string> read_fio() // Чтение
      {
          return FIO;
      }
      public string read_fio(string str) // Чтение
      {
          for (int i = 0 ; i != FIO.Count(); i++)
          {
              str += FIO[i] + " ";
          }
          return str;
      }
      public DateTime read_id()  // Чтение id
      {
          return id_patient;
      }
      public DateTime read_data() // Чтение
      {
          return data_patient;
      }
      public bool save(string fio, DateTime id_T, DateTime t_data) // Запись
      {
          List<string> str = new List<string>(fio.Split(' '));
          if (str[0] != "") FIO = str;
          else return false;
          id_patient = id_T;
          data_patient = t_data;
          return true;
      }
  }
}
