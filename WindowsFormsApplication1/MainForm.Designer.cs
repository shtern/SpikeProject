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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.SpikeGraph = new System.Windows.Forms.PictureBox();
      this.NoStimCharacter = new System.Windows.Forms.PictureBox();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.savaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.TopScroll = new System.Windows.Forms.TrackBar();
      this.Threshold_Scroll = new System.Windows.Forms.TrackBar();
      this.StimCharacter = new System.Windows.Forms.PictureBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.cellName = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.numericAfterStim = new System.Windows.Forms.NumericUpDown();
      this.numericNoStim = new System.Windows.Forms.NumericUpDown();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.загрузитьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.загрузитьТеплокартуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.экспортВBMPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.убратьХарактеристикуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.построитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.сравнениеСреднихToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.тепловыеКартыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.матрицуКорToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.AvgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.общиеНастройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.NoStimZedGraph = new ZedGraph.ZedGraphControl();
      this.StimZedGraph = new ZedGraph.ZedGraphControl();
      this.CommonZedGraph = new ZedGraph.ZedGraphControl();
      ((System.ComponentModel.ISupportInitialize)(this.SpikeGraph)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.NoStimCharacter)).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TopScroll)).BeginInit();
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
      this.NoStimCharacter.ContextMenuStrip = this.contextMenuStrip1;
      this.NoStimCharacter.Location = new System.Drawing.Point(1143, 274);
      this.NoStimCharacter.Name = "NoStimCharacter";
      this.NoStimCharacter.Size = new System.Drawing.Size(67, 320);
      this.NoStimCharacter.TabIndex = 7;
      this.NoStimCharacter.TabStop = false;
      this.NoStimCharacter.Visible = false;
      this.NoStimCharacter.Paint += new System.Windows.Forms.PaintEventHandler(this.NoStimCharacter_Paint);
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savaToolStripMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(140, 26);
      // 
      // savaToolStripMenuItem
      // 
      this.savaToolStripMenuItem.Name = "savaToolStripMenuItem";
      this.savaToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
      this.savaToolStripMenuItem.Text = "save as bmp";
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
      // Threshold_Scroll
      // 
      this.Threshold_Scroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.Threshold_Scroll.AutoSize = false;
      this.Threshold_Scroll.Location = new System.Drawing.Point(27, 160);
      this.Threshold_Scroll.Maximum = 500;
      this.Threshold_Scroll.Minimum = 1;
      this.Threshold_Scroll.Name = "Threshold_Scroll";
      this.Threshold_Scroll.Size = new System.Drawing.Size(160, 24);
      this.Threshold_Scroll.TabIndex = 9;
      this.Threshold_Scroll.TickStyle = System.Windows.Forms.TickStyle.None;
      this.Threshold_Scroll.Value = 100;
      this.Threshold_Scroll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Threshold_Scroll_MouseUp);
      // 
      // StimCharacter
      // 
      this.StimCharacter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.StimCharacter.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.StimCharacter.Location = new System.Drawing.Point(1143, 637);
      this.StimCharacter.Name = "StimCharacter";
      this.StimCharacter.Size = new System.Drawing.Size(67, 320);
      this.StimCharacter.TabIndex = 10;
      this.StimCharacter.TabStop = false;
      this.StimCharacter.Visible = false;
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
      this.label8.Location = new System.Drawing.Point(222, 162);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(38, 13);
      this.label8.TabIndex = 12;
      this.label8.Text = "Порог";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(50, 68);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(202, 13);
      this.label7.TabIndex = 11;
      this.label7.Text = "Количество спайковых характеристик";
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.TopScroll);
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
      this.cellName.Location = new System.Drawing.Point(24, 27);
      this.cellName.Name = "cellName";
      this.cellName.Size = new System.Drawing.Size(105, 13);
      this.cellName.TabIndex = 20;
      this.cellName.Text = "Клетка не выбрана";
      // 
      // groupBox2
      // 
      this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox2.Controls.Add(this.cellName);
      this.groupBox2.Controls.Add(this.label5);
      this.groupBox2.Controls.Add(this.label8);
      this.groupBox2.Controls.Add(this.label2);
      this.groupBox2.Controls.Add(this.numericAfterStim);
      this.groupBox2.Controls.Add(this.numericNoStim);
      this.groupBox2.Controls.Add(this.Threshold_Scroll);
      this.groupBox2.Controls.Add(this.label7);
      this.groupBox2.Location = new System.Drawing.Point(918, 45);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(292, 218);
      this.groupBox2.TabIndex = 14;
      this.groupBox2.TabStop = false;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(184, 90);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(102, 13);
      this.label5.TabIndex = 18;
      this.label5.Text = "После стимуляции";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(17, 90);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(85, 13);
      this.label2.TabIndex = 17;
      this.label2.Text = "До стимуляции";
      // 
      // numericAfterStim
      // 
      this.numericAfterStim.Location = new System.Drawing.Point(202, 115);
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
      this.numericNoStim.Location = new System.Drawing.Point(33, 115);
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
      // menuStrip1
      // 
      this.menuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.правкаToolStripMenuItem,
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
      // правкаToolStripMenuItem
      // 
      this.правкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.убратьХарактеристикуToolStripMenuItem});
      this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
      this.правкаToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
      this.правкаToolStripMenuItem.Text = "Правка";
      // 
      // убратьХарактеристикуToolStripMenuItem
      // 
      this.убратьХарактеристикуToolStripMenuItem.Name = "убратьХарактеристикуToolStripMenuItem";
      this.убратьХарактеристикуToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
      this.убратьХарактеристикуToolStripMenuItem.Text = "Убрать характеристику";
      this.убратьХарактеристикуToolStripMenuItem.Click += new System.EventHandler(this.убратьХарактеристикуToolStripMenuItem_Click);
      // 
      // построитьToolStripMenuItem
      // 
      this.построитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сравнениеСреднихToolStripMenuItem,
            this.тепловыеКартыToolStripMenuItem,
            this.матрицуКорToolStripMenuItem});
      this.построитьToolStripMenuItem.Name = "построитьToolStripMenuItem";
      this.построитьToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
      this.построитьToolStripMenuItem.Text = "Построить";
      // 
      // сравнениеСреднихToolStripMenuItem
      // 
      this.сравнениеСреднихToolStripMenuItem.Name = "сравнениеСреднихToolStripMenuItem";
      this.сравнениеСреднихToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
      this.сравнениеСреднихToolStripMenuItem.Text = "Сравнение средних";
      this.сравнениеСреднихToolStripMenuItem.Click += new System.EventHandler(this.сравнениеСреднихToolStripMenuItem_Click);
      // 
      // тепловыеКартыToolStripMenuItem
      // 
      this.тепловыеКартыToolStripMenuItem.Name = "тепловыеКартыToolStripMenuItem";
      this.тепловыеКартыToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
      this.тепловыеКартыToolStripMenuItem.Text = "Тепловые карты";
      this.тепловыеКартыToolStripMenuItem.Click += new System.EventHandler(this.тепловыеКартыToolStripMenuItem_Click);
      // 
      // матрицуКорToolStripMenuItem
      // 
      this.матрицуКорToolStripMenuItem.Name = "матрицуКорToolStripMenuItem";
      this.матрицуКорToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
      this.матрицуКорToolStripMenuItem.Text = "Матрицу корреляции";
      this.матрицуКорToolStripMenuItem.Click += new System.EventHandler(this.матрицуКорToolStripMenuItem_Click);
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
      // NoStimZedGraph
      // 
      this.NoStimZedGraph.Location = new System.Drawing.Point(10, 311);
      this.NoStimZedGraph.Name = "NoStimZedGraph";
      this.NoStimZedGraph.ScrollGrace = 0D;
      this.NoStimZedGraph.ScrollMaxX = 0D;
      this.NoStimZedGraph.ScrollMaxY = 0D;
      this.NoStimZedGraph.ScrollMaxY2 = 0D;
      this.NoStimZedGraph.ScrollMinX = 0D;
      this.NoStimZedGraph.ScrollMinY = 0D;
      this.NoStimZedGraph.ScrollMinY2 = 0D;
      this.NoStimZedGraph.Size = new System.Drawing.Size(1200, 320);
      this.NoStimZedGraph.TabIndex = 22;
      // 
      // StimZedGraph
      // 
      this.StimZedGraph.Location = new System.Drawing.Point(16, 645);
      this.StimZedGraph.Name = "StimZedGraph";
      this.StimZedGraph.ScrollGrace = 0D;
      this.StimZedGraph.ScrollMaxX = 0D;
      this.StimZedGraph.ScrollMaxY = 0D;
      this.StimZedGraph.ScrollMaxY2 = 0D;
      this.StimZedGraph.ScrollMinX = 0D;
      this.StimZedGraph.ScrollMinY = 0D;
      this.StimZedGraph.ScrollMinY2 = 0D;
      this.StimZedGraph.Size = new System.Drawing.Size(1194, 320);
      this.StimZedGraph.TabIndex = 23;
      // 
      // CommonZedGraph
      // 
      this.CommonZedGraph.Location = new System.Drawing.Point(10, 27);
      this.CommonZedGraph.Name = "CommonZedGraph";
      this.CommonZedGraph.ScrollGrace = 0D;
      this.CommonZedGraph.ScrollMaxX = 0D;
      this.CommonZedGraph.ScrollMaxY = 0D;
      this.CommonZedGraph.ScrollMaxY2 = 0D;
      this.CommonZedGraph.ScrollMinX = 0D;
      this.CommonZedGraph.ScrollMinY = 0D;
      this.CommonZedGraph.ScrollMinY2 = 0D;
      this.CommonZedGraph.Size = new System.Drawing.Size(902, 268);
      this.CommonZedGraph.TabIndex = 24;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1220, 972);
      this.Controls.Add(this.CommonZedGraph);
      this.Controls.Add(this.StimZedGraph);
      this.Controls.Add(this.NoStimZedGraph);
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
      this.contextMenuStrip1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.TopScroll)).EndInit();
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
    private System.Windows.Forms.TrackBar Threshold_Scroll;
    private System.Windows.Forms.PictureBox StimCharacter;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.NumericUpDown numericNoStim;
    private System.Windows.Forms.NumericUpDown numericAfterStim;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label2;
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
    private System.Windows.Forms.ToolStripMenuItem матрицуКорToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem убратьХарактеристикуToolStripMenuItem;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem savaToolStripMenuItem;
    private ZedGraph.ZedGraphControl NoStimZedGraph;
    private ZedGraph.ZedGraphControl StimZedGraph;
    private ZedGraph.ZedGraphControl CommonZedGraph;
  }
}

