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
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.TopScroll = new System.Windows.Forms.TrackBar();
      this.BottomScroll = new System.Windows.Forms.TrackBar();
      this.ViewSpikeScroll = new System.Windows.Forms.TrackBar();
      this.Threshold_Scroll = new System.Windows.Forms.TrackBar();
      this.pictureBox2 = new System.Windows.Forms.PictureBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      ((System.ComponentModel.ISupportInitialize)(this.SpikeGraph)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TopScroll)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BottomScroll)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ViewSpikeScroll)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.Threshold_Scroll)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // SpikeGraph
      // 
      this.SpikeGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.SpikeGraph.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.SpikeGraph.Location = new System.Drawing.Point(12, 12);
      this.SpikeGraph.Name = "SpikeGraph";
      this.SpikeGraph.Size = new System.Drawing.Size(534, 194);
      this.SpikeGraph.TabIndex = 0;
      this.SpikeGraph.TabStop = false;
      this.SpikeGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.SpikeGraph_Paint);
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(832, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(86, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Выберите файл";
      // 
      // Load_Button
      // 
      this.Load_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.Load_Button.Location = new System.Drawing.Point(1052, 7);
      this.Load_Button.Name = "Load_Button";
      this.Load_Button.Size = new System.Drawing.Size(75, 23);
      this.Load_Button.TabIndex = 2;
      this.Load_Button.Text = "Выбрать";
      this.Load_Button.UseVisualStyleBackColor = true;
      this.Load_Button.Click += new System.EventHandler(this.Load_Button_Click);
      // 
      // textBox1
      // 
      this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.textBox1.Enabled = false;
      this.textBox1.Location = new System.Drawing.Point(1052, 31);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(75, 20);
      this.textBox1.TabIndex = 5;
      this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(832, 34);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(202, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "Количество спайковых характеристик";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.pictureBox1.Location = new System.Drawing.Point(12, 243);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(534, 376);
      this.pictureBox1.TabIndex = 7;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
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
      // ViewSpikeScroll
      // 
      this.ViewSpikeScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ViewSpikeScroll.Location = new System.Drawing.Point(28, 106);
      this.ViewSpikeScroll.Maximum = 50;
      this.ViewSpikeScroll.Name = "ViewSpikeScroll";
      this.ViewSpikeScroll.Size = new System.Drawing.Size(258, 45);
      this.ViewSpikeScroll.TabIndex = 8;
      this.ViewSpikeScroll.TickStyle = System.Windows.Forms.TickStyle.None;
      this.ViewSpikeScroll.Value = 15;
      this.ViewSpikeScroll.Scroll += new System.EventHandler(this.ViewSpikeScroll_Scroll);
      // 
      // Threshold_Scroll
      // 
      this.Threshold_Scroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.Threshold_Scroll.Location = new System.Drawing.Point(13, 71);
      this.Threshold_Scroll.Maximum = 150;
      this.Threshold_Scroll.Name = "Threshold_Scroll";
      this.Threshold_Scroll.Size = new System.Drawing.Size(160, 45);
      this.Threshold_Scroll.TabIndex = 9;
      this.Threshold_Scroll.TickStyle = System.Windows.Forms.TickStyle.None;
      this.Threshold_Scroll.Value = 20;
      this.Threshold_Scroll.Scroll += new System.EventHandler(this.Threshold_Scroll_Scroll);
      // 
      // pictureBox2
      // 
      this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.pictureBox2.Location = new System.Drawing.Point(563, 243);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new System.Drawing.Size(564, 376);
      this.pictureBox2.TabIndex = 10;
      this.pictureBox2.TabStop = false;
      this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(195, 26);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(53, 13);
      this.label4.TabIndex = 9;
      this.label4.Text = "Масштаб";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(195, 71);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(38, 13);
      this.label8.TabIndex = 12;
      this.label8.Text = "Порог";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(27, 81);
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
      this.groupBox1.Location = new System.Drawing.Point(563, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(254, 136);
      this.groupBox1.TabIndex = 13;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Общий график";
      // 
      // groupBox2
      // 
      this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox2.Controls.Add(this.label7);
      this.groupBox2.Controls.Add(this.BottomScroll);
      this.groupBox2.Controls.Add(this.label6);
      this.groupBox2.Controls.Add(this.ViewSpikeScroll);
      this.groupBox2.Location = new System.Drawing.Point(835, 70);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(292, 153);
      this.groupBox2.TabIndex = 14;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Графики спайковых характеристик";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1139, 631);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.pictureBox2);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.Load_Button);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.SpikeGraph);
      this.Name = "Form1";
      this.Text = "Form1";
      this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
      ((System.ComponentModel.ISupportInitialize)(this.SpikeGraph)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TopScroll)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BottomScroll)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ViewSpikeScroll)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.Threshold_Scroll)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox SpikeGraph;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button Load_Button;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.TrackBar TopScroll;
    private System.Windows.Forms.TrackBar BottomScroll;
    private System.Windows.Forms.TrackBar ViewSpikeScroll;
    private System.Windows.Forms.TrackBar Threshold_Scroll;
    private System.Windows.Forms.PictureBox pictureBox2;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
  }
}

