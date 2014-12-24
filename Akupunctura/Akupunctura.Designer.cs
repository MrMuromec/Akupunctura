namespace Akupunctura
{
  partial class Akupunctura
  {
    /// <summary>
    /// Требуется переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Обязательный метод для поддержки конструктора - не изменяйте
    /// содержимое данного метода при помощи редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.списокКомандToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.измеренияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выборБазыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.работаСПриборомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.менюРаботыПрибораToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.операцииСВрачамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.авторизацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокКомандToolStripMenuItem,
            this.работаСПриборомToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.MainMenu.Size = new System.Drawing.Size(1165, 28);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "MainMenu";
            // 
            // списокКомандToolStripMenuItem
            // 
            this.списокКомандToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.измеренияToolStripMenuItem,
            this.операцииСВрачамиToolStripMenuItem});
            this.списокКомандToolStripMenuItem.Name = "списокКомандToolStripMenuItem";
            this.списокКомандToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.списокКомандToolStripMenuItem.Text = "Список команд";
            // 
            // измеренияToolStripMenuItem
            // 
            this.измеренияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выборБазыToolStripMenuItem});
            this.измеренияToolStripMenuItem.Name = "измеренияToolStripMenuItem";
            this.измеренияToolStripMenuItem.Size = new System.Drawing.Size(226, 24);
            this.измеренияToolStripMenuItem.Text = "Операции с базой";
            // 
            // выборБазыToolStripMenuItem
            // 
            this.выборБазыToolStripMenuItem.Name = "выборБазыToolStripMenuItem";
            this.выборБазыToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.выборБазыToolStripMenuItem.Text = "Выбор базы";
            this.выборБазыToolStripMenuItem.Click += new System.EventHandler(this.выборБазыToolStripMenuItem_Click);
            // 
            // работаСПриборомToolStripMenuItem
            // 
            this.работаСПриборомToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюРаботыПрибораToolStripMenuItem});
            this.работаСПриборомToolStripMenuItem.Name = "работаСПриборомToolStripMenuItem";
            this.работаСПриборомToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.работаСПриборомToolStripMenuItem.Text = "Работа с прибором";
            // 
            // менюРаботыПрибораToolStripMenuItem
            // 
            this.менюРаботыПрибораToolStripMenuItem.Name = "менюРаботыПрибораToolStripMenuItem";
            this.менюРаботыПрибораToolStripMenuItem.Size = new System.Drawing.Size(242, 24);
            this.менюРаботыПрибораToolStripMenuItem.Text = "Меню работы прибора";
            this.менюРаботыПрибораToolStripMenuItem.Click += new System.EventHandler(this.МенюРаботыПрибораToolStripMenuItem_Click);
            // 
            // операцииСВрачамиToolStripMenuItem
            // 
            this.операцииСВрачамиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.авторизацияToolStripMenuItem});
            this.операцииСВрачамиToolStripMenuItem.Name = "операцииСВрачамиToolStripMenuItem";
            this.операцииСВрачамиToolStripMenuItem.Size = new System.Drawing.Size(226, 24);
            this.операцииСВрачамиToolStripMenuItem.Text = "Операции с врачами";
            // 
            // авторизацияToolStripMenuItem
            // 
            this.авторизацияToolStripMenuItem.Name = "авторизацияToolStripMenuItem";
            this.авторизацияToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.авторизацияToolStripMenuItem.Text = "Авторизация";
            this.авторизацияToolStripMenuItem.Click += new System.EventHandler(this.авторизацияToolStripMenuItem_Click);
            // 
            // Akupunctura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 586);
            this.Controls.Add(this.MainMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Akupunctura";
            this.Text = "Akupunctura";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip MainMenu;
    private System.Windows.Forms.ToolStripMenuItem списокКомандToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem измеренияToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem выборБазыToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem работаСПриборомToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem менюРаботыПрибораToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem операцииСВрачамиToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem авторизацияToolStripMenuItem;
  }
}

