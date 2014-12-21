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
        private string Adress;
        private control_forms BD;
        public Position(Akupunctura mainForm, control_forms BD) // Инициализация
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
            Adress = textBox1.Text + @"\БД";                
            BD.address = Adress;
            System.IO.Directory.CreateDirectory(Adress);
            this.Close();
        }

        private void Position_Load(object sender, EventArgs e) // Событие загрузки
        {
            Adress = BD.address.Replace(@"\БД", "");
            textBox1.Text = Adress;
        }
    }
}
