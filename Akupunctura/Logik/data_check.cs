using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Akupunctura.Logik.Files;

namespace Akupunctura.Logik
{
    public class data_check // Управление данными
    {
        private patient local_patient = new patient();
        private doctor local_doctor = new doctor();
        private measurement local_mesument = new measurement();
        public void put_point(Int32 Current, Int32 Voltage)
        {
            local_mesument.put_dimension(Current,Voltage);
        }
    }
}
