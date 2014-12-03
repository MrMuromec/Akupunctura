using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Akupunctura.Logik.Files
{
  [Serializable]
  public class measurement
  {
      private List<one_dimension> points = new List<one_dimension>();
      one_dimension p = new one_dimension();

      public void put_dimension(Int32 Current, Int32 Voltage)
      {
          p.put (Current,Voltage);
          points.Add(p);
      }
  }
}
