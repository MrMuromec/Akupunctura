using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Akupunctura.Logik.Files
{
  public class measurement
  {
      private List<Int32> Currents = new List<Int32>();
      private List<Int32> Voltages = new List<Int32>();
      private string  id_doctor;
      private string id_patient;

      public void clean() // Чистка
      {
          Currents.Clear();
          Voltages.Clear();
          id_doctor = id_patient = "";
      }
      public void put_dimension(Int32 Current, Int32 Voltage) // Загрузка по точкам
      {
          Currents.Add(Current);
          Voltages.Add(Voltage);
      }
      public void put_dimension(List<Int32> Current, List<Int32> Voltage) // Загрузка
      {
          clean();
          Currents.Concat(Current);
          Voltages.Concat(Current);
      }
      public List<Int32> open_current() // Открытие
      {
          return Currents;
      }
      public List<Int32> open_voltage() // Открытие
      {
          return Voltages;
      }
      public void save_id_doctor(string id_d) // сохранение id
      {
          id_doctor = id_d;
      }
      public void save_id_patient(string id_p) // сохранение id
      {
          id_patient = id_p;
      }
      public string open_id_doctor() // Чтение id
      {
          return id_doctor;
      }
      public string open_id_patient() // Чтение id
      {
          return id_patient;
      }

  }
}
