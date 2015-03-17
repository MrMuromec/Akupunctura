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
        System.IO.Ports.SerialPort Port = new System.IO.Ports.SerialPort();
        private Queue<byte> DataByteQueue = new Queue<byte>();
        byte b;
        //object sw_locker = new object();
        //byte[] tmp = new byte[5];
        //byte[] buf = new byte[5];
        //int n = 0;
        //int FileNum = 0;
        data_check data;
        bool pressure_timer = false;
        //Int32[] point_CV = new Int32[2];
        
        public Device01(Akupunctura mainForm, data_check parameters)
        {
            data = parameters;
            InitializeComponent();
        }

        void serialPort_DataReceived(object sender, EventArgs e) // чтение и преобразования сообщений в 32-разрядное целое число
        {            
            try
            {
                Thread.Sleep(0);// Элемент магии
                for (; Port.BytesToRead >= 1; b = (byte)Port.ReadByte()) 
                    DataByteQueue.Enqueue(b);
            }
            catch (Exception e3)
            {
                MessageBox.Show("serialPort1_DataReceived" + e3.Message);
            }
            /*
            try
            {
                byte[] b = new byte[serialPort1.BytesToRead];
                serialPort1.Read(b, 0, b.Length);
                 for (int j = 0; j < b.Length; j++)
                 {
                    if (b[j] == 0x0F)
                    {                        
                        data.local_mesument.clean();
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
             * */
    }
    public void Device01_Load(object sender, EventArgs e) // Событие загрузки формы (установка параметров соединения по умолчанию)
    {
        try
        {
            // Выбор порта
            string[] availablePorts = SerialPort.GetPortNames();
            foreach (string port in availablePorts)
            {
                comboBox1.Items.Add(port);
            }
            comboBox1.SelectedIndex = 0;
            string str = comboBox1.SelectedItem.ToString();
            if (str != "")
            {
              Port.PortName = str;
            }
            // Настройки порта
            Port.StopBits = StopBits.One;
            Port.DataBits = 8;
            Port.BaudRate = 921600;
            Port.Parity = Parity.None;
            ////////
            Port.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived); // Назначения обработчика для событию SerialPort.DataReceived
            //serialPort1.ReceivedBytesThreshold = 100;
            groupBox1.Enabled = groupBox4.Enabled = true; // Поля
        }
        catch (Exception e9)
        {
            MessageBox.Show(e9.Message, "Window_Loaded");
        }
        ;
    }
    private void Device01_FormClosed(object sender, FormClosedEventArgs e) // Событие закрытия формы 
    {
        timer1.Stop();
        Disconnect_Click_1(sender,e);
        data.Free = true;
    }
    private void Connect_Click_1(object sender, EventArgs e) // Подключение
    {
        try
        {
            Port.Open();
            if (Port.IsOpen)
            {
                groupBox2.Enabled = true;
                groupBox4.Visible = true;
                Connect.Enabled = false;
                Disconnect.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = true;
            }
            textBox1.Text = "200";
            textBox2.Clear();
        }
        catch (Exception e1)
        {
            MessageBox.Show(e1.Message, "Подключение");            
        }
    }
    private void Disconnect_Click_1(object sender, EventArgs e) // Выключение
    {
    try
            {
                Port.Close();
                groupBox2.Enabled = false;
                if (!Port.IsOpen)
                {
                    Connect.Enabled = true;
                    Disconnect.Enabled = false;
                    groupBox4.Visible = false;
                }
            }
    catch (Exception e2)
    {
        MessageBox.Show(e2.Message, "Выключение");
    }
    }
    private byte[] convert_A(byte A) // Перевод в массив
    {
        byte[] a = { A };
        return a;
    }
    private byte[] send(byte[] a) // Отправка
    {
        Port.Write(a, 0, a.Length);
        return a;
    }
    private void text_mesegbox (byte[] a) // Отображение
    {
        textBox2.Text += " " + a[0].ToString();
    }
    private void text_mesegbox(byte[] a,string b) // Отображение
    {
        textBox2.Text += " " + a[0].ToString() + "*" + b;
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
            Port.BaudRate = Int32.Parse(comboBox2.Text);
        }
    }
    private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) // Выбор паритета
    {
        try
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0: Port.Parity = Parity.None; break;
                case 1: Port.Parity = Parity.Even; break;
                case 2: Port.Parity = Parity.Odd; break;
                case 3: Port.Parity = Parity.None; break;
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
                case 0: Port.StopBits = StopBits.One; break;
                case 1: Port.StopBits = StopBits.OnePointFive; break;
                case 2: Port.StopBits = StopBits.Two; break;
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
        Port.PortName = comboBox1.SelectedItem.ToString();
    }
  }
}
