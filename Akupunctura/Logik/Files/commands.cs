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
        control_forms BD;
        public void loading_BD(control_forms bd)
        {
            BD = bd;
        }
        public void save_ (doctor doc, string str) // Сохранение
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream f = new FileStream(str, FileMode.Create))
                formatter.Serialize(f, doc);
        }
        public void save_(patient pat, string str) // Сохранение
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream f = new FileStream(str, FileMode.Create))
                formatter.Serialize(f,pat);
        }
        public void save_(rights_doctor rig, string str) // Сохранение
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream f = new FileStream(str, FileMode.Create))
                formatter.Serialize(f,rig);
        }

        public doctor loading_(doctor doc, string str) // Загрузка
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream f = new FileStream(str, FileMode.Create))
                doc = (doctor)formatter.Deserialize(f);
            return doc;
        }
        public patient loading_(patient pat, string str) // Загрузка
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream f = new FileStream(str, FileMode.Create))
                pat = (patient)formatter.Deserialize(f);
            return pat;
        }
        public rights_doctor loading_(rights_doctor rig, string str) // Загрузка
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream f = new FileStream(str, FileMode.Create))
                rig = (rights_doctor)formatter.Deserialize(f);
            return rig;
        }
    }
}
