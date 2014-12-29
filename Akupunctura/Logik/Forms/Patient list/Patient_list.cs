using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Akupunctura.Logik.Forms.patient_list
{
    public partial class Patient_list : Form
    {
        List<DateTime> id = new List<DateTime>();
        data_check data;
        public Patient_list(Akupunctura mainForm, data_check parameters)
        {
            data = parameters;
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e) // Отмена
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) // Добавить
        {
            if (!data.local_patient.save(textBox1.Text, DateTime.UtcNow, dateTimePicker1.Value))
                MessageBox.Show("введите ФИО");
            else
            {
                data.BD.command.table.save_id_patient(data.local_patient.read_id());
                data.BD.command.t_id.Add(data.BD.command.table);
                data.BD.command.savr_d(data.BD.address, data, "patient");
                //data.BD.command.savr_d(data.BD.address, data, "table_idh");
            }
            show_list(sender, e);
        }
        private void Patient_list_Load(object sender, EventArgs e) // Загрузка
        {
            textBox1.Text = " Введите ФИО через пробел и нажмите кнопку 'Ок'";
            dataGridView1.AllowUserToAddRows = false;
            show_list(sender, e);
        }
        private void add_rows() // Создание не совпадающего списка id пациентов
        {
            id.Clear();
            data.BD.command.folder(data.BD.address);
            id = data.BD.command.ID(data.BD.address + @"\" + "patient");
        }
        private void show_list(object sender, EventArgs e) // Показать
        {
            add_rows();
            dataGridView1.Rows.Clear();
            for ( int i = id.Count() - 1 ; i != -1 ; i-- )
            {
                string[] rows = new string[2];
                /*
                 * 1) Адрес
                 * 2) Доктор - не имеет смысла
                 * 3) Пациент
                 * 4) Измерение - не имеет смысла 
                 * */
                data = data.BD.command.loading_d(data.BD.address, data, DateTime.MinValue, id[i], DateTime.MinValue);
                rows[0] = data.local_patient.read_fio("");
                rows[1] = data.local_patient.read_data().ToString("d");
        
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
            if ((-1<i)&&(i<id.Count()))
                data = data.BD.command.loading_d(data.BD.address, data, DateTime.MinValue, id[i], DateTime.MinValue);
            data.BD.local_patient = data.local_patient;
            this.Close();
            //MessageBox.Show(data.local_patient.read_fio(""));
        }
    }
}
