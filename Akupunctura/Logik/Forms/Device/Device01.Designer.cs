﻿namespace Akupunctura.Logik.Forms.Device
{
  partial class Device01
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.comboBox4 = new System.Windows.Forms.ComboBox();
      this.comboBox3 = new System.Windows.Forms.ComboBox();
      this.comboBox2 = new System.Windows.Forms.ComboBox();
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.Disconnect = new System.Windows.Forms.Button();
      this.Connect = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.button4 = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.Send = new System.Windows.Forms.Button();
      this.cd_second = new System.Windows.Forms.ComboBox();
      this.cb_first = new System.Windows.Forms.ComboBox();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.comboBox4);
      this.groupBox1.Controls.Add(this.comboBox3);
      this.groupBox1.Controls.Add(this.comboBox2);
      this.groupBox1.Controls.Add(this.comboBox1);
      this.groupBox1.Enabled = false;
      this.groupBox1.Location = new System.Drawing.Point(2, 234);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(288, 132);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Настройки соединения";
      this.groupBox1.Visible = false;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(6, 102);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(63, 13);
      this.label4.TabIndex = 8;
      this.label4.Text = "Стоп-битов";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 76);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(49, 13);
      this.label3.TabIndex = 7;
      this.label3.Text = "Паритет";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 49);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(55, 13);
      this.label2.TabIndex = 6;
      this.label2.Text = "Скорость";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 21);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(77, 13);
      this.label1.TabIndex = 5;
      this.label1.Text = "№ COM порта";
      // 
      // comboBox4
      // 
      this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBox4.FormattingEnabled = true;
      this.comboBox4.Items.AddRange(new object[] {
            "1.0",
            "1.5",
            "2.0"});
      this.comboBox4.Location = new System.Drawing.Point(109, 100);
      this.comboBox4.Name = "comboBox4";
      this.comboBox4.Size = new System.Drawing.Size(167, 21);
      this.comboBox4.TabIndex = 3;
      this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
      // 
      // comboBox3
      // 
      this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBox3.FormattingEnabled = true;
      this.comboBox3.Items.AddRange(new object[] {
            "нет- 00",
            "четный",
            "нечетный",
            "нет-11"});
      this.comboBox3.Location = new System.Drawing.Point(109, 73);
      this.comboBox3.Name = "comboBox3";
      this.comboBox3.Size = new System.Drawing.Size(167, 21);
      this.comboBox3.TabIndex = 2;
      this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
      // 
      // comboBox2
      // 
      this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBox2.FormattingEnabled = true;
      this.comboBox2.Items.AddRange(new object[] {
            "    2400",
            "    4800",
            "    9600",
            "  19200",
            "  38400",
            "  57600",
            "115200",
            "128000",
            "256000",
            "921600"});
      this.comboBox2.Location = new System.Drawing.Point(109, 46);
      this.comboBox2.Name = "comboBox2";
      this.comboBox2.Size = new System.Drawing.Size(167, 21);
      this.comboBox2.Sorted = true;
      this.comboBox2.TabIndex = 1;
      this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
      // 
      // comboBox1
      // 
      this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new System.Drawing.Point(109, 19);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(167, 21);
      this.comboBox1.TabIndex = 0;
      this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
      // 
      // Disconnect
      // 
      this.Disconnect.Enabled = false;
      this.Disconnect.Location = new System.Drawing.Point(2, 202);
      this.Disconnect.Name = "Disconnect";
      this.Disconnect.Size = new System.Drawing.Size(288, 26);
      this.Disconnect.TabIndex = 12;
      this.Disconnect.Text = "Отключить";
      this.Disconnect.UseVisualStyleBackColor = true;
      this.Disconnect.Click += new System.EventHandler(this.Disconnect_Click_1);
      // 
      // Connect
      // 
      this.Connect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Connect.Location = new System.Drawing.Point(2, 169);
      this.Connect.Name = "Connect";
      this.Connect.Size = new System.Drawing.Size(288, 26);
      this.Connect.TabIndex = 11;
      this.Connect.Text = "Подключить";
      this.Connect.UseVisualStyleBackColor = true;
      this.Connect.Click += new System.EventHandler(this.Connect_Click_1);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.textBox1);
      this.groupBox2.Controls.Add(this.button4);
      this.groupBox2.Controls.Add(this.button3);
      this.groupBox2.Controls.Add(this.button2);
      this.groupBox2.Controls.Add(this.button1);
      this.groupBox2.Controls.Add(this.Send);
      this.groupBox2.Controls.Add(this.cd_second);
      this.groupBox2.Controls.Add(this.cb_first);
      this.groupBox2.Enabled = false;
      this.groupBox2.Location = new System.Drawing.Point(2, 2);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(288, 78);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Посылка";
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(231, 47);
      this.textBox1.Margin = new System.Windows.Forms.Padding(2);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(44, 20);
      this.textBox1.TabIndex = 7;
      // 
      // button4
      // 
      this.button4.Location = new System.Drawing.Point(134, 46);
      this.button4.Margin = new System.Windows.Forms.Padding(2);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(92, 21);
      this.button4.TabIndex = 6;
      this.button4.Text = "Отправить 001";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new System.EventHandler(this.button4_Click);
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(92, 46);
      this.button3.Margin = new System.Windows.Forms.Padding(2);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(38, 21);
      this.button3.TabIndex = 5;
      this.button3.Text = "255";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(50, 46);
      this.button2.Margin = new System.Windows.Forms.Padding(2);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(38, 21);
      this.button2.TabIndex = 4;
      this.button2.Text = "001";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(8, 46);
      this.button1.Margin = new System.Windows.Forms.Padding(2);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(38, 21);
      this.button1.TabIndex = 3;
      this.button1.Text = "000";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // Send
      // 
      this.Send.Location = new System.Drawing.Point(94, 19);
      this.Send.Name = "Send";
      this.Send.Size = new System.Drawing.Size(181, 21);
      this.Send.TabIndex = 2;
      this.Send.Text = "Отправить";
      this.Send.UseVisualStyleBackColor = true;
      this.Send.Click += new System.EventHandler(this.Send_Click);
      // 
      // cd_second
      // 
      this.cd_second.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cd_second.FormattingEnabled = true;
      this.cd_second.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F"});
      this.cd_second.Location = new System.Drawing.Point(50, 20);
      this.cd_second.Name = "cd_second";
      this.cd_second.Size = new System.Drawing.Size(38, 21);
      this.cd_second.TabIndex = 1;
      // 
      // cb_first
      // 
      this.cb_first.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cb_first.FormattingEnabled = true;
      this.cb_first.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F"});
      this.cb_first.Location = new System.Drawing.Point(8, 20);
      this.cb_first.Name = "cb_first";
      this.cb_first.Size = new System.Drawing.Size(38, 21);
      this.cb_first.TabIndex = 0;
      // 
      // groupBox4
      // 
      this.groupBox4.Controls.Add(this.textBox2);
      this.groupBox4.Enabled = false;
      this.groupBox4.Location = new System.Drawing.Point(2, 85);
      this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
      this.groupBox4.Size = new System.Drawing.Size(288, 78);
      this.groupBox4.TabIndex = 3;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Отпрака";
      this.groupBox4.Visible = false;
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(10, 21);
      this.textBox2.Margin = new System.Windows.Forms.Padding(2);
      this.textBox2.Multiline = true;
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(266, 45);
      this.textBox2.TabIndex = 0;
      // 
      // timer1
      // 
      this.timer1.Interval = 2;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // Device01
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(300, 373);
      this.Controls.Add(this.Disconnect);
      this.Controls.Add(this.groupBox4);
      this.Controls.Add(this.Connect);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Name = "Device01";
      this.Text = "Device_01";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Device01_FormClosed);
      this.Load += new System.EventHandler(this.Device01_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.ComboBox comboBox4;
    private System.Windows.Forms.ComboBox comboBox3;
    private System.Windows.Forms.ComboBox comboBox2;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.ComboBox cd_second;
    private System.Windows.Forms.ComboBox cb_first;
    private System.Windows.Forms.Button Send;
    private System.Windows.Forms.Button Connect;
    private System.Windows.Forms.Button Disconnect;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.Timer timer1;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
  }
}