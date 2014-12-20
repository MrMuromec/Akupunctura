using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Akupunctura.Logik.Files
{
  public class measurement
  {
      private DateTime id_doctor;
      private DateTime id_patient;
      private DateTime id_measurement;
      [NonSerialized]
      private List<Int32> Currents = new List<Int32>();
      private List<Int32> Voltages = new List<Int32>();

      public void clean() // Чистка
      {
          Currents.Clear();
          Voltages.Clear();
          // А вот с датой хз
      }
      public void save_dimension(Int32 Current, Int32 Voltage) // сохранение (по точкам)
      {
          Currents.Add(Current);
          Voltages.Add(Voltage);
      }
      public void save_dimension(List<Int32> Current, List<Int32> Voltage) // сохранение
      {
          clean();
          Currents.Concat(Current);
          Voltages.Concat(Current);
      }
      public void save_id_doctor(DateTime id_d) // сохранение id
      {
          id_doctor = id_d;
      }
      public void save_id_patient(DateTime id_p) // сохранение id
      {
          id_patient = id_p;
      }
      public void save_(DateTime id_m) // сохранение id
      {
          id_measurement = id_m;
      }

      public List<Int32> read_current() // Чтение
      {
          return Currents;
      }
      public List<Int32> read_voltage() // Чтение
      {
          return Voltages;
      }
      public DateTime read_id_doctor() // Чтение id
      {
          return id_doctor;
      }
      public DateTime read_id_patient() // Чтение id
      {
          return id_patient;
      }
      public DateTime read_id_measurement() // Чтение id
      {
          return id_measurement;
      }

  }
}
