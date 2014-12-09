using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Akupunctura.Logik.Files
{
  [Serializable]
  public class measurement
  {
      private List<Int32> Currents = new List<Int32>();
      private List<Int32> Voltages = new List<Int32>();
      private DateTime id_doctor;
      private DateTime id_patient;

      public void put_dimension(Int32 Current, Int32 Voltage)
      {
          Currents.Add(Current);
          Voltages.Add(Voltage);
      }
      public void save_mesurement(DateTime id_d, DateTime id_p)
      {
          id_doctor = id_d;
          id_patient = id_p;
      }
  }
}
