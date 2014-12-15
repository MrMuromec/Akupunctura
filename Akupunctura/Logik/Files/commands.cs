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
        int FileNum = 0;
        StreamWriter sw;
        object sw_locker = new object();
        FileInfo fi;

        public void save_(measurement meas, string str) // Сохранение
        {
            List<Int32> C = meas.open_dimension("currents");
            List<Int32> V = meas.open_dimension("voltages");
            lock (sw_locker)
            {
                fi = new FileInfo(".txt");
                FileNum++;
                sw = fi.AppendText();
            }
            for (int i = 0; i < C.Count();i++ ) 
                SetText(" " + C[i].ToString() + " " + V[i].ToString() + "\r\n");
        }
        private void SetText(string text)
        {
            lock (sw_locker)
            {
                sw.Write(text);
                sw.Flush();
            }
        }
        public void save_ (doctor doc, string str) // Сохранение
        {
            using (FileStream f = new FileStream(str, FileMode.Create))
                formatter.Serialize(f, doc);
        }
        public void save_(patient pat, string str) // Сохранение
        {
            using (FileStream f = new FileStream(str, FileMode.Create))
                formatter.Serialize(f,pat);
        }
        public void save_(rights_doctor rig, string str) // Сохранение
        {
            using (FileStream f = new FileStream(str, FileMode.Create))
                formatter.Serialize(f,rig);
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
