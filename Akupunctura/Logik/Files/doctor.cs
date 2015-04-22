using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Akupunctura.Logik.Files
{
  [Serializable]
  public class doctor
  {
      const string name_folder = "doctor"; // Название директории 
      private DateTime id_doctor; // Дата создания записи
      private List<string> FIO = new List<string>(); // ФИО
      [NonSerialized] private BinaryFormatter formatter; // Для сериализации

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

      public void save_disk ( doctor doc, string str ) // Сохранение на диск
      {
          formatter = new BinaryFormatter(); // Для сериализации
          folder(str);
          using (FileStream f = new FileStream(str + @"\" + name_folder + @"\" + id_str(id_doctor), FileMode.OpenOrCreate))
              formatter.Serialize(f, doc);
      }
      public void read_disk ( out doctor doc , DateTime id, string str ) // Загрузка с диска
      {
          formatter = new BinaryFormatter(); // Для сериализации
          folder(str);
          using (FileStream f = new FileStream(str + @"\" + name_folder + @"\" + id_str(id), FileMode.Open))
              doc = (doctor)formatter.Deserialize(f);
      }
      public void save_id() // сохранение id
      {
        id_doctor = DateTime.Now.ToUniversalTime();
      }
      public DateTime read_id()  // Чтение id
      {
          return id_doctor;
      }
      public List<string> read_fio() // Чтение фио
      {
          return FIO;
      }
      public string read_fio(string str) // Чтение фио
      {
          for (int i = 0; i != FIO.Count(); i++)
          {
              str += FIO[i] + " ";
          }
          return str;
      }
      public bool save(string fio, DateTime T) // Запись
      {
          List<string> str = new List<string>(fio.Split(' '));
          if (str.Count != 0) FIO = str;
          else return false;
          id_doctor = T;
          return true;
      }
  }
}
