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
        private Akupunctura Ak;
        private List<DateTime> id = new List<DateTime>();
        private doctor doc;

        public Authorization( doctor doc, Akupunctura Ak)
        {
            this.Ak= Ak;
            this.doc = doc;
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
                doc.save_disk(doc, Ak.get_Addres());
            }
            show_list(sender, e);
        }
        private void show_list(object sender, EventArgs e) // Показать
        {
            string[] rows = new string[1];
            id.Clear();
            id = Ak.add_rows(Ak.get_Addres() + doc.get_folder(Ak.get_Addres()));
            dataGridView1.Rows.Clear();
            for (int i = id.Count() - 1; i != -1; i--)
            {
                doc.read_disk(out doc, id[i], Ak.get_Addres());
                rows[0] = doc.read_fio("");
                dataGridView1.Rows.Add(rows);
            }
        }
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) // Двойной щелчёк по содержимому
        {
            int i = id.Count() - e.RowIndex - 1;
            if ((0 <= i) && (i < id.Count()))
            {
                Ak.id_d(id[i]);
                //doc.read_disk(out doc, id[i], Ak.get_Addres());
            }
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e) // Обновить
        {
            show_list(sender, e);
        }
    }
}
