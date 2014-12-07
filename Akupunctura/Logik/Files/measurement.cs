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

      public void put_dimension(Int32 Current, Int32 Voltage)
      {
          Currents.Add(Current);
          Voltages.Add(Voltage);
      }
  }
}
