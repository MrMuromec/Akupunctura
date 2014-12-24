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

      public void clean() // Чистка
      {
          FIO.Clear();
          // А вот с датой хз
      }
      public DateTime read_id()  // Чтение id
      {
          return id_doctor;
      }
      public List<string> read_fio() // Чтение фио
      {
          return FIO;
      }
      public bool save(string fio) // Запись
      {
          List<string> str = new List<string>(fio.Split(' '));
          if (str.Count != 0) FIO = str;
          else return false;
          return true;
      }
      public bool save(List<string> str, DateTime T) // Запись
      {
          if (str.Count != 0) FIO = str;
          else return false;
          id_doctor = T;
          return true;
      }
      public bool save(string fio, DateTime T) // Запись
      {
          List<string> str = new List<string>(fio.Split(' '));
          if (str.Count != 0) FIO = str;
          else return false;
          id_doctor = T;
          return true;
      }
      /*
      public bool record(List<string> fio) // Запись
      {
          if (fio.Count == 0) return false;
          if (FIO.Count == 0) id_doctor = DateTime.UtcNow; // Пишется по мировому времени
          FIO = fio;
          return true;
      }
       * */
  }
}
