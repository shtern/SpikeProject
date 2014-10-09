namespace WindowsFormsApplication1
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
      ((System.ComponentModel.ISupportInitialize)(this.CompareGraph)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.NormalizedGraph)).BeginInit();
      this.SuspendLayout();
      // 
      // CompareGraph
      // 
      this.CompareGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)));
      this.CompareGraph.BackColor = System.Drawing.Color.White;
      this.CompareGraph.Location = new System.Drawing.Point(12, 12);
      this.CompareGraph.Name = "CompareGraph";
      this.CompareGraph.Size = new System.Drawing.Size(745, 412);
      this.CompareGraph.TabIndex = 0;
      this.CompareGraph.TabStop = false;
      this.CompareGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.CompareGraph_Paint);
      // 
      // NormalizedGraph
      // 
      this.NormalizedGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.NormalizedGraph.BackColor = System.Drawing.Color.White;
      this.NormalizedGraph.Location = new System.Drawing.Point(768, 12);
      this.NormalizedGraph.Name = "NormalizedGraph";
      this.NormalizedGraph.Size = new System.Drawing.Size(745, 412);
      this.NormalizedGraph.TabIndex = 1;
      this.NormalizedGraph.TabStop = false;
      this.NormalizedGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.NormalizedGraph_Paint);
      // 
      // FCompareForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1524, 436);
      this.Controls.Add(this.NormalizedGraph);
      this.Controls.Add(this.CompareGraph);
      this.Name = "FCompareForm";
      this.Text = "FCompareForm";
      ((System.ComponentModel.ISupportInitialize)(this.CompareGraph)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.NormalizedGraph)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox CompareGraph;
    private System.Windows.Forms.PictureBox NormalizedGraph;
  }
}