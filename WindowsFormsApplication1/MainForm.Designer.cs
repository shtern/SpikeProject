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
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.savaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.Threshold_Scroll = new System.Windows.Forms.TrackBar();
      this.label8 = new System.Windows.Forms.Label();
      this.colSpikeLabel = new System.Windows.Forms.Label();
      this.controlGroupBox = new System.Windows.Forms.GroupBox();
      this.spikeViewTypeLabel = new System.Windows.Forms.Label();
      this.separateButton = new System.Windows.Forms.RadioButton();
      this.togetherButton = new System.Windows.Forms.RadioButton();
      this.afterStimLabel = new System.Windows.Forms.Label();
      this.beforeStimLabel = new System.Windows.Forms.Label();
      this.numericAfterStim = new System.Windows.Forms.NumericUpDown();
      this.numericNoStim = new System.Windows.Forms.NumericUpDown();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.FileItem = new System.Windows.Forms.ToolStripMenuItem();
      this.LoadDataItem = new System.Windows.Forms.ToolStripMenuItem();
      this.LoadHeatmapItem = new System.Windows.Forms.ToolStripMenuItem();
      this.EditItem = new System.Windows.Forms.ToolStripMenuItem();
      this.RemoveCharactItem = new System.Windows.Forms.ToolStripMenuItem();
      this.BuildItem = new System.Windows.Forms.ToolStripMenuItem();
      this.AverageCompItem = new System.Windows.Forms.ToolStripMenuItem();
      this.HeatMapItem = new System.Windows.Forms.ToolStripMenuItem();
      this.CorrMatrixItem = new System.Windows.Forms.ToolStripMenuItem();
      this.SingalProcessItem = new System.Windows.Forms.ToolStripMenuItem();
      this.MAItem = new System.Windows.Forms.ToolStripMenuItem();
      this.MAParamItem = new System.Windows.Forms.ToolStripMenuItem();
      this.MAParamTB = new System.Windows.Forms.ToolStripTextBox();
      this.ApproxItem = new System.Windows.Forms.ToolStripMenuItem();
      this.SettingsItem = new System.Windows.Forms.ToolStripMenuItem();
      this.AvgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.OpenDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.CommonSettingsItem = new System.Windows.Forms.ToolStripMenuItem();
      this.NoStimZedGraph = new ZedGraph.ZedGraphControl();
      this.StimZedGraph = new ZedGraph.ZedGraphControl();
      this.CommonZedGraph = new ZedGraph.ZedGraphControl();
      this.ApproxParamItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ApproxParamText = new System.Windows.Forms.ToolStripTextBox();
      this.contextMenuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.Threshold_Scroll)).BeginInit();
      this.controlGroupBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericAfterStim)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericNoStim)).BeginInit();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
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
      // Threshold_Scroll
      // 
      this.Threshold_Scroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.Threshold_Scroll.AutoSize = false;
      this.Threshold_Scroll.Location = new System.Drawing.Point(26, 42);
      this.Threshold_Scroll.Maximum = 500;
      this.Threshold_Scroll.Minimum = 1;
      this.Threshold_Scroll.Name = "Threshold_Scroll";
      this.Threshold_Scroll.Size = new System.Drawing.Size(239, 24);
      this.Threshold_Scroll.TabIndex = 9;
      this.Threshold_Scroll.TickStyle = System.Windows.Forms.TickStyle.None;
      this.Threshold_Scroll.Value = 100;
      this.Threshold_Scroll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Threshold_Scroll_MouseUp);
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
      // colSpikeLabel
      // 
      this.colSpikeLabel.AutoSize = true;
      this.colSpikeLabel.Location = new System.Drawing.Point(39, 95);
      this.colSpikeLabel.Name = "colSpikeLabel";
      this.colSpikeLabel.Size = new System.Drawing.Size(202, 13);
      this.colSpikeLabel.TabIndex = 11;
      this.colSpikeLabel.Text = "Количество спайковых характеристик";
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
      this.controlGroupBox.Location = new System.Drawing.Point(1207, 27);
      this.controlGroupBox.Name = "controlGroupBox";
      this.controlGroupBox.Size = new System.Drawing.Size(267, 268);
      this.controlGroupBox.TabIndex = 14;
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
      this.separateButton.CheckedChanged += new System.EventHandler(this.separateButton_CheckedChanged);
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
      this.togetherButton.CheckedChanged += new System.EventHandler(this.togetherButton_CheckedChanged);
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
      this.numericAfterStim.ValueChanged += new System.EventHandler(this.numericAfterStim_ValueChanged);
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
      this.numericNoStim.ValueChanged += new System.EventHandler(this.numericNo_ValueChanged);
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
      this.menuStrip1.Size = new System.Drawing.Size(1484, 24);
      this.menuStrip1.TabIndex = 21;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // FileItem
      // 
      this.FileItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadDataItem,
            this.LoadHeatmapItem});
      this.FileItem.Name = "FileItem";
      this.FileItem.Size = new System.Drawing.Size(48, 20);
      this.FileItem.Text = "Файл";
      // 
      // LoadDataItem
      // 
      this.LoadDataItem.Name = "LoadDataItem";
      this.LoadDataItem.Size = new System.Drawing.Size(193, 22);
      this.LoadDataItem.Text = "Загрузить данные";
      this.LoadDataItem.Click += new System.EventHandler(this.LoadDataItem_Click);
      // 
      // LoadHeatmapItem
      // 
      this.LoadHeatmapItem.Name = "LoadHeatmapItem";
      this.LoadHeatmapItem.Size = new System.Drawing.Size(193, 22);
      this.LoadHeatmapItem.Text = "Загрузить теплокарту";
      this.LoadHeatmapItem.Click += new System.EventHandler(this.LoadHeatmapItem_Click);
      // 
      // EditItem
      // 
      this.EditItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveCharactItem});
      this.EditItem.Name = "EditItem";
      this.EditItem.Size = new System.Drawing.Size(59, 20);
      this.EditItem.Text = "Правка";
      // 
      // RemoveCharactItem
      // 
      this.RemoveCharactItem.Name = "RemoveCharactItem";
      this.RemoveCharactItem.Size = new System.Drawing.Size(200, 22);
      this.RemoveCharactItem.Text = "Убрать характеристику";
      this.RemoveCharactItem.Click += new System.EventHandler(this.RemoveCharactItem_Click);
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
      this.AverageCompItem.Click += new System.EventHandler(this.AverageCompItem_Click);
      // 
      // HeatMapItem
      // 
      this.HeatMapItem.Name = "HeatMapItem";
      this.HeatMapItem.Size = new System.Drawing.Size(193, 22);
      this.HeatMapItem.Text = "Тепловые карты";
      this.HeatMapItem.Click += new System.EventHandler(this.HeatMapItem_Click);
      // 
      // CorrMatrixItem
      // 
      this.CorrMatrixItem.Name = "CorrMatrixItem";
      this.CorrMatrixItem.Size = new System.Drawing.Size(193, 22);
      this.CorrMatrixItem.Text = "Матрицу корреляции";
      this.CorrMatrixItem.Click += new System.EventHandler(this.CorrMatrixItem_Click);
      // 
      // SingalProcessItem
      // 
      this.SingalProcessItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MAItem,
            this.ApproxItem});
      this.SingalProcessItem.Name = "SingalProcessItem";
      this.SingalProcessItem.Size = new System.Drawing.Size(126, 20);
      this.SingalProcessItem.Text = "Обработка сигнала";
      this.SingalProcessItem.DropDownClosed += new System.EventHandler(this.обработкаСигналаToolStripMenuItem_DropDownClosed);
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
      this.MAItem.Click += new System.EventHandler(this.скользящееСреднееToolStripMenuItem_Click);
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
      this.MAParamTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MAParamTB_KeyDown);
      this.MAParamTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MAParamTB_KeyPress);
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
      this.ApproxItem.Click += new System.EventHandler(this.ApproxItem_Click);
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
      this.AvgToolStripMenuItem.CheckedChanged += new System.EventHandler(this.AvgToolStripMenuItem_CheckedChanged);
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
      this.CommonSettingsItem.Click += new System.EventHandler(this.CommonSettingsItem_Click);
      // 
      // NoStimZedGraph
      // 
      this.NoStimZedGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.NoStimZedGraph.Location = new System.Drawing.Point(10, 311);
      this.NoStimZedGraph.Name = "NoStimZedGraph";
      this.NoStimZedGraph.ScrollGrace = 0D;
      this.NoStimZedGraph.ScrollMaxX = 0D;
      this.NoStimZedGraph.ScrollMaxY = 0D;
      this.NoStimZedGraph.ScrollMaxY2 = 0D;
      this.NoStimZedGraph.ScrollMinX = 0D;
      this.NoStimZedGraph.ScrollMinY = 0D;
      this.NoStimZedGraph.ScrollMinY2 = 0D;
      this.NoStimZedGraph.Size = new System.Drawing.Size(1464, 320);
      this.NoStimZedGraph.TabIndex = 22;
      // 
      // StimZedGraph
      // 
      this.StimZedGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.StimZedGraph.Location = new System.Drawing.Point(16, 645);
      this.StimZedGraph.Name = "StimZedGraph";
      this.StimZedGraph.ScrollGrace = 0D;
      this.StimZedGraph.ScrollMaxX = 0D;
      this.StimZedGraph.ScrollMaxY = 0D;
      this.StimZedGraph.ScrollMaxY2 = 0D;
      this.StimZedGraph.ScrollMinX = 0D;
      this.StimZedGraph.ScrollMinY = 0D;
      this.StimZedGraph.ScrollMinY2 = 0D;
      this.StimZedGraph.Size = new System.Drawing.Size(1458, 320);
      this.StimZedGraph.TabIndex = 23;
      // 
      // CommonZedGraph
      // 
      this.CommonZedGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.CommonZedGraph.Location = new System.Drawing.Point(12, 27);
      this.CommonZedGraph.Name = "CommonZedGraph";
      this.CommonZedGraph.ScrollGrace = 0D;
      this.CommonZedGraph.ScrollMaxX = 0D;
      this.CommonZedGraph.ScrollMaxY = 0D;
      this.CommonZedGraph.ScrollMaxY2 = 0D;
      this.CommonZedGraph.ScrollMinX = 0D;
      this.CommonZedGraph.ScrollMinY = 0D;
      this.CommonZedGraph.ScrollMinY2 = 0D;
      this.CommonZedGraph.Size = new System.Drawing.Size(1189, 268);
      this.CommonZedGraph.TabIndex = 24;
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
      this.ApproxParamText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ApproxParamText_KeyDown);
      this.ApproxParamText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ApproxParamText_KeyPress);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1484, 972);
      this.Controls.Add(this.CommonZedGraph);
      this.Controls.Add(this.StimZedGraph);
      this.Controls.Add(this.NoStimZedGraph);
      this.Controls.Add(this.controlGroupBox);
      this.Controls.Add(this.menuStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip1;
      this.MinimumSize = new System.Drawing.Size(1236, 1010);
      this.Name = "MainForm";
      this.Text = "Анализ спайковых характеристик";
      this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
      this.contextMenuStrip1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.Threshold_Scroll)).EndInit();
      this.controlGroupBox.ResumeLayout(false);
      this.controlGroupBox.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericAfterStim)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericNoStim)).EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TrackBar Threshold_Scroll;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label colSpikeLabel;
    private System.Windows.Forms.GroupBox controlGroupBox;
    private System.Windows.Forms.NumericUpDown numericNoStim;
    private System.Windows.Forms.NumericUpDown numericAfterStim;
    private System.Windows.Forms.Label afterStimLabel;
    private System.Windows.Forms.Label beforeStimLabel;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem FileItem;
    private System.Windows.Forms.ToolStripMenuItem LoadDataItem;
    private System.Windows.Forms.ToolStripMenuItem BuildItem;
    private System.Windows.Forms.ToolStripMenuItem AverageCompItem;
    private System.Windows.Forms.ToolStripMenuItem HeatMapItem;
    private System.Windows.Forms.ToolStripMenuItem SettingsItem;
    private System.Windows.Forms.ToolStripMenuItem AvgToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem OpenDirToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem LoadHeatmapItem;
    private System.Windows.Forms.ToolStripMenuItem CommonSettingsItem;
    private System.Windows.Forms.ToolStripMenuItem CorrMatrixItem;
    private System.Windows.Forms.ToolStripMenuItem EditItem;
    private System.Windows.Forms.ToolStripMenuItem RemoveCharactItem;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem savaToolStripMenuItem;
    private ZedGraph.ZedGraphControl NoStimZedGraph;
    private ZedGraph.ZedGraphControl StimZedGraph;
    private ZedGraph.ZedGraphControl CommonZedGraph;
    private System.Windows.Forms.ToolStripMenuItem SingalProcessItem;
    private System.Windows.Forms.ToolStripMenuItem MAItem;
    private System.Windows.Forms.ToolStripMenuItem ApproxItem;
    private System.Windows.Forms.ToolStripTextBox MAParamTB;
    private System.Windows.Forms.ToolStripMenuItem MAParamItem;
    private System.Windows.Forms.RadioButton separateButton;
    private System.Windows.Forms.RadioButton togetherButton;
    private System.Windows.Forms.Label spikeViewTypeLabel;
    private System.Windows.Forms.ToolStripMenuItem ApproxParamItem;
    private System.Windows.Forms.ToolStripTextBox ApproxParamText;
  }
}

