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

namespace Akupunctura.Logik.Forms.Authorization
{
    public partial class Authorization : Form
    {
        private string adres;
        private Akupunctura Ak;
        private List<DateTime> id = new List<DateTime>();
        private doctor doc;

        public Authorization( doctor doc, Akupunctura Ak)
        {
            this.Ak= Ak;
            this.doc = doc;
            adres = Ak.get_Addres();
            InitializeComponent();
        }

        private void Authorization_Load(object sender, EventArgs e)  // Событие загрузки
        {
            textBox1.Text = " Введите ФИО через пробел и нажмите кнопку 'Ок'";
            dataGridView1.AllowUserToAddRows = false;
            show_list(sender, e);
        }
        private void button1_Click(object sender, EventArgs e) // Отмена
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e) // Добавить
        {
            if (!doc.save(textBox1.Text, DateTime.UtcNow))
                MessageBox.Show("введите ФИО");
            else
            {
                doc.save_disk(doc,adres);
            }
            show_list(sender, e);
        }
        private void show_list(object sender, EventArgs e) // Показать
        {
            id.Clear();
            id = Ak.add_rows(adres + doc.get_folder(adres));
            dataGridView1.Rows.Clear();
            for (int i = id.Count() - 1; i != -1; i--)
            {

                string[] rows = new string[1];
                //data = data.BD.command.loading_d(data.BD.get_Addres(), data, id[i], DateTime.MinValue, DateTime.MinValue);
                //rows[0] = data.local_doctor.read_fio("");
                doc.read_disk(out doc, id [i],adres);
                rows[0] = doc.read_fio("");
                dataGridView1.Rows.Add(rows);
            }
        }
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) // Двойной щелчёк по содержимому
        {
            int i = id.Count() - e.RowIndex - 1;
          /*
            if ((-1 < i) && (i < id.Count()))
                data = data.BD.command.loading_d(data.BD.get_Addres(), data, id[i], DateTime.MinValue, DateTime.MinValue);
            data.BD.local_doctor = data.local_doctor;
           * */
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e) // Обновить
        {
            show_list(sender, e);
        }
    }
}
