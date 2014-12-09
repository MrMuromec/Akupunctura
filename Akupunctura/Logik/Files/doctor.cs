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
      private rights_doctor local_rights ; // На будущее (разрешение действий для различных учётных записей)
      private DateTime id_doctor; // Дата создания записи
      private List<string> FIO = new List<string>();
      private string file_name;

      private void save(doctor doc, string address) // Бинарная сериализация
      {
          BinaryFormatter formatter = new BinaryFormatter();
          using (FileStream fs = new FileStream(address + file_name, FileMode.OpenOrCreate))
          {
              formatter.Serialize(fs, doc);
          }
      }
      public void save_doctor(doctor doc, List<string> fio, string address) // Сохранение
      {
          if (FIO.Count==0) id_doctor = DateTime.UtcNow; // Пишется по мировому времени
          FIO = fio;
          save(doc,address);
      }
      public void open_doctor(doctor doc)
      {
      }
  }
}
