using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Akupunctura.Logik
{
    public class list_data // Список данных
    {
        public List<string> patients = new List<string>();
        public List<string> doctors = new List<string>();
        public List<string> mesuments = new List<string>();

        public void loading_patient() // Список пациентов
        {
            patients.Clear(); /// Дописать
        }
    }
}
