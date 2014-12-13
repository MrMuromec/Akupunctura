using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Akupunctura.Logik.Files
{
  [Serializable]
  public class doctor
  {
      private DateTime id_doctor; // Дата создания записи
      private List<string> FIO = new List<string>();

      public List<string> read(string parameter) // Чтение
      {
          parameter.ToLower();
          List<string> str = new List<string>();
          switch (parameter)
          {
              case "id":
                  {
                      str.Add(id_doctor.ToString());
                      break;
                  }
              case "fio":
                  {
                      str.AddRange(FIO);
                      break;
                  }
              default:
                  break;
          }
          return str;
      }

      public bool record(List<string> fio) // Запись
      {
          if (fio.Count == 0) return false;
          if (FIO.Count == 0) id_doctor = DateTime.UtcNow; // Пишется по мировому времени
          FIO = fio;
          return true;
      }
  }
}
