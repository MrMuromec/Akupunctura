using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Akupunctura.Logik;

namespace Akupunctura
{
  public partial class Akupunctura : Form
  {
    public control_database BD = new control_database(); // инициализация рабочей базы и логики работы

    public Akupunctura()
    {
      InitializeComponent();
    }

    private void МенюРаботыПрибораToolStripMenuItem_Click(object sender, EventArgs e)
    {
        BD.MainForms(this, "Device01");
        /*
      Device_01 device01 = new Device_01(this);
      device01.MdiParent = this;
      device01.Show();
         * */
    }
  }
}
