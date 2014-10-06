namespace WindowsFormsApplication1
{
  partial class Form1
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
      this.SpikeGraph = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.Load_Button = new System.Windows.Forms.Button();
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
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.numericAfterStim = new System.Windows.Forms.NumericUpDown();
      this.numericNoStim = new System.Windows.Forms.NumericUpDown();
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
      this.SuspendLayout();
      // 
      // SpikeGraph
      // 
      this.SpikeGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.SpikeGraph.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.SpikeGraph.Location = new System.Drawing.Point(12, 12);
      this.SpikeGraph.Name = "SpikeGraph";
      this.SpikeGraph.Size = new System.Drawing.Size(593, 194);
      this.SpikeGraph.TabIndex = 0;
      this.SpikeGraph.TabStop = false;
      this.SpikeGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.SpikeGraph_Paint);
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(891, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(86, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Выберите файл";
      // 
      // Load_Button
      // 
      this.Load_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.Load_Button.Location = new System.Drawing.Point(1111, 7);
      this.Load_Button.Name = "Load_Button";
      this.Load_Button.Size = new System.Drawing.Size(75, 23);
      this.Load_Button.TabIndex = 2;
      this.Load_Button.Text = "Выбрать";
      this.Load_Button.UseVisualStyleBackColor = true;
      this.Load_Button.Click += new System.EventHandler(this.Load_Button_Click);
      // 
      // NoStimCharacter
      // 
      this.NoStimCharacter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.NoStimCharacter.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.NoStimCharacter.Location = new System.Drawing.Point(12, 241);
      this.NoStimCharacter.Name = "NoStimCharacter";
      this.NoStimCharacter.Size = new System.Drawing.Size(1174, 229);
      this.NoStimCharacter.TabIndex = 7;
      this.NoStimCharacter.TabStop = false;
      this.NoStimCharacter.Paint += new System.Windows.Forms.PaintEventHandler(this.NoStimCharacter_Paint);
      // 
      // TopScroll
      // 
      this.TopScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.TopScroll.Location = new System.Drawing.Point(13, 26);
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
      this.BottomScroll.Location = new System.Drawing.Point(27, 33);
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
      this.Threshold_Scroll.Location = new System.Drawing.Point(13, 70);
      this.Threshold_Scroll.Maximum = 150;
      this.Threshold_Scroll.Name = "Threshold_Scroll";
      this.Threshold_Scroll.Size = new System.Drawing.Size(160, 45);
      this.Threshold_Scroll.TabIndex = 9;
      this.Threshold_Scroll.TickStyle = System.Windows.Forms.TickStyle.None;
      this.Threshold_Scroll.Value = 20;
      this.Threshold_Scroll.Scroll += new System.EventHandler(this.Threshold_Scroll_Scroll);
      // 
      // StimCharacter
      // 
      this.StimCharacter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.StimCharacter.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.StimCharacter.Location = new System.Drawing.Point(12, 484);
      this.StimCharacter.Name = "StimCharacter";
      this.StimCharacter.Size = new System.Drawing.Size(1174, 238);
      this.StimCharacter.TabIndex = 10;
      this.StimCharacter.TabStop = false;
      this.StimCharacter.Paint += new System.Windows.Forms.PaintEventHandler(this.StimCharacter_Paint);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(179, 29);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(53, 13);
      this.label4.TabIndex = 9;
      this.label4.Text = "Масштаб";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(179, 70);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(38, 13);
      this.label8.TabIndex = 12;
      this.label8.Text = "Порог";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(50, 80);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(202, 13);
      this.label7.TabIndex = 11;
      this.label7.Text = "Количество спайковых характеристик";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(233, 33);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(53, 13);
      this.label6.TabIndex = 10;
      this.label6.Text = "Масштаб";
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.label8);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.TopScroll);
      this.groupBox1.Controls.Add(this.Threshold_Scroll);
      this.groupBox1.Location = new System.Drawing.Point(622, 9);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(254, 120);
      this.groupBox1.TabIndex = 13;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Общий график";
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
      this.groupBox2.Location = new System.Drawing.Point(892, 37);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(292, 169);
      this.groupBox2.TabIndex = 14;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Графики спайковых характеристик";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(184, 105);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(102, 13);
      this.label5.TabIndex = 18;
      this.label5.Text = "После стимуляции";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(17, 105);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(85, 13);
      this.label2.TabIndex = 17;
      this.label2.Text = "До стимуляции";
      // 
      // numericAfterStim
      // 
      this.numericAfterStim.Location = new System.Drawing.Point(202, 130);
      this.numericAfterStim.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
      this.numericAfterStim.Name = "numericAfterStim";
      this.numericAfterStim.Size = new System.Drawing.Size(50, 20);
      this.numericAfterStim.TabIndex = 16;
      this.numericAfterStim.ValueChanged += new System.EventHandler(this.numericAfterStim_ValueChanged);
      // 
      // numericNoStim
      // 
      this.numericNoStim.Location = new System.Drawing.Point(33, 130);
      this.numericNoStim.Maximum = new decimal(new int[] {
            11,
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
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1198, 734);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.StimCharacter);
      this.Controls.Add(this.NoStimCharacter);
      this.Controls.Add(this.Load_Button);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.SpikeGraph);
      this.Name = "Form1";
      this.Text = "Анализ спайковых характеристик";
      this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
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
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox SpikeGraph;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button Load_Button;
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
  }
}

