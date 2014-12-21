using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Akupunctura.Logik.Files
{
  [Serializable]
  public class measurement
  {
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
      public DateTime read_id_measurement() // Чтение id
      {
          return id_measurement;
      }

  }
}
