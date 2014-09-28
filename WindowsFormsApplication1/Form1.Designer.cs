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
      ((System.ComponentModel.ISupportInitialize)(this.SpikeGraph)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TopScroll)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BottomScroll)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ViewSpikeScroll)).BeginInit();
      this.SuspendLayout();
      // 
      // SpikeGraph
      // 
      this.SpikeGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.SpikeGraph.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.SpikeGraph.Location = new System.Drawing.Point(12, 12);
      this.SpikeGraph.Name = "SpikeGraph";
      this.SpikeGraph.Size = new System.Drawing.Size(792, 194);
      this.SpikeGraph.TabIndex = 0;
      this.SpikeGraph.TabStop = false;
      this.SpikeGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.SpikeGraph_Paint);
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(810, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(86, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Выберите файл";
      // 
      // Load_Button
      // 
      this.Load_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.Load_Button.Location = new System.Drawing.Point(1030, 7);
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
      this.textBox1.Location = new System.Drawing.Point(1030, 31);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(75, 20);
      this.textBox1.TabIndex = 5;
      this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(810, 34);
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
      this.pictureBox1.Location = new System.Drawing.Point(12, 224);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(1084, 397);
      this.pictureBox1.TabIndex = 7;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
      // 
      // TopScroll
      // 
      this.TopScroll.Location = new System.Drawing.Point(810, 57);
      this.TopScroll.Maximum = 50;
      this.TopScroll.Name = "TopScroll";
      this.TopScroll.Size = new System.Drawing.Size(294, 45);
      this.TopScroll.TabIndex = 8;
      this.TopScroll.TickStyle = System.Windows.Forms.TickStyle.None;
      this.TopScroll.Value = 18;
      this.TopScroll.Scroll += new System.EventHandler(this.TopScroll_Scroll);
      // 
      // BottomScroll
      // 
      this.BottomScroll.Location = new System.Drawing.Point(810, 108);
      this.BottomScroll.Maximum = 50;
      this.BottomScroll.Name = "BottomScroll";
      this.BottomScroll.Size = new System.Drawing.Size(294, 45);
      this.BottomScroll.TabIndex = 8;
      this.BottomScroll.TickStyle = System.Windows.Forms.TickStyle.None;
      this.BottomScroll.Value = 35;
      this.BottomScroll.Scroll += new System.EventHandler(this.BottomScroll_Scroll);
      // 
      // ViewSpikeScroll
      // 
      this.ViewSpikeScroll.Location = new System.Drawing.Point(810, 159);
      this.ViewSpikeScroll.Maximum = 50;
      this.ViewSpikeScroll.Name = "ViewSpikeScroll";
      this.ViewSpikeScroll.Size = new System.Drawing.Size(294, 45);
      this.ViewSpikeScroll.TabIndex = 8;
      this.ViewSpikeScroll.TickStyle = System.Windows.Forms.TickStyle.None;
      this.ViewSpikeScroll.Value = 10;
      this.ViewSpikeScroll.Scroll += new System.EventHandler(this.ViewSpikeScroll_Scroll);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1108, 633);
      this.Controls.Add(this.ViewSpikeScroll);
      this.Controls.Add(this.BottomScroll);
      this.Controls.Add(this.TopScroll);
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
  }
}

