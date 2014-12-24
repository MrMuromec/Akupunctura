using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Akupunctura.Logik.Forms.Authorization
{
    public partial class Authorization : Form
    {
        private control_forms BD;
        public Authorization(Akupunctura mainForm, control_forms BD)
        {
            this.BD = BD;   
            InitializeComponent();
        }

        private void Authorization_Load(object sender, EventArgs e)  // Событие загрузки
        {
            textBox1.Text = " Введите ФИО через пробел и нажмите кнопку 'Ок'";
        }
        private void button1_Click(object sender, EventArgs e) // Отмена
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e) // Ок
        {
            BD.local_doctor.save(textBox1.Text, DateTime.UtcNow);
            // Дописать сохранение в бд
            this.Close();
        }
    }
}
