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
        private BinaryFormatter formatter = new BinaryFormatter();

        public void folder(string Adress) // Создание папок
        {
            System.IO.Directory.CreateDirectory(Adress);
            System.IO.Directory.CreateDirectory(Adress + @"\" + Doctor);
            System.IO.Directory.CreateDirectory(Adress + @"\" + Patient);
            System.IO.Directory.CreateDirectory(Adress + @"\" + Measurement);
            System.IO.Directory.CreateDirectory(Adress + @"\" + Rights_doctor);
            System.IO.Directory.CreateDirectory(Adress + @"\" + Table_id);
        }
        public List<DateTime> ID(string Address) // Чтение названий и преобразования в id
        {
            List<DateTime> id = new List<DateTime>();            
            string str;
            //var dir = new DirectoryInfo(Address); // папка с файлами 
            var files = new List<string>(); // список для имен файлов 
            /*
            foreach (FileInfo file in dir.GetFiles("*.txt")) // извлекаем все файлы и кидаем их в список 
            {
                files.Add(Path.GetFileNameWithoutExtension(file.FullName)); // получаем полный путь к файлу и потом вычищаем ненужное, оставляем только имя файла. 
            }
            */
            DateTime T_id;
            for (int i = Directory.GetFiles(Address, "*.txt").Length - 1; i != -1; i--)
            {               
                str = Path.GetFileNameWithoutExtension(Directory.GetFiles(Address, "*.txt")[i]).Replace(';', ':');
                if (DateTime.TryParse(str, out T_id))
                    id.Add(T_id.ToUniversalTime());
            }
            /*
            for (int i = files.Count() - 1; i != -1; i--)
            {
                DateTime.TryParse(files[i].Replace(';', ':'), out T_id);
                id.Add(T_id);
            }
            */
            return id;
        }
        /*************************************************************************************************************/
        public void savr_d(string Address, data_check Data, string str) // Сохранения в БД
        {
            /*
             * Пример для ToString("u")
             * 15.06.2009 13:45:30 -> 2009-06-15 20:45:30Z
             * Поскольку : недопустим в название папки, то используем
             * Replace(':',';')
             * заменяем : на ;
             * */
            folder(Address);
            switch (str)
            {
                case Patient:
                    {
                        save_(Data.local_patient, Address + @"\" + Patient + @"\" + Data.local_patient.read_id().ToString("u").Replace(':', ';') + ".txt"); // Сохранеие пациентов            
                        break;
                    }
                case Doctor:
                    {
                        save_(Data.local_doctor, Address + @"\" + Doctor + @"\" + Data.local_doctor.read_id().ToString("u").Replace(':', ';') + ".txt"); // Сохранеие докторов
                        break;
                    }
                case Measurement:
                    {
                        save_(Data.local_mesument, Address + @"\" + Measurement + @"\" + Data.local_mesument.read_id_measurement().ToString("u").Replace(':', ';') + ".txt"); // Сохранеие измерений            
                        break;
                    }
                case Table_id:
                    {                       
                        //save_id(Address + @"\" + Table_id + @"\" + Data.local_mesument.read_id_measurement().ToString("u").Replace(':', ';') + ".txt"); // Сохранеие списков с индексацией        
                        break;
                    }
                case Rights_doctor:
                    {
                        // Прав пока нет!
                        break;
                    }
            }
        }
        /*
        public void save_id(string Address) // Сохранение списков с индексацией 
        {
            save_(Address);
        }
         * /
        /*************************************************************************************************************/
        private void save_(measurement meas, string str) // Сохранение 
        {
            using (FileStream f = new FileStream(str, FileMode.OpenOrCreate))
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
            using (FileStream f = new FileStream(str, FileMode.OpenOrCreate))
                formatter.Serialize(f, doc);
        }
        private void save_(patient pat, string str) // Сохранение
        {
            using (FileStream f = new FileStream(str, FileMode.OpenOrCreate))
                formatter.Serialize(f, pat);
        }
        /*
        private void save_(string str) // Сохранение
        {
            for (Int32 i = t_id.Count; i != 0; i--)
            {
                using (FileStream f = new FileStream(str + " " + i.ToString(), FileMode.Create))
                    formatter.Serialize(f, t_id[i-1]);
            }
        }
         * */
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
            if ((Directory.GetFiles(Address + @"\" + Doctor).Length !=0) && (d_id != DateTime.MinValue))
                Data.local_doctor = loading_(Data.local_doctor, Address + @"\" + Doctor + @"\" + d_id.ToString("u").Replace(':', ';') + ".txt"); // Загркзуа докторов
            if ((Directory.GetFiles(Address + @"\" + Patient).Length != 0) && (p_id != DateTime.MinValue))
                Data.local_patient = loading_(Data.local_patient, Address + @"\" + Patient + @"\" + p_id.ToString("u").Replace(':', ';') + ".txt"); // Загркзуа пациентов 
            if ((Directory.GetFiles(Address + @"\" + Measurement).Length != 0) && (m_id != DateTime.MinValue))
                Data.local_mesument=loading_(Data.local_mesument, Address + @"\" + Measurement + @"\" + m_id.ToString("u").Replace(':', ';') + ".txt"); // Загркзуа измерений
            // Прав пока нет!
            // Список id  что сохранение, что чтение надо править
            return Data;
        }
        /*
        public void loading_id(string Address) // Загркзуа списков с индексацией 
        {
            loading_(Address);
        }
         * */
        /*************************************************************************************************************/
        private measurement loading_(measurement meas, string str) // Загрузка
        {
            using (FileStream f = new FileStream(str, FileMode.OpenOrCreate))
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
            using (FileStream f = new FileStream(str, FileMode.Open))
                doc = (doctor)formatter.Deserialize(f);
            return doc;
        }
        private patient loading_(patient pat, string str) // Загрузка
        {
            using (FileStream f = new FileStream(str, FileMode.Open))
                pat = (patient)formatter.Deserialize(f);
            return pat;
        }
        /*
        private void loading_(string str) // Загрузка
        {
            t_id.Clear();
            for (Int32 i = t_id.Count; i != -1; i--)
            {
                using (FileStream f = new FileStream(str, FileMode.Create))
                    t_id.Add((table_id)formatter.Deserialize(f));
            }
        }
         * */
    }
}
