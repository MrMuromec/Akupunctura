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
      private DateTime id_patient;// Дата создания записи
      private DateTime data_patient; // Дата рождения 
      private List<string> FIO = new List<string>();
      private string file_name;

      private void save(patient pat, string address)  // Бинарная сериализация
      {
          BinaryFormatter formatter = new BinaryFormatter();
          using (FileStream fs = new FileStream(file_name, FileMode.OpenOrCreate))
          {
              formatter.Serialize(fs, pat);
          }
      }
      public void save_patient(patient pat, List<string> fio, Int32[] d, string address) // Сохранение
      {
          if (FIO.Count == 0) id_patient= DateTime.UtcNow; // Пишется по мировому времени
          FIO = fio;
          data_patient = new DateTime(d[0], d[1], d[2]); // Год, месяц, день
          save(pat,address);
      }
  }
}
