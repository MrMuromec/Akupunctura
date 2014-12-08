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
      private rights_doctor local_rights = new rights_doctor(); // На будущее (разрешение действий для различных учётных записей)
      private DateTime id_doctor; // Дата создания записи
      private string[] FIO = new string[3];
      private string file_name;


      public void save_doctor (doctor doc) // Первое сохранение
      {
          id_doctor = DateTime.UtcNow; // Пишется по мировому времени 
          BinaryFormatter formatter = new BinaryFormatter();
          using (FileStream fs = new FileStream(file_name, FileMode.OpenOrCreate))
          {
              formatter.Serialize(fs, doc);
          }
      }
  }
}
