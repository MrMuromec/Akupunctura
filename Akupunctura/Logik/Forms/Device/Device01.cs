using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Akupunctura.Logik;


namespace Akupunctura.Logik.Forms.Device
{
    public partial class Device01 : Form
    {
        System.IO.Ports.SerialPort serialPort1 = new System.IO.Ports.SerialPort();
        object sw_locker = new object();
        byte[] tmp = new byte[5];
        byte[] buf = new byte[5];
        int n = 0;
        int FileNum = 0;
        data_check data;
        Int32[] point_CV = new Int32[2];
        public Device01(Akupunctura mainForm, data_check parameters)
        {
            data = parameters;
            InitializeComponent();
        }

        void serialPort1_DataReceived(object sender, EventArgs e) // чтение и преобразования сообщений в 32-разрядное целое число
        {
            try
            {
                byte[] b = new byte[serialPort1.BytesToRead];
                serialPort1.Read(b, 0, b.Length);
                 for (int j = 0; j < b.Length; j++)
                 {
                    if (b[j] == 0x0F)
                    {
                        FileNum++;
                        continue;
                    }
                    if (b[j] == 0x07)
                    {
                        continue;
                    }
                    if ((b[j] & 0xC0) == 0x40)//первый байт
                    {
                        if (n >= 0)
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
                                    if (p.IsI)
                                    {
                                        point_CV[1] = p.Int_pack;
                                        data.put_point(point_CV[0], point_CV[1]);
                                    }
                                    else
                                    {
                                        point_CV[0] = p.Int_pack;
                                    }
                                    n = 0;
                                }
                                continue;
                            }
                            continue;
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
        //MessageBox.Show(data.number_form.ToString());
    }
    private void Device01_FormClosed(object sender, FormClosedEventArgs e)
    {
        data.number_form = 0;
    }
    private void Connect_Click_1(object sender, EventArgs e) // Подключение
    {
        try
        {
            serialPort1.Open();
            if (serialPort1.IsOpen)
            {
                groupBox2.Visible = groupBox4.Visible = true;
                Connect.Enabled = false;
                Disconnect.Enabled = true;
            }
        }
        catch (Exception e1)
        {
            MessageBox.Show(e1.Message, "Error_Button_Click");
        }
    }
    private void Disconnect_Click_1(object sender, EventArgs e) // Выключение
    {
    try
            {
                serialPort1.Close();
                if (!serialPort1.IsOpen)
                {
                    Connect.Enabled = true;
                    Disconnect.Enabled = false;
                    groupBox2.Visible = groupBox4.Visible = false;
                }
            }
    catch (Exception e2)
    {
        MessageBox.Show(e2.Message , "Button_Click_1");
    }
    }
    private byte[] convert_A(byte A) // Перевод в массив
    {
        byte[] a = { A };
        return a;
    }
    private byte[] send(byte[] a) // Отправка
    {
        serialPort1.Write(a, 0, a.Length);
        return a;
    }
    private void text_mesegbox (byte[] a) // Отображение
    {
        textBox2.Text += " " + a.ToString();
    }
    private void button1_Click(object sender, EventArgs e) // 0x00
    {
        text_mesegbox(send(convert_A((byte)0x00)));
    }

    private void button2_Click(object sender, EventArgs e) // 0x01
    {
        text_mesegbox(send(convert_A((byte)0x01)));
    }

    private void button3_Click(object sender, EventArgs e) // 0xFF
    {
        text_mesegbox(send(convert_A((byte)0xFF)));
    }
  }
}
