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
      ((System.ComponentModel.ISupportInitialize)(this.SpikeGraph)).BeginInit();
      this.SuspendLayout();
      // 
      // SpikeGraph
      // 
      this.SpikeGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.SpikeGraph.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.SpikeGraph.Location = new System.Drawing.Point(12, 12);
      this.SpikeGraph.Name = "SpikeGraph";
      this.SpikeGraph.Size = new System.Drawing.Size(1168, 455);
      this.SpikeGraph.TabIndex = 0;
      this.SpikeGraph.TabStop = false;
      this.SpikeGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.SpikeGraph_Paint);
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(1350, 56);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "label1";
      // 
      // Load_Button
      // 
      this.Load_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.Load_Button.Location = new System.Drawing.Point(1391, 51);
      this.Load_Button.Name = "Load_Button";
      this.Load_Button.Size = new System.Drawing.Size(75, 23);
      this.Load_Button.TabIndex = 2;
      this.Load_Button.Text = "load";
      this.Load_Button.UseVisualStyleBackColor = true;
      this.Load_Button.Click += new System.EventHandler(this.Load_Button_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1469, 475);
      this.Controls.Add(this.Load_Button);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.SpikeGraph);
      this.Name = "Form1";
      this.Text = "Form1";
      this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
      ((System.ComponentModel.ISupportInitialize)(this.SpikeGraph)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox SpikeGraph;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button Load_Button;
  }
}

