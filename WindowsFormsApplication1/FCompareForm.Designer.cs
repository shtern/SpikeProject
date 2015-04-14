namespace SpikeProject
{
  partial class FCompareForm
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
      this.CompareGraph = new System.Windows.Forms.PictureBox();
      this.NormalizedGraph = new System.Windows.Forms.PictureBox();
      this.compareLabel = new System.Windows.Forms.Label();
      this.NormalizedLabel = new System.Windows.Forms.Label();
      this.moveNumeric = new System.Windows.Forms.NumericUpDown();
      ((System.ComponentModel.ISupportInitialize)(this.CompareGraph)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.NormalizedGraph)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.moveNumeric)).BeginInit();
      this.SuspendLayout();
      // 
      // CompareGraph
      // 
      this.CompareGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.CompareGraph.BackColor = System.Drawing.Color.White;
      this.CompareGraph.Location = new System.Drawing.Point(12, 36);
      this.CompareGraph.Name = "CompareGraph";
      this.CompareGraph.Size = new System.Drawing.Size(745, 342);
      this.CompareGraph.TabIndex = 0;
      this.CompareGraph.TabStop = false;
      this.CompareGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.CompareGraph_Paint);
      // 
      // NormalizedGraph
      // 
      this.NormalizedGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.NormalizedGraph.BackColor = System.Drawing.Color.White;
      this.NormalizedGraph.Location = new System.Drawing.Point(12, 418);
      this.NormalizedGraph.Name = "NormalizedGraph";
      this.NormalizedGraph.Size = new System.Drawing.Size(745, 342);
      this.NormalizedGraph.TabIndex = 1;
      this.NormalizedGraph.TabStop = false;
      this.NormalizedGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.NormalizedGraph_Paint);
      // 
      // compareLabel
      // 
      this.compareLabel.AutoSize = true;
      this.compareLabel.Location = new System.Drawing.Point(13, 13);
      this.compareLabel.Name = "compareLabel";
      this.compareLabel.Size = new System.Drawing.Size(306, 13);
      this.compareLabel.TabIndex = 2;
      this.compareLabel.Text = "Сравнение средних до стимуляции и во время стимуляции";
      // 
      // NormalizedLabel
      // 
      this.NormalizedLabel.AutoSize = true;
      this.NormalizedLabel.Location = new System.Drawing.Point(13, 393);
      this.NormalizedLabel.Name = "NormalizedLabel";
      this.NormalizedLabel.Size = new System.Drawing.Size(265, 13);
      this.NormalizedLabel.TabIndex = 3;
      this.NormalizedLabel.Text = "Сравнение средних, нормированных по амплитуде";
      // 
      // moveNumeric
      // 
      this.moveNumeric.Location = new System.Drawing.Point(635, 6);
      this.moveNumeric.Name = "moveNumeric";
      this.moveNumeric.Size = new System.Drawing.Size(120, 20);
      this.moveNumeric.TabIndex = 4;
      this.moveNumeric.Visible = false;
      this.moveNumeric.ValueChanged += new System.EventHandler(this.moveNum_ValueChanged);
      // 
      // FCompareForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(767, 768);
      this.Controls.Add(this.moveNumeric);
      this.Controls.Add(this.NormalizedLabel);
      this.Controls.Add(this.compareLabel);
      this.Controls.Add(this.NormalizedGraph);
      this.Controls.Add(this.CompareGraph);
      this.MinimumSize = new System.Drawing.Size(783, 806);
      this.Name = "FCompareForm";
      this.Text = "Сравнение спайковых характеристик";
      ((System.ComponentModel.ISupportInitialize)(this.CompareGraph)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.NormalizedGraph)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.moveNumeric)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox CompareGraph;
    private System.Windows.Forms.PictureBox NormalizedGraph;
    private System.Windows.Forms.Label compareLabel;
    private System.Windows.Forms.Label NormalizedLabel;
    private System.Windows.Forms.NumericUpDown moveNumeric;
  }
}