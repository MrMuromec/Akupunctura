namespace Akupunctura.Logik.Forms.Device
{
  partial class Device_01
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.Disconnect = new System.Windows.Forms.Button();
      this.Connect = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.comboBox4 = new System.Windows.Forms.ComboBox();
      this.comboBox3 = new System.Windows.Forms.ComboBox();
      this.comboBox2 = new System.Windows.Forms.ComboBox();
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.cb_first = new System.Windows.Forms.ComboBox();
      this.cd_second = new System.Windows.Forms.ComboBox();
      this.Send = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.Disconnect);
      this.groupBox1.Controls.Add(this.Connect);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.comboBox4);
      this.groupBox1.Controls.Add(this.comboBox3);
      this.groupBox1.Controls.Add(this.comboBox2);
      this.groupBox1.Controls.Add(this.comboBox1);
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(288, 196);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Настройки соединения";
      // 
      // Disconnect
      // 
      this.Disconnect.Location = new System.Drawing.Point(9, 159);
      this.Disconnect.Name = "Disconnect";
      this.Disconnect.Size = new System.Drawing.Size(267, 29);
      this.Disconnect.TabIndex = 10;
      this.Disconnect.Text = "Отключить";
      this.Disconnect.UseVisualStyleBackColor = true;
      this.Disconnect.Click += new System.EventHandler(this.Disconnect_Click);
      // 
      // Connect
      // 
      this.Connect.Location = new System.Drawing.Point(9, 127);
      this.Connect.Name = "Connect";
      this.Connect.Size = new System.Drawing.Size(267, 26);
      this.Connect.TabIndex = 9;
      this.Connect.Text = "Подключить";
      this.Connect.UseVisualStyleBackColor = true;
      this.Connect.Click += new System.EventHandler(this.Connect_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(6, 103);
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
      this.label1.Location = new System.Drawing.Point(6, 22);
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
            "1",
            "2"});
      this.comboBox4.Location = new System.Drawing.Point(109, 100);
      this.comboBox4.Name = "comboBox4";
      this.comboBox4.Size = new System.Drawing.Size(167, 21);
      this.comboBox4.TabIndex = 3;
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
      // 
      // comboBox1
      // 
      this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new System.Drawing.Point(109, 19);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(167, 21);
      this.comboBox1.TabIndex = 0;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.Send);
      this.groupBox2.Controls.Add(this.cd_second);
      this.groupBox2.Controls.Add(this.cb_first);
      this.groupBox2.Location = new System.Drawing.Point(12, 214);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(288, 88);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Посылка";
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
      this.cb_first.Location = new System.Drawing.Point(6, 19);
      this.cb_first.Name = "cb_first";
      this.cb_first.Size = new System.Drawing.Size(41, 21);
      this.cb_first.TabIndex = 0;
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
      this.cd_second.Location = new System.Drawing.Point(53, 19);
      this.cd_second.Name = "cd_second";
      this.cd_second.Size = new System.Drawing.Size(42, 21);
      this.cd_second.TabIndex = 1;
      // 
      // Send
      // 
      this.Send.Location = new System.Drawing.Point(109, 19);
      this.Send.Name = "Send";
      this.Send.Size = new System.Drawing.Size(167, 21);
      this.Send.TabIndex = 2;
      this.Send.Text = "Отправить";
      this.Send.UseVisualStyleBackColor = true;
      // 
      // Device_01
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(660, 476);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Name = "Device_01";
      this.Text = "Device_01";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
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
    private System.Windows.Forms.Button Connect;
    private System.Windows.Forms.Button Disconnect;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.ComboBox cd_second;
    private System.Windows.Forms.ComboBox cb_first;
    private System.Windows.Forms.Button Send;
  }
}