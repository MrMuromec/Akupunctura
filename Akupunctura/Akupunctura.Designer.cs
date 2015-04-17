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
      this.работаСПриборомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.менюРаботыПрибораToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.MainMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // MainMenu
      // 
      this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.работаСПриборомToolStripMenuItem});
      this.MainMenu.Location = new System.Drawing.Point(0, 0);
      this.MainMenu.Name = "MainMenu";
      this.MainMenu.Size = new System.Drawing.Size(874, 24);
      this.MainMenu.TabIndex = 0;
      this.MainMenu.Text = "MainMenu";
      // 
      // работаСПриборомToolStripMenuItem
      // 
      this.работаСПриборомToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюРаботыПрибораToolStripMenuItem});
      this.работаСПриборомToolStripMenuItem.Name = "работаСПриборомToolStripMenuItem";
      this.работаСПриборомToolStripMenuItem.Size = new System.Drawing.Size(127, 20);
      this.работаСПриборомToolStripMenuItem.Text = "Работа с прибором";
      // 
      // менюРаботыПрибораToolStripMenuItem
      // 
      this.менюРаботыПрибораToolStripMenuItem.Name = "менюРаботыПрибораToolStripMenuItem";
      this.менюРаботыПрибораToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
      this.менюРаботыПрибораToolStripMenuItem.Text = "Меню работы прибора";
      this.менюРаботыПрибораToolStripMenuItem.Click += new System.EventHandler(this.МенюРаботыПрибораToolStripMenuItem_Click);
      // 
      // Akupunctura
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(874, 476);
      this.Controls.Add(this.MainMenu);
      this.IsMdiContainer = true;
      this.MainMenuStrip = this.MainMenu;
      this.Name = "Akupunctura";
      this.Text = "Akupunctura";
      this.MainMenu.ResumeLayout(false);
      this.MainMenu.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip MainMenu;
    private System.Windows.Forms.ToolStripMenuItem работаСПриборомToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem менюРаботыПрибораToolStripMenuItem;
  }
}

