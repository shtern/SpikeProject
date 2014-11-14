﻿namespace SpikeProject
{
  partial class HeatPictureForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeatPictureForm));
      this.notStimSpikes = new System.Windows.Forms.PictureBox();
      this.NoStimPanel = new System.Windows.Forms.Panel();
      this.StimPanel = new System.Windows.Forms.Panel();
      this.StimSpikes = new System.Windows.Forms.PictureBox();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.экспортВBMPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.нормализацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.вклToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.выклToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.notStimSpikes)).BeginInit();
      this.NoStimPanel.SuspendLayout();
      this.StimPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.StimSpikes)).BeginInit();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // notStimSpikes
      // 
      this.notStimSpikes.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.notStimSpikes.Location = new System.Drawing.Point(0, 0);
      this.notStimSpikes.Name = "notStimSpikes";
      this.notStimSpikes.Size = new System.Drawing.Size(581, 241);
      this.notStimSpikes.TabIndex = 0;
      this.notStimSpikes.TabStop = false;
      this.notStimSpikes.Paint += new System.Windows.Forms.PaintEventHandler(this.notStimSpikes_Paint);
      // 
      // NoStimPanel
      // 
      this.NoStimPanel.AutoScroll = true;
      this.NoStimPanel.Controls.Add(this.notStimSpikes);
      this.NoStimPanel.Location = new System.Drawing.Point(12, 37);
      this.NoStimPanel.Name = "NoStimPanel";
      this.NoStimPanel.Size = new System.Drawing.Size(689, 330);
      this.NoStimPanel.TabIndex = 1;
      this.NoStimPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Panel_Scroll);
      // 
      // StimPanel
      // 
      this.StimPanel.AutoScroll = true;
      this.StimPanel.Controls.Add(this.StimSpikes);
      this.StimPanel.Location = new System.Drawing.Point(15, 395);
      this.StimPanel.Name = "StimPanel";
      this.StimPanel.Size = new System.Drawing.Size(689, 330);
      this.StimPanel.TabIndex = 3;
      // 
      // StimSpikes
      // 
      this.StimSpikes.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.StimSpikes.Location = new System.Drawing.Point(0, 0);
      this.StimSpikes.Name = "StimSpikes";
      this.StimSpikes.Size = new System.Drawing.Size(570, 242);
      this.StimSpikes.TabIndex = 0;
      this.StimSpikes.TabStop = false;
      this.StimSpikes.Paint += new System.Windows.Forms.PaintEventHandler(this.StimSpikes_Paint);
      // 
      // menuStrip1
      // 
      this.menuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.нормализацияToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(1135, 24);
      this.menuStrip1.TabIndex = 7;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // файлToolStripMenuItem
      // 
      this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.экспортВBMPToolStripMenuItem});
      this.файлToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
      this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
      this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
      this.файлToolStripMenuItem.Text = "Файл";
      // 
      // экспортВBMPToolStripMenuItem
      // 
      this.экспортВBMPToolStripMenuItem.Name = "экспортВBMPToolStripMenuItem";
      this.экспортВBMPToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
      this.экспортВBMPToolStripMenuItem.Text = "Экспорт в BMP";
      this.экспортВBMPToolStripMenuItem.Click += new System.EventHandler(this.экспортВBMPToolStripMenuItem_Click);
      // 
      // нормализацияToolStripMenuItem
      // 
      this.нормализацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вклToolStripMenuItem,
            this.выклToolStripMenuItem});
      this.нормализацияToolStripMenuItem.Name = "нормализацияToolStripMenuItem";
      this.нормализацияToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
      this.нормализацияToolStripMenuItem.Text = "Нормализация";
      // 
      // вклToolStripMenuItem
      // 
      this.вклToolStripMenuItem.CheckOnClick = true;
      this.вклToolStripMenuItem.Name = "вклToolStripMenuItem";
      this.вклToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.вклToolStripMenuItem.Text = "Вкл";
      this.вклToolStripMenuItem.Click += new System.EventHandler(this.вклToolStripMenuItem_Click);
      // 
      // выклToolStripMenuItem
      // 
      this.выклToolStripMenuItem.Checked = true;
      this.выклToolStripMenuItem.CheckOnClick = true;
      this.выклToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.выклToolStripMenuItem.Name = "выклToolStripMenuItem";
      this.выклToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.выклToolStripMenuItem.Text = "Выкл";
      this.выклToolStripMenuItem.Click += new System.EventHandler(this.выклToolStripMenuItem_Click);
      // 
      // HeatPictureForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1135, 807);
      this.Controls.Add(this.StimPanel);
      this.Controls.Add(this.NoStimPanel);
      this.Controls.Add(this.menuStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "HeatPictureForm";
      this.Text = "Карта спайковых характеристик";
      ((System.ComponentModel.ISupportInitialize)(this.notStimSpikes)).EndInit();
      this.NoStimPanel.ResumeLayout(false);
      this.StimPanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.StimSpikes)).EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox notStimSpikes;
    private System.Windows.Forms.Panel NoStimPanel;
    private System.Windows.Forms.Panel StimPanel;
    private System.Windows.Forms.PictureBox StimSpikes;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem экспортВBMPToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem нормализацияToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem вклToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem выклToolStripMenuItem;
  }
}