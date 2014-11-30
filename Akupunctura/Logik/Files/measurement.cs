using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Akupunctura.Logik.Files
{
  [Serializable]
  public class measurement
  {
      public List<one_dimension> point = new List<one_dimension>();
  }
    [NonSerialized]
    static public class commands_measurement
    {

    }
}
