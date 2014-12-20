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
        const string Doc = "doctor", Pat = "patient", Meas = "measurement", Rig = "rights_docto"; // Имена директорий
        string[] D;
        string[] P;
        BinaryFormatter formatter = new BinaryFormatter();

        public void savr_bd(string Address, data_check Data) // Сохранения в БД
        {
            /*
             * Пример для ToString("u")
             * 15.06.2009 13:45:30 -> 2009-06-15 20:45:30Z
             * Поскольку : недопустим в название папки, то используем
             * Replace(':',';')
             * заменяем : на ;
             * */
            save_(Data.local_doctor,Address + @"\" + Doc + @"\" + Data.local_doctor.read_id().ToString("u").Replace(':',';') + ".txt");
            save_(Data.local_patient, Address + @"\" + Pat + @"\" + Data.local_patient.read_id().ToString("u").Replace(':', ';') + ".txt");
            save_(Data.local_mesument, Address + @"\" + Meas + @"\" + Data.local_mesument.read_id_measurement().ToString("u").Replace(':', ';') + ".txt");
            // Прав пока нет!
        }

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

        public data_check loading_bd(string Address, data_check Data)
        {
            return Data;
        }

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

        public void name_list(string address) // Получение всех врачей и пациентов
        {
            D = Directory.GetFiles(address + @"\" + Doc, "*.txt");
            P = Directory.GetFiles(address + @"\" + Pat, "*.txt");
        }
    }
}
