using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Akupunctura.Logik.Files
{
    public class commands
    {
        private const string Doctor = "doctor", Patient = "patient", Measurement = "measurement", Rights_doctor = "rights_doctor", Table_id = "table_id"; // Имена директорий
        private List<table_id> t_id = new List<table_id>();
        private BinaryFormatter formatter = new BinaryFormatter();

        private void folder(string Adress) // Создание папок
        {
            System.IO.Directory.CreateDirectory(Adress);
            System.IO.Directory.CreateDirectory(Adress + @"\" + Doctor);
            System.IO.Directory.CreateDirectory(Adress + @"\" + Patient);
            System.IO.Directory.CreateDirectory(Adress + @"\" + Measurement);
            System.IO.Directory.CreateDirectory(Adress + @"\" + Rights_doctor);
            System.IO.Directory.CreateDirectory(Adress + @"\" + Table_id);
        }
        /*************************************************************************************************************/
        public void savr_d(string Address, data_check Data) // Сохранения в БД
        {
            /*
             * Пример для ToString("u")
             * 15.06.2009 13:45:30 -> 2009-06-15 20:45:30Z
             * Поскольку : недопустим в название папки, то используем
             * Replace(':',';')
             * заменяем : на ;
             * */
            folder(Address);
            save_(Data.local_doctor,Address + @"\" + Doctor + @"\" + Data.local_doctor.read_id().ToString("u").Replace(':',';') + ".txt"); // Сохранеие докторов
            save_(Data.local_patient, Address + @"\" + Patient + @"\" + Data.local_patient.read_id().ToString("u").Replace(':', ';') + ".txt"); // Сохранеие пациентов
            save_(Data.local_mesument, Address + @"\" + Measurement + @"\" + Data.local_mesument.read_id_measurement().ToString("u").Replace(':', ';') + ".txt"); // Сохранеие измерений
            // Прав пока нет!
            save_(Address + @"\" + Table_id + @"\" + Data.local_mesument.read_id_measurement().ToString("u").Replace(':', ';') + ".txt"); // Сохранеие списков с индексацией
        }
        public void save_id(string Address) // Сохранение списков с индексацией 
        {
            folder(Address);
            save_(Address + @"\" + Doctor + @"\" + "" + ".txt");
        }
        /*************************************************************************************************************/
        private void save_(measurement meas, string str) // Сохранение 
        {
            using (FileStream f = new FileStream(str, FileMode.Create))
                formatter.Serialize(f, meas);
            using (StreamWriter sw = new StreamWriter(str + "_VC" + ".txt"))
            {
                List<Int32> C = meas.read_current();
                List<Int32> V = meas.read_voltage();
                for (int i = 0; i < C.Count(); i++)
                    sw.WriteLine(" " + C[i].ToString() + " " + V[i].ToString()); // А потому что так было раньше, но не совсем так
                sw.Close();
            }
        }
        private void save_(doctor doc, string str) // Сохранение
        {
            using (FileStream f = new FileStream(str, FileMode.Create))
                formatter.Serialize(f, doc);
        }
        private void save_(patient pat, string str) // Сохранение
        {
            using (FileStream f = new FileStream(str, FileMode.Create))
                formatter.Serialize(f,pat);
        }
        private void save_(rights_doctor rig, string str) // Сохранение
        {
            using (FileStream f = new FileStream(str, FileMode.Create))
                formatter.Serialize(f,rig);
        }
        private void save_(string str) // Сохранение
        {
            for (Int32 i = t_id.Count; i != 0; i--)
            {
                using (FileStream f = new FileStream(str, FileMode.Create))
                    formatter.Serialize(f, t_id[i-1]);
            }
        }
        /*************************************************************************************************************/
        /*                                             Загрузки                                                      */
        /*************************************************************************************************************/
        public data_check loading_d(string Address, data_check Data, DateTime d_id, DateTime p_id, DateTime m_id) // Загркзуа измерения
        {
            /*
             * Пример для ToString("u")
             * 15.06.2009 13:45:30 -> 2009-06-15 20:45:30Z
             * Поскольку : недопустим в название папки, то используем
             * Replace(':',';')
             * заменяем : на ;
             * */
            folder(Address);
            loading_(Data.local_doctor, Address + @"\" + Doctor + @"\" + d_id.ToString("u").Replace(':', ';') + ".txt"); // Загркзуа докторов
            loading_(Data.local_patient, Address + @"\" + Doctor + @"\" + p_id.ToString("u").Replace(':', ';') + ".txt"); // Загркзуа пациентов 
            loading_(Data.local_mesument, Address + @"\" + Doctor + @"\" + m_id.ToString("u").Replace(':', ';') + ".txt"); // Загркзуа измерений
            // Прав пока нет!
            return Data;
        }
        public void loading_id(string Address) // Загркзуа списков с индексацией 
        {
            folder(Address);
            loading_(Address + @"\" + Doctor + @"\" + "" + ".txt");
        }
        /*************************************************************************************************************/
        private measurement loading_(measurement meas, string str) // Загрузка
        {
            using (FileStream f = new FileStream(str, FileMode.Create))
                meas = (measurement)formatter.Deserialize(f);
            using (StreamReader sr = new StreamReader(str + "_VC" + ".txt"))
            {
                String line;
                line = sr.ReadLine();
                while (line != null)
                {
                    meas.save_dimension(Convert.ToInt32(line.Split(' ')[1]), Convert.ToInt32(line.Split(' ')[2])); // Разбор типизированного файла
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            return meas;
        }
        private doctor loading_(doctor doc, string str) // Загрузка
        {
            using (FileStream f = new FileStream(str, FileMode.Create))
                doc = (doctor)formatter.Deserialize(f);
            return doc;
        }
        private patient loading_(patient pat, string str) // Загрузка
        {
            using (FileStream f = new FileStream(str, FileMode.Create))
                pat = (patient)formatter.Deserialize(f);
            return pat;
        }
        private rights_doctor loading_(rights_doctor rig, string str) // Загрузка
        {
            using (FileStream f = new FileStream(str, FileMode.Create))
                rig = (rights_doctor)formatter.Deserialize(f);
            return rig;
        }
        private void loading_(string str) // Загрузка
        {
            t_id.Clear();
            for (Int32 i = t_id.Count; i != 0; i--)
            {
                using (FileStream f = new FileStream(str, FileMode.Create))
                    t_id.Add((table_id)formatter.Deserialize(f));
            }
        }
    }
}
