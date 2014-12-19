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

      public void clean() // Чистка
      {
          FIO.Clear();
          // А вот с датой хз
      }
      public List<string> read_fio() // Чтение
      {
          return FIO;
      }
      public string read_id() // Чтение
      {
          return id_patient.ToString();
      }
      public string read_data() // Чтение
      {
          return data_patient.ToString();
      }
      /*
      public List<string> read(string parameter) // Чтение
      {
          parameter.ToLower();
          List<string> str = new List<string>();
          switch (parameter)
          {
              case "id":
                  {
                      str.Add(id_patient.ToString());
                      break;
                  }
              case "fio":
                  {
                      str.AddRange(FIO);
                      break;
                  }
              case "data":
                  {
                      str.Add(data_patient.ToString());
                      break;
                  }
              default:
                  break;
          }
          return str;
      }
      */
      public bool record(List<string> fio, DateTime data) // Запись !!!!!!!!!!!!!!!!! Править!
      {
          if (fio.Count == 0) return false;
          if (FIO.Count == 0) id_patient = DateTime.UtcNow; // Пишется по мировому времени
          FIO = fio;
          data_patient = data;
          return true;
      }
  }
}
