using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Akupunctura.Logik;

using System.Windows;
using System.Threading;
using System.IO.Ports;
using System.IO;
using System.Runtime.InteropServices;

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
        bool pressure_timer = false;
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
        try
        {
            string[] availablePorts = SerialPort.GetPortNames();
            foreach (string port in availablePorts)
            {
                comboBox1.Items.Add(port);
            }
            comboBox1.SelectedIndex = 0;
            string str = comboBox1.SelectedItem.ToString();
            if (str != "")
            {
                serialPort1.PortName = str;
            }
            serialPort1.StopBits = StopBits.One;
            serialPort1.DataBits = 8;
            serialPort1.BaudRate = 921600;
            serialPort1.Parity = Parity.None;
            serialPort1.ReceivedBytesThreshold = 100;
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
            groupBox1.Enabled = groupBox2.Enabled = groupBox4.Enabled = true;
        }
        catch (Exception e9)
        {
            MessageBox.Show(e9.Message, "Window_Loaded");
        }
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
            //groupBox1.Enabled = true;
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
        textBox2.Text += " " + a[0].ToString();
    }
    private void text_mesegbox(byte[] a,string b) // Отображение
    {
        textBox2.Text += " " + a.ToString() + "*" + b;
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
    private void timer1_Tick(object sender, EventArgs e) // 0x01 по таймеру 
    {
        send(convert_A((byte)0x01));
    }
    private void button4_Click(object sender, EventArgs e) // Пуск таймера для множественной отправки 0х01
    {
        if (!pressure_timer)
        {
            text_mesegbox(convert_A((byte)0x01), textBox1.Text);
            timer1.Start();
        }
        else
        {
            timer1.Stop();
        }
        pressure_timer = !pressure_timer;
    }
    private void Send_Click(object sender, EventArgs e) // Отправка произвольного заданного значения
    {
        text_mesegbox(send(convert_A(Convert.ToByte(cb_first.Text+cd_second.Text, 16))));
    }
    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) // Выбор скорочти
    {
        if (comboBox2.Text != "")
        {
            serialPort1.BaudRate = Int32.Parse(comboBox2.Text);
        }
    }
    private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) // Выбор паритета
    {
        try
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0: serialPort1.Parity = Parity.None; break;
                case 1: serialPort1.Parity = Parity.Even; break;
                case 2: serialPort1.Parity = Parity.Odd; break;
                case 3: serialPort1.Parity = Parity.None; break;
                default: break;

            }
        }
        catch (Exception e6)
        {
            MessageBox.Show("comboBox4_SelectionChanged" + e6.Message);
        }
    }
    private void comboBox4_SelectedIndexChanged(object sender, EventArgs e) // Выбор стоповых битов
    {
        try
        {
            switch (comboBox4.SelectedIndex)
            {
                case 0: serialPort1.StopBits = StopBits.One; break;
                case 1: serialPort1.StopBits = StopBits.OnePointFive; break;
                case 2: serialPort1.StopBits = StopBits.Two; break;
                default: break;
            }
        }
        catch (Exception e8)
        {
            MessageBox.Show("comboBox5_SelectionChanged" + e8.Message);
        }
    }
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) // Выбор порта
    {
        serialPort1.PortName = comboBox1.SelectedItem.ToString();
    }
  }
}
