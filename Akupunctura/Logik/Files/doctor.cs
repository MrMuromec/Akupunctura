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
      public const string name_folder = "doctor"; // Название директории 
      private DateTime id_doctor = DateTime.MinValue; // Дата создания записи
      private List<string> FIO = new List<string>(); // ФИО
      private BinaryFormatter formatter = new BinaryFormatter(); // Для сериализации

      private void folder(string str) // Создание папки для врачей
      {
          System.IO.Directory.CreateDirectory(str + @"\" + name_folder);
      }
      private string id_str(DateTime id) // Перевод в строку названия файла
      {
          return id.ToString("u").Replace(':', ';') + ".txt";
      }

      public void save_disk ( doctor doc ) // Сохранение на диск
      {
          using (FileStream f = new FileStream(name_folder + id_str(id_doctor), FileMode.OpenOrCreate))
              formatter.Serialize(f, doc);
      }
      public void read_disk ( out doctor doc , DateTime id ) // Загрузка с диска
      {
          using (FileStream f = new FileStream(name_folder + id_str(id), FileMode.Open))
              doc = (doctor)formatter.Deserialize(f);
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
