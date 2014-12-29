using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Akupunctura.Logik.Files
{
    [Serializable]
    public class table_id // Аналог строки в таблице со столбцами: доктор, пациент, измерение
    {
        private DateTime id_doctor;
        private DateTime id_patient;
        private DateTime id_measurement;

        public void save_id_doctor(DateTime id_d) // сохранение id
        {
            id_doctor = id_d;
        }
        public void save_id_patient(DateTime id_p) // сохранение id
        {
            id_patient = id_p;
        }
        public void save_id_measurement(DateTime id_m) // сохранение id
        {
            id_measurement = id_m;
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
