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
      ((System.ComponentModel.ISupportInitialize)(this.CompareGraph)).BeginInit();
      this.SuspendLayout();
      // 
      // CompareGraph
      // 
      this.CompareGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.CompareGraph.BackColor = System.Drawing.Color.White;
      this.CompareGraph.Location = new System.Drawing.Point(12, 12);
      this.CompareGraph.Name = "CompareGraph";
      this.CompareGraph.Size = new System.Drawing.Size(816, 390);
      this.CompareGraph.TabIndex = 0;
      this.CompareGraph.TabStop = false;
      this.CompareGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.CompareGraph_Paint);
      // 
      // FCompareForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(840, 414);
      this.Controls.Add(this.CompareGraph);
      this.Name = "FCompareForm";
      this.Text = "FCompareForm";
      ((System.ComponentModel.ISupportInitialize)(this.CompareGraph)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox CompareGraph;
  }
}