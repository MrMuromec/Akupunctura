using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Akupunctura.Logik.Files;

namespace Akupunctura.Logik.Forms.patient_list
{
    public partial class Patient_list : Form
    {
        private Akupunctura Ak;
        private List<DateTime> id = new List<DateTime>();
        private patient pat;

        public Patient_list(patient pat, Akupunctura Ak)
        {
            this.Ak = Ak;
            this.pat = pat;
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e) // Отмена
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) // Добавить
        {
            if (!pat.save(textBox1.Text, DateTime.UtcNow, dateTimePicker1.Value))
                MessageBox.Show("введите ФИО");
            else
            {
                pat.save_id();
                pat.save_disk(pat, Ak.get_Addres());
            }
            show_list(sender, e);
        }
        private void Patient_list_Load(object sender, EventArgs e) // Загрузка
        {
            textBox1.Text = " Введите ФИО через пробел и нажмите кнопку 'Ок'";
            dataGridView1.AllowUserToAddRows = false;
            show_list(sender, e);
        }
        private void show_list(object sender, EventArgs e) // Показать
        {
            string[] rows = new string[2];
            id.Clear();
            id = Ak.add_rows(Ak.get_Addres() + pat.get_folder(Ak.get_Addres()));
            dataGridView1.Rows.Clear();
            for (int i = id.Count() - 1; i != -1; i--)
            {
                pat.read_disk(out pat, id[i], Ak.get_Addres());
                rows[0] = pat.read_fio("");
                rows[1] = pat.read_data().ToString("d");
                dataGridView1.Rows.Add(rows);
            }
        }
        private void button3_Click(object sender, EventArgs e) // Обновить
        {
            show_list(sender, e);
        }
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) // Двойной щелчёк по содержимому
        {
            int i = id.Count() - e.RowIndex - 1;
            if ((0 <= i) && (i < id.Count()))
            {
                Ak.id_p(id[i]);
                //doc.read_disk(out doc, id[i], Ak.get_Addres());
            }
            this.Close();
            /*
            int i = id.Count() - e.RowIndex - 1;
            if ((-1<i)&&(i<id.Count()))
                data = data.BD.command.loading_d(data.BD.get_Addres(), data, DateTime.MinValue, id[i], DateTime.MinValue);
            data.BD.local_patient = data.local_patient;
            this.Close();
             * */
            //MessageBox.Show(data.local_patient.read_fio(""));
        }
    }
}
