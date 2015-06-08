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
using Akupunctura.Logik.Files;

namespace Akupunctura.Logik.Forms.Device
{
    public partial class Device01 : Form
    {
        private volatile System.IO.Ports.SerialPort Port = new System.IO.Ports.SerialPort(); // Порт (COM порт, настройки далее в проге)
        private volatile bool status_Decoder; // Стутус разбора
        private measurement mes;
        private bool pressure_timer = false;
        private Int32[] point_CV = new Int32[2]; // Точка = ток, напряжение
        private Akupunctura Ak;
        private DateTime id_d, id_p;

        public Device01(measurement mes, DateTime id_d, DateTime id_p, Akupunctura Ak)
        {
            this.id_d = id_d;
            this.id_p = id_p;
            this.Ak = Ak;
            this.mes = mes;
            InitializeComponent();
        }

    public void Device01_Load(object sender, EventArgs e) // Событие загрузки формы (установка параметров соединения по умолчанию)
    {
        try
        {
            // Установка отправки произвольного заданного значения в позицию по умолчанию для значения 0x00
            cb_first.SelectedIndex = 0;
            cd_second.SelectedIndex = 0;
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
            //Port.ReceivedBytesThreshold = 500000;

            groupBox1.Enabled = groupBox4.Enabled = true; // Поля
        }
        catch (Exception e9)
        {
            MessageBox.Show(e9.Message, "Window_Loaded");
        }
    }
    private void Device01_FormClosed(object sender, FormClosedEventArgs e) // Событие закрытия формы 
    {
        Disconnect_Click_1(sender,e);
    }
    private void DataReceivedHandler(
                object sender,
                SerialDataReceivedEventArgs e) // Чтение с порта по событию
    {
        const byte size_p = 5; // Размер пачки     
        byte[] pack_ = new byte[size_p]; // Пачка
        byte n = 0; // Счётчик  
        byte r_byte; // Загруженный байт
        try
        {
            while (Port.BytesToRead > 0)
            {
                Thread.Sleep(0);
                r_byte = (byte)Port.ReadByte(); // Считывание с порта  

                if (r_byte == 0x0F) // 0000 1111 (начало измерение)
                {
                    mes.Clear();
                    continue;
                }
                if (r_byte == 0x07) // 0000 0111 (конец измерения)
                {
                    mes.save_id(id_d, id_p);
                    mes.save_disk(mes, Ak.get_Addres());
                    continue;
                }
                if ((r_byte & 0xC0) == 0x40) // первый байт пачки 01** **** & 1100 0000 = 0100 0000
                {
                    n = 0;
                    pack_[n] = r_byte;
                    continue;
                }
                if (((r_byte & 0x80) != 0)) // не первый байт пачки 1*** **** & 1000 0000 != 0000 0000
                {
                    n++;
                    if (n == size_p) // Всё плохо (0,1,2,3,4 - допустимые индексы в пачке)
                    {
                        status_Decoder = false;
                        break;
                    }
                    pack_[n] = r_byte;
                    package p = new package(pack_); // Кидаем пачку на разбор
                    Thread.Sleep(0);
                    if (p.IsI) // Решаем кто ток, кто напряжение
                    {
                        point_CV[1] = p.Int_pack; // Забираем с разбора значение
                        mes.save_dimension(point_CV[0], point_CV[1]); // Забираем точку в измерение
                    }
                    else
                    {
                        point_CV[0] = p.Int_pack; // Забираем с разбора значение
                    }
                    continue;
                }
            }
        }
        catch (Exception e3)
        {
            MessageBox.Show(e3.Message, "Ошибка чтения"); // Что-то пошлло не так
        }

    }
    private void Connect_Click_1(object sender, EventArgs e) // Подключение
    {
        Port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        // Отрытие порта
        for (Port.Open(); !Port.IsOpen; Thread.Sleep(1)) ; // Что бы открылся
        if (Port.IsOpen)
        {
              // Элементы управления(видимость/невидемость, отвечать/не отвечать)
              groupBox2.Enabled = true;
              groupBox4.Visible = true;
              Connect.Enabled = false;
              Disconnect.Enabled = true;
        }
        else
        {
              // Элементы управления(видимость/невидемость, отвечать/не отвечать)
              groupBox1.Enabled = true;
        }
        textBox1.Text = "200";
        textBox2.Clear();
    }
    private void Disconnect_Click_1(object sender, EventArgs e) // Выключение
    {
    timer1.Stop();
    // Завершение работы с портом
    status_Decoder = false; // Коректное завершение для потока
    // Зартытие порта
    Port.Close(); 
    if (!Port.IsOpen)
    {
        // Элементы управления(видимость/невидемость, отвечать/не отвечать)
        groupBox2.Enabled = false;
        Connect.Enabled = true;
        Disconnect.Enabled = false;
        groupBox4.Visible = false;
    }
    }
    private byte[] convert_A(byte A) // Перевод в массив
    {
        byte[] a = { A };
        return a;
    }
    private byte[] send(byte[] a) // Отправка
    {
      try
      {
          Port.Write(a, 0, a.Length);
      }
      catch (Exception e9)
      {
        MessageBox.Show("Port.Write" + e9.Message);
      }
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
            timer1.Stop();
        pressure_timer = !pressure_timer;
    }
    private void Send_Click(object sender, EventArgs e) // Отправка произвольного заданного значения
    {
        text_mesegbox(send(convert_A(Convert.ToByte(cb_first.Text+cd_second.Text, 16))));
    }
    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) // Выбор скорочти
    {
        if (comboBox2.Text != "")
            Port.BaudRate = Int32.Parse(comboBox2.Text);
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
