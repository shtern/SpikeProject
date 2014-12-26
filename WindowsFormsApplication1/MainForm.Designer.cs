namespace SpikeProject
{
  partial class MainForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.SpikeGraph = new System.Windows.Forms.PictureBox();
      this.NoStimCharacter = new System.Windows.Forms.PictureBox();
      this.TopScroll = new System.Windows.Forms.TrackBar();
      this.BottomScroll = new System.Windows.Forms.TrackBar();
      this.Threshold_Scroll = new System.Windows.Forms.TrackBar();
      this.StimCharacter = new System.Windows.Forms.PictureBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.cellName = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.numericAfterStim = new System.Windows.Forms.NumericUpDown();
      this.numericNoStim = new System.Windows.Forms.NumericUpDown();
      this.NoStimLabel = new System.Windows.Forms.Label();
      this.StimLabel = new System.Windows.Forms.Label();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.загрузитьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.загрузитьТеплокартуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.экспортВBMPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.построитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.сравнениеСреднихToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.тепловыеКартыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.AvgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.общиеНастройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.SpikeGraph)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.NoStimCharacter)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TopScroll)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BottomScroll)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.Threshold_Scroll)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.StimCharacter)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericAfterStim)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericNoStim)).BeginInit();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // SpikeGraph
      // 
      this.SpikeGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.SpikeGraph.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.SpikeGraph.Location = new System.Drawing.Point(10, 43);
      this.SpikeGraph.Name = "SpikeGraph";
      this.SpikeGraph.Size = new System.Drawing.Size(615, 194);
      this.SpikeGraph.TabIndex = 0;
      this.SpikeGraph.TabStop = false;
      this.SpikeGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.SpikeGraph_Paint);
      // 
      // NoStimCharacter
      // 
      this.NoStimCharacter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.NoStimCharacter.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.NoStimCharacter.Location = new System.Drawing.Point(10, 274);
      this.NoStimCharacter.Name = "NoStimCharacter";
      this.NoStimCharacter.Size = new System.Drawing.Size(1200, 320);
      this.NoStimCharacter.TabIndex = 7;
      this.NoStimCharacter.TabStop = false;
      this.NoStimCharacter.Paint += new System.Windows.Forms.PaintEventHandler(this.NoStimCharacter_Paint);
      // 
      // TopScroll
      // 
      this.TopScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.TopScroll.Location = new System.Drawing.Point(13, 36);
      this.TopScroll.Maximum = 50;
      this.TopScroll.Name = "TopScroll";
      this.TopScroll.Size = new System.Drawing.Size(160, 45);
      this.TopScroll.TabIndex = 8;
      this.TopScroll.TickStyle = System.Windows.Forms.TickStyle.None;
      this.TopScroll.Value = 18;
      this.TopScroll.Scroll += new System.EventHandler(this.TopScroll_Scroll);
      // 
      // BottomScroll
      // 
      this.BottomScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.BottomScroll.Location = new System.Drawing.Point(27, 35);
      this.BottomScroll.Maximum = 50;
      this.BottomScroll.Name = "BottomScroll";
      this.BottomScroll.Size = new System.Drawing.Size(200, 45);
      this.BottomScroll.TabIndex = 8;
      this.BottomScroll.TickStyle = System.Windows.Forms.TickStyle.None;
      this.BottomScroll.Value = 35;
      this.BottomScroll.Scroll += new System.EventHandler(this.BottomScroll_Scroll);
      // 
      // Threshold_Scroll
      // 
      this.Threshold_Scroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.Threshold_Scroll.AutoSize = false;
      this.Threshold_Scroll.Location = new System.Drawing.Point(13, 82);
      this.Threshold_Scroll.Maximum = 150;
      this.Threshold_Scroll.Name = "Threshold_Scroll";
      this.Threshold_Scroll.Size = new System.Drawing.Size(160, 24);
      this.Threshold_Scroll.TabIndex = 9;
      this.Threshold_Scroll.TickStyle = System.Windows.Forms.TickStyle.None;
      this.Threshold_Scroll.Value = 20;
      this.Threshold_Scroll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Threshold_Scroll_MouseUp);
      // 
      // StimCharacter
      // 
      this.StimCharacter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.StimCharacter.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.StimCharacter.Location = new System.Drawing.Point(10, 637);
      this.StimCharacter.Name = "StimCharacter";
      this.StimCharacter.Size = new System.Drawing.Size(1200, 320);
      this.StimCharacter.TabIndex = 10;
      this.StimCharacter.TabStop = false;
      this.StimCharacter.Paint += new System.Windows.Forms.PaintEventHandler(this.StimCharacter_Paint);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(179, 39);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(53, 13);
      this.label4.TabIndex = 9;
      this.label4.Text = "Масштаб";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(179, 85);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(38, 13);
      this.label8.TabIndex = 12;
      this.label8.Text = "Порог";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(50, 89);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(202, 13);
      this.label7.TabIndex = 11;
      this.label7.Text = "Количество спайковых характеристик";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(233, 37);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(53, 13);
      this.label6.TabIndex = 10;
      this.label6.Text = "Масштаб";
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.cellName);
      this.groupBox1.Controls.Add(this.label8);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.TopScroll);
      this.groupBox1.Controls.Add(this.Threshold_Scroll);
      this.groupBox1.Location = new System.Drawing.Point(644, 45);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(254, 192);
      this.groupBox1.TabIndex = 13;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Общий график";
      // 
      // cellName
      // 
      this.cellName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cellName.AutoSize = true;
      this.cellName.Location = new System.Drawing.Point(68, 138);
      this.cellName.Name = "cellName";
      this.cellName.Size = new System.Drawing.Size(105, 13);
      this.cellName.TabIndex = 20;
      this.cellName.Text = "Клетка не выбрана";
      // 
      // groupBox2
      // 
      this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox2.Controls.Add(this.label5);
      this.groupBox2.Controls.Add(this.label2);
      this.groupBox2.Controls.Add(this.numericAfterStim);
      this.groupBox2.Controls.Add(this.numericNoStim);
      this.groupBox2.Controls.Add(this.label7);
      this.groupBox2.Controls.Add(this.BottomScroll);
      this.groupBox2.Controls.Add(this.label6);
      this.groupBox2.Location = new System.Drawing.Point(918, 45);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(292, 192);
      this.groupBox2.TabIndex = 14;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Графики спайковых характеристик";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(184, 114);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(102, 13);
      this.label5.TabIndex = 18;
      this.label5.Text = "После стимуляции";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(17, 114);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(85, 13);
      this.label2.TabIndex = 17;
      this.label2.Text = "До стимуляции";
      // 
      // numericAfterStim
      // 
      this.numericAfterStim.Location = new System.Drawing.Point(202, 139);
      this.numericAfterStim.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
      this.numericAfterStim.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numericAfterStim.Name = "numericAfterStim";
      this.numericAfterStim.Size = new System.Drawing.Size(50, 20);
      this.numericAfterStim.TabIndex = 16;
      this.numericAfterStim.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
      this.numericAfterStim.ValueChanged += new System.EventHandler(this.numericAfterStim_ValueChanged);
      // 
      // numericNoStim
      // 
      this.numericNoStim.Location = new System.Drawing.Point(33, 139);
      this.numericNoStim.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
      this.numericNoStim.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numericNoStim.Name = "numericNoStim";
      this.numericNoStim.Size = new System.Drawing.Size(50, 20);
      this.numericNoStim.TabIndex = 15;
      this.numericNoStim.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
      this.numericNoStim.ValueChanged += new System.EventHandler(this.numericNo_ValueChanged);
      // 
      // NoStimLabel
      // 
      this.NoStimLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.NoStimLabel.AutoSize = true;
      this.NoStimLabel.Location = new System.Drawing.Point(13, 250);
      this.NoStimLabel.Name = "NoStimLabel";
      this.NoStimLabel.Size = new System.Drawing.Size(85, 13);
      this.NoStimLabel.TabIndex = 17;
      this.NoStimLabel.Text = "До стимуляции";
      // 
      // StimLabel
      // 
      this.StimLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.StimLabel.AutoSize = true;
      this.StimLabel.Location = new System.Drawing.Point(13, 617);
      this.StimLabel.Name = "StimLabel";
      this.StimLabel.Size = new System.Drawing.Size(118, 13);
      this.StimLabel.TabIndex = 18;
      this.StimLabel.Text = "Во время стимуляции";
      // 
      // menuStrip1
      // 
      this.menuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.построитьToolStripMenuItem,
            this.настройкиToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(1220, 24);
      this.menuStrip1.TabIndex = 21;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // файлToolStripMenuItem
      // 
      this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьДанныеToolStripMenuItem,
            this.загрузитьТеплокартуToolStripMenuItem,
            this.экспортВBMPToolStripMenuItem});
      this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
      this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
      this.файлToolStripMenuItem.Text = "Файл";
      // 
      // загрузитьДанныеToolStripMenuItem
      // 
      this.загрузитьДанныеToolStripMenuItem.Name = "загрузитьДанныеToolStripMenuItem";
      this.загрузитьДанныеToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
      this.загрузитьДанныеToolStripMenuItem.Text = "Загрузить данные";
      this.загрузитьДанныеToolStripMenuItem.Click += new System.EventHandler(this.загрузитьДанныеToolStripMenuItem_Click);
      // 
      // загрузитьТеплокартуToolStripMenuItem
      // 
      this.загрузитьТеплокартуToolStripMenuItem.Name = "загрузитьТеплокартуToolStripMenuItem";
      this.загрузитьТеплокартуToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
      this.загрузитьТеплокартуToolStripMenuItem.Text = "Загрузить теплокарту";
      this.загрузитьТеплокартуToolStripMenuItem.Click += new System.EventHandler(this.загрузитьТеплокартуToolStripMenuItem_Click);
      // 
      // экспортВBMPToolStripMenuItem
      // 
      this.экспортВBMPToolStripMenuItem.Name = "экспортВBMPToolStripMenuItem";
      this.экспортВBMPToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
      this.экспортВBMPToolStripMenuItem.Text = "Экспорт в BMP";
      this.экспортВBMPToolStripMenuItem.Click += new System.EventHandler(this.экспортВBMPToolStripMenuItem_Click);
      // 
      // построитьToolStripMenuItem
      // 
      this.построитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сравнениеСреднихToolStripMenuItem,
            this.тепловыеКартыToolStripMenuItem});
      this.построитьToolStripMenuItem.Name = "построитьToolStripMenuItem";
      this.построитьToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
      this.построитьToolStripMenuItem.Text = "Построить";
      // 
      // сравнениеСреднихToolStripMenuItem
      // 
      this.сравнениеСреднихToolStripMenuItem.Name = "сравнениеСреднихToolStripMenuItem";
      this.сравнениеСреднихToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
      this.сравнениеСреднихToolStripMenuItem.Text = "Сравнение средних";
      this.сравнениеСреднихToolStripMenuItem.Click += new System.EventHandler(this.сравнениеСреднихToolStripMenuItem_Click);
      // 
      // тепловыеКартыToolStripMenuItem
      // 
      this.тепловыеКартыToolStripMenuItem.Name = "тепловыеКартыToolStripMenuItem";
      this.тепловыеКартыToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
      this.тепловыеКартыToolStripMenuItem.Text = "Тепловые карты";
      this.тепловыеКартыToolStripMenuItem.Click += new System.EventHandler(this.тепловыеКартыToolStripMenuItem_Click);
      // 
      // настройкиToolStripMenuItem
      // 
      this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AvgToolStripMenuItem,
            this.openDirToolStripMenuItem,
            this.общиеНастройкиToolStripMenuItem});
      this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
      this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
      this.настройкиToolStripMenuItem.Text = "Настройки";
      // 
      // AvgToolStripMenuItem
      // 
      this.AvgToolStripMenuItem.Checked = true;
      this.AvgToolStripMenuItem.CheckOnClick = true;
      this.AvgToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.AvgToolStripMenuItem.Name = "AvgToolStripMenuItem";
      this.AvgToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
      this.AvgToolStripMenuItem.Text = "Рисовать средние";
      this.AvgToolStripMenuItem.CheckedChanged += new System.EventHandler(this.AvgToolStripMenuItem_CheckedChanged);
      // 
      // openDirToolStripMenuItem
      // 
      this.openDirToolStripMenuItem.Checked = true;
      this.openDirToolStripMenuItem.CheckOnClick = true;
      this.openDirToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.openDirToolStripMenuItem.Name = "openDirToolStripMenuItem";
      this.openDirToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
      this.openDirToolStripMenuItem.Text = "Открывать окно при сохранении";
      // 
      // общиеНастройкиToolStripMenuItem
      // 
      this.общиеНастройкиToolStripMenuItem.Name = "общиеНастройкиToolStripMenuItem";
      this.общиеНастройкиToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
      this.общиеНастройкиToolStripMenuItem.Text = "Общие настройки";
      this.общиеНастройкиToolStripMenuItem.Click += new System.EventHandler(this.общиеНастройкиToolStripMenuItem_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1220, 972);
      this.Controls.Add(this.StimLabel);
      this.Controls.Add(this.NoStimLabel);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.StimCharacter);
      this.Controls.Add(this.NoStimCharacter);
      this.Controls.Add(this.SpikeGraph);
      this.Controls.Add(this.menuStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip1;
      this.MinimumSize = new System.Drawing.Size(1236, 1010);
      this.Name = "MainForm";
      this.Text = "Анализ спайковых характеристик";
      this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.SpikeGraph)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.NoStimCharacter)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TopScroll)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BottomScroll)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.Threshold_Scroll)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.StimCharacter)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericAfterStim)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericNoStim)).EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox SpikeGraph;
    private System.Windows.Forms.PictureBox NoStimCharacter;
    private System.Windows.Forms.TrackBar TopScroll;
    private System.Windows.Forms.TrackBar BottomScroll;
    private System.Windows.Forms.TrackBar Threshold_Scroll;
    private System.Windows.Forms.PictureBox StimCharacter;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.NumericUpDown numericNoStim;
    private System.Windows.Forms.NumericUpDown numericAfterStim;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label NoStimLabel;
    private System.Windows.Forms.Label StimLabel;
    public System.Windows.Forms.Label cellName;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem загрузитьДанныеToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem экспортВBMPToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem построитьToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem сравнениеСреднихToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem тепловыеКартыToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem AvgToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openDirToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem загрузитьТеплокартуToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem общиеНастройкиToolStripMenuItem;
  }
}

