using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Akupunctura.Logik.Forms.Рosition_folders
{
    public partial class Position : Form
    {
        private control_forms BD;
        public Position(control_forms BD) // Инициализация
        {
            this.BD = BD;           
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) // Отмена
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) // Ок
        {   
            try
            {
                System.IO.Directory.CreateDirectory(textBox1.Text + @"\БД");
                BD.Addres(textBox1.Text + @"\БД");
                this.Close();
            }
            catch (System.ArgumentException e2)
            {
                MessageBox.Show(e2.ToString(),"Ошибка выбора");
            }
        }

        private void Position_Load(object sender, EventArgs e) // Событие загрузки
        {
            textBox1.Text = BD.get_Addres().Replace(@"\БД", "");
        }
    }
}
