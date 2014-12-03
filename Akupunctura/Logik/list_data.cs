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
        private byte[] numbers_form = new byte[byte.MaxValue]; // ноль запрещён

        public void loading_patient() // Список пациентов
        {
            patients.Clear(); /// Дописать
        }
        public byte new_issue() // Номер data_check
        {
            byte N =0;
            for (byte i = 1; numbers_form[i] == i; i++) N = i;
            if (N == byte.MaxValue) return 0;
            N++;
            numbers_form[N] = N;
            return N;
        }
        public void del_issue(byte N)
        {
            numbers_form[N] = 0;
        }
    }
}
