using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Akupunctura.Logik.Forms.Device
{
  public partial class Device01 : Form
  {
    public Device01(Akupunctura mainForm)
    {
      InitializeComponent();
    }

    public void Device01_Load(object sender, EventArgs e) // Событие загрузки формы (установка параметров соединения по умолчанию)
    {
        // Не работает!!!!
    }
     

    private void Disconnect_Click(object sender, EventArgs e)
    {

    }

    private void Connect_Click(object sender, EventArgs e)
    {

    }
  }
}
