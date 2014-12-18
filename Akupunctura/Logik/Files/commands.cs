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
        BinaryFormatter formatter = new BinaryFormatter();

        public void savr_bd(string Address, data_check Data, string save_parameter) // Сохранения в БД
        {
            const string Doc = "doctor", Pat = "patient", Meas = "measurement", Rig = "rights_docto"; // Имена директорий
            List<string> symbol = new List<string>(save_parameter.Split(' '));
            for (int i = symbol.Count(); i>-1; i--)
            {
              switch (symbol[i].ToLower())
              {
                case Doc:
                  {
                    save_(Data.local_doctor,Address + @"\" + Doc + @"\" + Data.local_doctor.read("id") + ".txt");
                    break;
                  }
                case Pat:
                  {
                    save_(Data.local_patient, Address + @"\" + Pat + @"\" + Data.local_patient.read("id") + ".txt");
                    break;
                  }
                case Meas:
                  {
                    break;
                  }
                case Rig:
                  {
                    break;
                  }
                default: break; // ошибочное название
              }
            }
        }

        private void save_(measurement meas, string str) // Сохранение 
        {
            List<Int32> C = meas.open_dimension("currents");
            List<Int32> V = meas.open_dimension("voltages");
            try
            {
                StreamWriter sw = new StreamWriter(str + ".txt");
                for (int i = 0; i < C.Count(); i++)
                    sw.WriteLine(" " + C[i].ToString() + " " + V[i].ToString()); // А потому что так было раньше, но не совсем так
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
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


        public measurement loading_(measurement meas, string str) // Загрузка
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader(str + ".txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    meas.put_dimension(Convert.ToInt32(line.Split(' ')[1]), Convert.ToInt32(line.Split(' ')[2])); // Разбор типизированного файла
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            return meas;
        }
        public doctor loading_(doctor doc, string str) // Загрузка
        {
            using (FileStream f = new FileStream(str, FileMode.Create))
                doc = (doctor)formatter.Deserialize(f);
            return doc;
        }
        public patient loading_(patient pat, string str) // Загрузка
        {
            using (FileStream f = new FileStream(str, FileMode.Create))
                pat = (patient)formatter.Deserialize(f);
            return pat;
        }
        public rights_doctor loading_(rights_doctor rig, string str) // Загрузка
        {
            using (FileStream f = new FileStream(str, FileMode.Create))
                rig = (rights_doctor)formatter.Deserialize(f);
            return rig;
        }
    }
}
