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
        private List<UInt16> numbers_form = new List<UInt16>();

        public void loading_patient() // Список пациентов
        {
            patients.Clear(); /// Дописать
        }
        public UInt16 new_issue() // Номер data_check
        {
            UInt16 N = numbers_form.Min();
            for (; numbers_form.IndexOf(N)!=-1; N++) if (N == UInt16.MaxValue) N = 1;           
            return N;
        }
    }
}
