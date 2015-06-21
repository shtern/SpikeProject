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
      this.components = new System.ComponentModel.Container();
      this.CompareGraph = new System.Windows.Forms.PictureBox();
      this.NormalizedGraph = new System.Windows.Forms.PictureBox();
      this.compareLabel = new System.Windows.Forms.Label();
      this.NormalizedLabel = new System.Windows.Forms.Label();
      this.moveNumeric = new System.Windows.Forms.NumericUpDown();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.отображатьСоСдвигомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.compareZedGraph = new ZedGraph.ZedGraphControl();
      this.normalizedCompareZedGraph = new ZedGraph.ZedGraphControl();
      ((System.ComponentModel.ISupportInitialize)(this.CompareGraph)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.NormalizedGraph)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.moveNumeric)).BeginInit();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // CompareGraph
      // 
      this.CompareGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.CompareGraph.BackColor = System.Drawing.Color.White;
      this.CompareGraph.Location = new System.Drawing.Point(12, 57);
      this.CompareGraph.Name = "CompareGraph";
      this.CompareGraph.Size = new System.Drawing.Size(745, 342);
      this.CompareGraph.TabIndex = 0;
      this.CompareGraph.TabStop = false;
      this.CompareGraph.Visible = false;
      this.CompareGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.CompareGraph_Paint);
      // 
      // NormalizedGraph
      // 
      this.NormalizedGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.NormalizedGraph.BackColor = System.Drawing.Color.White;
      this.NormalizedGraph.Location = new System.Drawing.Point(12, 442);
      this.NormalizedGraph.Name = "NormalizedGraph";
      this.NormalizedGraph.Size = new System.Drawing.Size(745, 342);
      this.NormalizedGraph.TabIndex = 1;
      this.NormalizedGraph.TabStop = false;
      this.NormalizedGraph.Visible = false;
      this.NormalizedGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.NormalizedGraph_Paint);
      // 
      // compareLabel
      // 
      this.compareLabel.AutoSize = true;
      this.compareLabel.Location = new System.Drawing.Point(13, 33);
      this.compareLabel.Name = "compareLabel";
      this.compareLabel.Size = new System.Drawing.Size(306, 13);
      this.compareLabel.TabIndex = 2;
      this.compareLabel.Text = "Сравнение средних до стимуляции и во время стимуляции";
      // 
      // NormalizedLabel
      // 
      this.NormalizedLabel.AutoSize = true;
      this.NormalizedLabel.Location = new System.Drawing.Point(13, 417);
      this.NormalizedLabel.Name = "NormalizedLabel";
      this.NormalizedLabel.Size = new System.Drawing.Size(265, 13);
      this.NormalizedLabel.TabIndex = 3;
      this.NormalizedLabel.Text = "Сравнение средних, нормированных по амплитуде";
      // 
      // moveNumeric
      // 
      this.moveNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.moveNumeric.Location = new System.Drawing.Point(717, 31);
      this.moveNumeric.Name = "moveNumeric";
      this.moveNumeric.Size = new System.Drawing.Size(40, 20);
      this.moveNumeric.TabIndex = 4;
      this.moveNumeric.Visible = false;
      this.moveNumeric.ValueChanged += new System.EventHandler(this.moveNum_ValueChanged);
      // 
      // menuStrip1
      // 
      this.menuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(767, 24);
      this.menuStrip1.TabIndex = 5;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // настройкиToolStripMenuItem
      // 
      this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отображатьСоСдвигомToolStripMenuItem});
      this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
      this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
      this.настройкиToolStripMenuItem.Text = "Настройки";
      // 
      // отображатьСоСдвигомToolStripMenuItem
      // 
      this.отображатьСоСдвигомToolStripMenuItem.Checked = true;
      this.отображатьСоСдвигомToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.отображатьСоСдвигомToolStripMenuItem.Name = "отображатьСоСдвигомToolStripMenuItem";
      this.отображатьСоСдвигомToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
      this.отображатьСоСдвигомToolStripMenuItem.Text = "Отображать со сдвигом";
      // 
      // compareZedGraph
      // 
      this.compareZedGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.compareZedGraph.Location = new System.Drawing.Point(12, 57);
      this.compareZedGraph.Name = "compareZedGraph";
      this.compareZedGraph.ScrollGrace = 0D;
      this.compareZedGraph.ScrollMaxX = 0D;
      this.compareZedGraph.ScrollMaxY = 0D;
      this.compareZedGraph.ScrollMaxY2 = 0D;
      this.compareZedGraph.ScrollMinX = 0D;
      this.compareZedGraph.ScrollMinY = 0D;
      this.compareZedGraph.ScrollMinY2 = 0D;
      this.compareZedGraph.Size = new System.Drawing.Size(745, 342);
      this.compareZedGraph.TabIndex = 6;
      // 
      // normalizedCompareZedGraph
      // 
      this.normalizedCompareZedGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.normalizedCompareZedGraph.Location = new System.Drawing.Point(12, 442);
      this.normalizedCompareZedGraph.Name = "normalizedCompareZedGraph";
      this.normalizedCompareZedGraph.ScrollGrace = 0D;
      this.normalizedCompareZedGraph.ScrollMaxX = 0D;
      this.normalizedCompareZedGraph.ScrollMaxY = 0D;
      this.normalizedCompareZedGraph.ScrollMaxY2 = 0D;
      this.normalizedCompareZedGraph.ScrollMinX = 0D;
      this.normalizedCompareZedGraph.ScrollMinY = 0D;
      this.normalizedCompareZedGraph.ScrollMinY2 = 0D;
      this.normalizedCompareZedGraph.Size = new System.Drawing.Size(745, 342);
      this.normalizedCompareZedGraph.TabIndex = 7;
      // 
      // FCompareForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(767, 796);
      this.Controls.Add(this.normalizedCompareZedGraph);
      this.Controls.Add(this.compareZedGraph);
      this.Controls.Add(this.moveNumeric);
      this.Controls.Add(this.NormalizedLabel);
      this.Controls.Add(this.compareLabel);
      this.Controls.Add(this.NormalizedGraph);
      this.Controls.Add(this.CompareGraph);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.MinimumSize = new System.Drawing.Size(783, 806);
      this.Name = "FCompareForm";
      this.Text = "Сравнение спайковых характеристик";
      ((System.ComponentModel.ISupportInitialize)(this.CompareGraph)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.NormalizedGraph)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.moveNumeric)).EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox CompareGraph;
    private System.Windows.Forms.PictureBox NormalizedGraph;
    private System.Windows.Forms.Label compareLabel;
    private System.Windows.Forms.Label NormalizedLabel;
    private System.Windows.Forms.NumericUpDown moveNumeric;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem отображатьСоСдвигомToolStripMenuItem;
    private ZedGraph.ZedGraphControl compareZedGraph;
    private ZedGraph.ZedGraphControl normalizedCompareZedGraph;
  }
}