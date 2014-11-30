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

    System.IO.Ports.SerialPort serialPort1 = new System.IO.Ports.SerialPort();
    object sw_locker = new object();
    bool bb = true;
    byte[] tmp = new byte[5];
    byte[] buf = new byte[5];
    int n = 0;
    int FileNum = 0;

    void serialPort1_DataReceived(object sender, EventArgs e)
    {
        try
        {
            byte[] b = new byte[serialPort1.BytesToRead];
            serialPort1.Read(b, 0, b.Length);
            if (bb == false)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < b.Length; j++)
                {
                    string s = Convert.ToString(b[j], 2);
                    if (s.Length < 8)
                        s = s.PadLeft(8, '0');
                    else sb.Append("\r\n");
                    sb.Append(s);
                    sb.Append('.');
                }
                SetText("\r\nThe End\r\n" + sb.ToString());
            }
            if (bb == true)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (b[j] == 0x0F)
                    {
                        FileOpen();
                        continue;
                    }
                    if (b[j] == 0x07)
                    {
                        continue;
                    }
                    if ((b[j] & 0xC0) == 0x40)//первый байт
                    {
                        if (n == 0)
                        {
                            tmp = new byte[5];
                            n = 0;
                            tmp[n] = b[j];
                            n++;
                            continue;
                        }
                        if (n > 0)
                        {
                            tmp = new byte[5];
                            n = 0;
                            tmp[n] = b[j];
                            n++;
                            continue;
                        }
                        continue;
                    }
                    if (((b[j] & 0x80) != 0))//не первый байт
                    {

                        if (n > 0)
                        {
                            if (n < 5)
                            {
                                tmp[n] = b[j];
                                n++;
                                if (n == 5)
                                {
                                    package p = new package(tmp);
                                    SetText(" " + p.Int_pack.ToString());
                                    if (p.IsI) SetText("\r\n");
                                    n = 0;
                                }
                                continue;
                            }
                            continue;
                        }
                    }
                }
            }

        }
        catch (Exception e3)
        {
            MessageBox.Show("serialPort1_DataReceived" + e3.Message);
        }
    }
    public void Device01_Load(object sender, EventArgs e) // Событие загрузки формы (установка параметров соединения по умолчанию)
    {
        MessageBox.Show("AAAAAAAAAAAAAAAAAAAAAAAa");
    }
     

    private void Disconnect_Click(object sender, EventArgs e)
    {

    }

    private void Connect_Click(object sender, EventArgs e)
    {

    }
  }
}
