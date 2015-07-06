namespace AnalizerCore.Views
{
  partial class FMainForm
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
      this.BuildItem = new System.Windows.Forms.ToolStripMenuItem();
      this.AverageCompItem = new System.Windows.Forms.ToolStripMenuItem();
      this.HeatMapItem = new System.Windows.Forms.ToolStripMenuItem();
      this.CorrMatrixItem = new System.Windows.Forms.ToolStripMenuItem();
      this.SingalProcessItem = new System.Windows.Forms.ToolStripMenuItem();
      this.MAItem = new System.Windows.Forms.ToolStripMenuItem();
      this.MAParamItem = new System.Windows.Forms.ToolStripMenuItem();
      this.MAParamTB = new System.Windows.Forms.ToolStripTextBox();
      this.ApproxItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ApproxParamItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ApproxParamText = new System.Windows.Forms.ToolStripTextBox();
      this.SettingsItem = new System.Windows.Forms.ToolStripMenuItem();
      this.AvgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.OpenDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.CommonSettingsItem = new System.Windows.Forms.ToolStripMenuItem();
      this.RemoveCharactItem = new System.Windows.Forms.ToolStripMenuItem();
      this.EditItem = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.savaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.controlGroupBox = new System.Windows.Forms.GroupBox();
      this.spikeViewTypeLabel = new System.Windows.Forms.Label();
      this.separateButton = new System.Windows.Forms.RadioButton();
      this.togetherButton = new System.Windows.Forms.RadioButton();
      this.afterStimLabel = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.beforeStimLabel = new System.Windows.Forms.Label();
      this.numericAfterStim = new System.Windows.Forms.NumericUpDown();
      this.numericNoStim = new System.Windows.Forms.NumericUpDown();
      this.Threshold_Scroll = new System.Windows.Forms.TrackBar();
      this.colSpikeLabel = new System.Windows.Forms.Label();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.FileItem = new System.Windows.Forms.ToolStripMenuItem();
      this.LoadDataItem = new System.Windows.Forms.ToolStripMenuItem();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.radioButton1 = new System.Windows.Forms.RadioButton();
      this.radioButton2 = new System.Windows.Forms.RadioButton();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
      this.trackBar1 = new System.Windows.Forms.TrackBar();
      this.label5 = new System.Windows.Forms.Label();
      this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
      this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
      this.zedGraphControl3 = new ZedGraph.ZedGraphControl();
      this.contextMenuStrip1.SuspendLayout();
      this.controlGroupBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericAfterStim)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericNoStim)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.Threshold_Scroll)).BeginInit();
      this.menuStrip1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
      this.SuspendLayout();
      // 
      // BuildItem
      // 
      this.BuildItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AverageCompItem,
            this.HeatMapItem,
            this.CorrMatrixItem});
      this.BuildItem.Name = "BuildItem";
      this.BuildItem.Size = new System.Drawing.Size(78, 20);
      this.BuildItem.Text = "Построить";
      // 
      // AverageCompItem
      // 
      this.AverageCompItem.Name = "AverageCompItem";
      this.AverageCompItem.Size = new System.Drawing.Size(193, 22);
      this.AverageCompItem.Text = "Сравнение средних";
      // 
      // HeatMapItem
      // 
      this.HeatMapItem.Name = "HeatMapItem";
      this.HeatMapItem.Size = new System.Drawing.Size(193, 22);
      this.HeatMapItem.Text = "Тепловые карты";
      // 
      // CorrMatrixItem
      // 
      this.CorrMatrixItem.Name = "CorrMatrixItem";
      this.CorrMatrixItem.Size = new System.Drawing.Size(193, 22);
      this.CorrMatrixItem.Text = "Матрицу корреляции";
      // 
      // SingalProcessItem
      // 
      this.SingalProcessItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MAItem,
            this.ApproxItem});
      this.SingalProcessItem.Name = "SingalProcessItem";
      this.SingalProcessItem.Size = new System.Drawing.Size(126, 20);
      this.SingalProcessItem.Text = "Обработка сигнала";
      // 
      // MAItem
      // 
      this.MAItem.Checked = true;
      this.MAItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.MAItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MAParamItem,
            this.MAParamTB});
      this.MAItem.Name = "MAItem";
      this.MAItem.Size = new System.Drawing.Size(209, 22);
      this.MAItem.Text = "Скользящее среднее";
      // 
      // MAParamItem
      // 
      this.MAParamItem.Name = "MAParamItem";
      this.MAParamItem.Size = new System.Drawing.Size(160, 22);
      this.MAParamItem.Text = "Параметр";
      // 
      // MAParamTB
      // 
      this.MAParamTB.Name = "MAParamTB";
      this.MAParamTB.Size = new System.Drawing.Size(100, 23);
      this.MAParamTB.Text = "7";
      // 
      // ApproxItem
      // 
      this.ApproxItem.Checked = true;
      this.ApproxItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ApproxItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ApproxParamItem,
            this.ApproxParamText});
      this.ApproxItem.Name = "ApproxItem";
      this.ApproxItem.Size = new System.Drawing.Size(209, 22);
      this.ApproxItem.Text = "Нормирование по оси Y";
      // 
      // ApproxParamItem
      // 
      this.ApproxParamItem.Name = "ApproxParamItem";
      this.ApproxParamItem.Size = new System.Drawing.Size(160, 22);
      this.ApproxParamItem.Text = "Параметр";
      // 
      // ApproxParamText
      // 
      this.ApproxParamText.Name = "ApproxParamText";
      this.ApproxParamText.Size = new System.Drawing.Size(100, 23);
      this.ApproxParamText.Text = "5";
      // 
      // SettingsItem
      // 
      this.SettingsItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AvgToolStripMenuItem,
            this.OpenDirToolStripMenuItem,
            this.CommonSettingsItem});
      this.SettingsItem.Name = "SettingsItem";
      this.SettingsItem.Size = new System.Drawing.Size(79, 20);
      this.SettingsItem.Text = "Настройки";
      // 
      // AvgToolStripMenuItem
      // 
      this.AvgToolStripMenuItem.Checked = true;
      this.AvgToolStripMenuItem.CheckOnClick = true;
      this.AvgToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.AvgToolStripMenuItem.Name = "AvgToolStripMenuItem";
      this.AvgToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
      this.AvgToolStripMenuItem.Text = "Рисовать средние";
      // 
      // OpenDirToolStripMenuItem
      // 
      this.OpenDirToolStripMenuItem.Checked = true;
      this.OpenDirToolStripMenuItem.CheckOnClick = true;
      this.OpenDirToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.OpenDirToolStripMenuItem.Name = "OpenDirToolStripMenuItem";
      this.OpenDirToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
      this.OpenDirToolStripMenuItem.Text = "Открывать окно при сохранении";
      // 
      // CommonSettingsItem
      // 
      this.CommonSettingsItem.Name = "CommonSettingsItem";
      this.CommonSettingsItem.Size = new System.Drawing.Size(255, 22);
      this.CommonSettingsItem.Text = "Общие настройки";
      // 
      // RemoveCharactItem
      // 
      this.RemoveCharactItem.Name = "RemoveCharactItem";
      this.RemoveCharactItem.Size = new System.Drawing.Size(200, 22);
      this.RemoveCharactItem.Text = "Убрать характеристику";
      // 
      // EditItem
      // 
      this.EditItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveCharactItem});
      this.EditItem.Name = "EditItem";
      this.EditItem.Size = new System.Drawing.Size(59, 20);
      this.EditItem.Text = "Правка";
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
      // controlGroupBox
      // 
      this.controlGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.controlGroupBox.Controls.Add(this.spikeViewTypeLabel);
      this.controlGroupBox.Controls.Add(this.separateButton);
      this.controlGroupBox.Controls.Add(this.togetherButton);
      this.controlGroupBox.Controls.Add(this.afterStimLabel);
      this.controlGroupBox.Controls.Add(this.label8);
      this.controlGroupBox.Controls.Add(this.beforeStimLabel);
      this.controlGroupBox.Controls.Add(this.numericAfterStim);
      this.controlGroupBox.Controls.Add(this.numericNoStim);
      this.controlGroupBox.Controls.Add(this.Threshold_Scroll);
      this.controlGroupBox.Controls.Add(this.colSpikeLabel);
      this.controlGroupBox.Location = new System.Drawing.Point(1732, 182);
      this.controlGroupBox.Name = "controlGroupBox";
      this.controlGroupBox.Size = new System.Drawing.Size(14, 268);
      this.controlGroupBox.TabIndex = 22;
      this.controlGroupBox.TabStop = false;
      // 
      // spikeViewTypeLabel
      // 
      this.spikeViewTypeLabel.AutoSize = true;
      this.spikeViewTypeLabel.Location = new System.Drawing.Point(57, 189);
      this.spikeViewTypeLabel.Name = "spikeViewTypeLabel";
      this.spikeViewTypeLabel.Size = new System.Drawing.Size(162, 13);
      this.spikeViewTypeLabel.TabIndex = 21;
      this.spikeViewTypeLabel.Text = "Тип просмотра характеристик";
      // 
      // separateButton
      // 
      this.separateButton.AutoSize = true;
      this.separateButton.Location = new System.Drawing.Point(180, 219);
      this.separateButton.Name = "separateButton";
      this.separateButton.Size = new System.Drawing.Size(80, 17);
      this.separateButton.TabIndex = 20;
      this.separateButton.Text = "Раздельно";
      this.separateButton.UseVisualStyleBackColor = true;
      // 
      // togetherButton
      // 
      this.togetherButton.AutoSize = true;
      this.togetherButton.Checked = true;
      this.togetherButton.Location = new System.Drawing.Point(34, 219);
      this.togetherButton.Name = "togetherButton";
      this.togetherButton.Size = new System.Drawing.Size(63, 17);
      this.togetherButton.TabIndex = 19;
      this.togetherButton.TabStop = true;
      this.togetherButton.Text = "Вместе";
      this.togetherButton.UseVisualStyleBackColor = true;
      // 
      // afterStimLabel
      // 
      this.afterStimLabel.AutoSize = true;
      this.afterStimLabel.Location = new System.Drawing.Point(158, 121);
      this.afterStimLabel.Name = "afterStimLabel";
      this.afterStimLabel.Size = new System.Drawing.Size(102, 13);
      this.afterStimLabel.TabIndex = 18;
      this.afterStimLabel.Text = "После стимуляции";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(127, 16);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(38, 13);
      this.label8.TabIndex = 12;
      this.label8.Text = "Порог";
      // 
      // beforeStimLabel
      // 
      this.beforeStimLabel.AutoSize = true;
      this.beforeStimLabel.Location = new System.Drawing.Point(23, 121);
      this.beforeStimLabel.Name = "beforeStimLabel";
      this.beforeStimLabel.Size = new System.Drawing.Size(85, 13);
      this.beforeStimLabel.TabIndex = 17;
      this.beforeStimLabel.Text = "До стимуляции";
      // 
      // numericAfterStim
      // 
      this.numericAfterStim.Location = new System.Drawing.Point(186, 138);
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
      // 
      // numericNoStim
      // 
      this.numericNoStim.Location = new System.Drawing.Point(34, 139);
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
      // 
      // Threshold_Scroll
      // 
      this.Threshold_Scroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.Threshold_Scroll.AutoSize = false;
      this.Threshold_Scroll.Location = new System.Drawing.Point(-227, 42);
      this.Threshold_Scroll.Maximum = 500;
      this.Threshold_Scroll.Minimum = 1;
      this.Threshold_Scroll.Name = "Threshold_Scroll";
      this.Threshold_Scroll.Size = new System.Drawing.Size(239, 24);
      this.Threshold_Scroll.TabIndex = 9;
      this.Threshold_Scroll.TickStyle = System.Windows.Forms.TickStyle.None;
      this.Threshold_Scroll.Value = 100;
      // 
      // colSpikeLabel
      // 
      this.colSpikeLabel.AutoSize = true;
      this.colSpikeLabel.Location = new System.Drawing.Point(39, 95);
      this.colSpikeLabel.Name = "colSpikeLabel";
      this.colSpikeLabel.Size = new System.Drawing.Size(202, 13);
      this.colSpikeLabel.TabIndex = 11;
      this.colSpikeLabel.Text = "Количество спайковых характеристик";
      // 
      // menuStrip1
      // 
      this.menuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileItem,
            this.EditItem,
            this.BuildItem,
            this.SingalProcessItem,
            this.SettingsItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(1469, 24);
      this.menuStrip1.TabIndex = 23;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // FileItem
      // 
      this.FileItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadDataItem});
      this.FileItem.Name = "FileItem";
      this.FileItem.Size = new System.Drawing.Size(48, 20);
      this.FileItem.Text = "Файл";
      // 
      // LoadDataItem
      // 
      this.LoadDataItem.Name = "LoadDataItem";
      this.LoadDataItem.Size = new System.Drawing.Size(172, 22);
      this.LoadDataItem.Text = "Загрузить данные";
      this.LoadDataItem.Click += new System.EventHandler(this.LoadDataItem_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.radioButton1);
      this.groupBox1.Controls.Add(this.radioButton2);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.numericUpDown1);
      this.groupBox1.Controls.Add(this.numericUpDown2);
      this.groupBox1.Controls.Add(this.trackBar1);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Location = new System.Drawing.Point(1195, 27);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(267, 268);
      this.groupBox1.TabIndex = 24;
      this.groupBox1.TabStop = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(57, 189);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(162, 13);
      this.label1.TabIndex = 21;
      this.label1.Text = "Тип просмотра характеристик";
      // 
      // radioButton1
      // 
      this.radioButton1.AutoSize = true;
      this.radioButton1.Location = new System.Drawing.Point(180, 219);
      this.radioButton1.Name = "radioButton1";
      this.radioButton1.Size = new System.Drawing.Size(80, 17);
      this.radioButton1.TabIndex = 20;
      this.radioButton1.Text = "Раздельно";
      this.radioButton1.UseVisualStyleBackColor = true;
      // 
      // radioButton2
      // 
      this.radioButton2.AutoSize = true;
      this.radioButton2.Checked = true;
      this.radioButton2.Location = new System.Drawing.Point(34, 219);
      this.radioButton2.Name = "radioButton2";
      this.radioButton2.Size = new System.Drawing.Size(63, 17);
      this.radioButton2.TabIndex = 19;
      this.radioButton2.TabStop = true;
      this.radioButton2.Text = "Вместе";
      this.radioButton2.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(158, 121);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(102, 13);
      this.label2.TabIndex = 18;
      this.label2.Text = "После стимуляции";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(127, 16);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(38, 13);
      this.label3.TabIndex = 12;
      this.label3.Text = "Порог";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(23, 121);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(85, 13);
      this.label4.TabIndex = 17;
      this.label4.Text = "До стимуляции";
      // 
      // numericUpDown1
      // 
      this.numericUpDown1.Location = new System.Drawing.Point(186, 138);
      this.numericUpDown1.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
      this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new System.Drawing.Size(50, 20);
      this.numericUpDown1.TabIndex = 16;
      this.numericUpDown1.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
      // 
      // numericUpDown2
      // 
      this.numericUpDown2.Location = new System.Drawing.Point(34, 139);
      this.numericUpDown2.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
      this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numericUpDown2.Name = "numericUpDown2";
      this.numericUpDown2.Size = new System.Drawing.Size(50, 20);
      this.numericUpDown2.TabIndex = 15;
      this.numericUpDown2.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
      // 
      // trackBar1
      // 
      this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.trackBar1.AutoSize = false;
      this.trackBar1.Location = new System.Drawing.Point(26, 42);
      this.trackBar1.Maximum = 500;
      this.trackBar1.Minimum = 1;
      this.trackBar1.Name = "trackBar1";
      this.trackBar1.Size = new System.Drawing.Size(239, 24);
      this.trackBar1.TabIndex = 9;
      this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
      this.trackBar1.Value = 100;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(39, 95);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(202, 13);
      this.label5.TabIndex = 11;
      this.label5.Text = "Количество спайковых характеристик";
      // 
      // zedGraphControl1
      // 
      this.zedGraphControl1.Location = new System.Drawing.Point(12, 27);
      this.zedGraphControl1.Name = "zedGraphControl1";
      this.zedGraphControl1.ScrollGrace = 0D;
      this.zedGraphControl1.ScrollMaxX = 0D;
      this.zedGraphControl1.ScrollMaxY = 0D;
      this.zedGraphControl1.ScrollMaxY2 = 0D;
      this.zedGraphControl1.ScrollMinX = 0D;
      this.zedGraphControl1.ScrollMinY = 0D;
      this.zedGraphControl1.ScrollMinY2 = 0D;
      this.zedGraphControl1.Size = new System.Drawing.Size(1170, 268);
      this.zedGraphControl1.TabIndex = 25;
      // 
      // zedGraphControl2
      // 
      this.zedGraphControl2.Location = new System.Drawing.Point(12, 301);
      this.zedGraphControl2.Name = "zedGraphControl2";
      this.zedGraphControl2.ScrollGrace = 0D;
      this.zedGraphControl2.ScrollMaxX = 0D;
      this.zedGraphControl2.ScrollMaxY = 0D;
      this.zedGraphControl2.ScrollMaxY2 = 0D;
      this.zedGraphControl2.ScrollMinX = 0D;
      this.zedGraphControl2.ScrollMinY = 0D;
      this.zedGraphControl2.ScrollMinY2 = 0D;
      this.zedGraphControl2.Size = new System.Drawing.Size(1450, 244);
      this.zedGraphControl2.TabIndex = 26;
      // 
      // zedGraphControl3
      // 
      this.zedGraphControl3.Location = new System.Drawing.Point(12, 551);
      this.zedGraphControl3.Name = "zedGraphControl3";
      this.zedGraphControl3.ScrollGrace = 0D;
      this.zedGraphControl3.ScrollMaxX = 0D;
      this.zedGraphControl3.ScrollMaxY = 0D;
      this.zedGraphControl3.ScrollMaxY2 = 0D;
      this.zedGraphControl3.ScrollMinX = 0D;
      this.zedGraphControl3.ScrollMinY = 0D;
      this.zedGraphControl3.ScrollMinY2 = 0D;
      this.zedGraphControl3.Size = new System.Drawing.Size(1450, 205);
      this.zedGraphControl3.TabIndex = 27;
      // 
      // FMainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1469, 768);
      this.Controls.Add(this.zedGraphControl3);
      this.Controls.Add(this.zedGraphControl2);
      this.Controls.Add(this.zedGraphControl1);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.controlGroupBox);
      this.Controls.Add(this.menuStrip1);
      this.Name = "FMainForm";
      this.Text = "FMainForm";
      this.contextMenuStrip1.ResumeLayout(false);
      this.controlGroupBox.ResumeLayout(false);
      this.controlGroupBox.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericAfterStim)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericNoStim)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.Threshold_Scroll)).EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStripMenuItem BuildItem;
    private System.Windows.Forms.ToolStripMenuItem AverageCompItem;
    private System.Windows.Forms.ToolStripMenuItem HeatMapItem;
    private System.Windows.Forms.ToolStripMenuItem CorrMatrixItem;
    private System.Windows.Forms.ToolStripMenuItem SingalProcessItem;
    private System.Windows.Forms.ToolStripMenuItem MAItem;
    private System.Windows.Forms.ToolStripMenuItem MAParamItem;
    private System.Windows.Forms.ToolStripTextBox MAParamTB;
    private System.Windows.Forms.ToolStripMenuItem ApproxItem;
    private System.Windows.Forms.ToolStripMenuItem ApproxParamItem;
    private System.Windows.Forms.ToolStripTextBox ApproxParamText;
    private System.Windows.Forms.ToolStripMenuItem SettingsItem;
    private System.Windows.Forms.ToolStripMenuItem AvgToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem OpenDirToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem CommonSettingsItem;
    private System.Windows.Forms.ToolStripMenuItem RemoveCharactItem;
    private System.Windows.Forms.ToolStripMenuItem EditItem;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem savaToolStripMenuItem;
    private System.Windows.Forms.GroupBox controlGroupBox;
    private System.Windows.Forms.Label spikeViewTypeLabel;
    private System.Windows.Forms.RadioButton separateButton;
    private System.Windows.Forms.RadioButton togetherButton;
    private System.Windows.Forms.Label afterStimLabel;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label beforeStimLabel;
    private System.Windows.Forms.NumericUpDown numericAfterStim;
    private System.Windows.Forms.NumericUpDown numericNoStim;
    private System.Windows.Forms.TrackBar Threshold_Scroll;
    private System.Windows.Forms.Label colSpikeLabel;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem FileItem;
    private System.Windows.Forms.ToolStripMenuItem LoadDataItem;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.RadioButton radioButton1;
    private System.Windows.Forms.RadioButton radioButton2;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.NumericUpDown numericUpDown1;
    private System.Windows.Forms.NumericUpDown numericUpDown2;
    private System.Windows.Forms.TrackBar trackBar1;
    private System.Windows.Forms.Label label5;
    private ZedGraph.ZedGraphControl zedGraphControl1;
    private ZedGraph.ZedGraphControl zedGraphControl2;
    private ZedGraph.ZedGraphControl zedGraphControl3;
  }
}