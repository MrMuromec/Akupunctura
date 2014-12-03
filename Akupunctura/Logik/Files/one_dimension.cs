using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Akupunctura.Logik.Files
{
[Serializable]
    public class one_dimension
    {
        private Int32 Current = 0;
        private Int32 Voltage = 0;

    public void put (Int32 current, Int32 voltage)
        {
        Current=current;
        Voltage = voltage;
        }
    }
}
