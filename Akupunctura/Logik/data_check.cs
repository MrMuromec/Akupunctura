using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Akupunctura.Logik.Files;

namespace Akupunctura.Logik
{
    public class data_check // Управление данными
    {
        public byte number_form = 0;
        private patient local_patient = new patient();
        private doctor local_doctor = new doctor();
        private measurement local_mesument = new measurement();
        private control_forms BD;
        public void put_point(Int32 Current, Int32 Voltage)
        {
            local_mesument.put_dimension(Current,Voltage);
        }
        public void all_db(control_forms bd)
        {
            BD = bd;
        }

    }
}
