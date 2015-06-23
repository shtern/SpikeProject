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
      this.compareLabel = new System.Windows.Forms.Label();
      this.moveNumeric = new System.Windows.Forms.NumericUpDown();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.отображатьСоСдвигомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.compareZedGraph = new ZedGraph.ZedGraphControl();
      this.normalizedCompareZedGraph = new ZedGraph.ZedGraphControl();
      this.CorrValueText = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.moveNumeric)).BeginInit();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // compareLabel
      // 
      this.compareLabel.AutoSize = true;
      this.compareLabel.Location = new System.Drawing.Point(13, 33);
      this.compareLabel.Name = "compareLabel";
      this.compareLabel.Size = new System.Drawing.Size(306, 13);
      this.compareLabel.TabIndex = 2;
      this.compareLabel.Text = "Сравнение средних до стимуляции и во время стимуляции";
      this.compareLabel.Visible = false;
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
      this.отображатьСоСдвигомToolStripMenuItem.Name = "отображатьСоСдвигомToolStripMenuItem";
      this.отображатьСоСдвигомToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
      this.отображатьСоСдвигомToolStripMenuItem.Text = "Двигать характеристики";
      this.отображатьСоСдвигомToolStripMenuItem.Click += new System.EventHandler(this.отображатьСоСдвигомToolStripMenuItem_Click);
      // 
      // compareZedGraph
      // 
      this.compareZedGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.compareZedGraph.Location = new System.Drawing.Point(9, 58);
      this.compareZedGraph.Name = "compareZedGraph";
      this.compareZedGraph.ScrollGrace = 0D;
      this.compareZedGraph.ScrollMaxX = 0D;
      this.compareZedGraph.ScrollMaxY = 0D;
      this.compareZedGraph.ScrollMaxY2 = 0D;
      this.compareZedGraph.ScrollMinX = 0D;
      this.compareZedGraph.ScrollMinY = 0D;
      this.compareZedGraph.ScrollMinY2 = 0D;
      this.compareZedGraph.Size = new System.Drawing.Size(750, 360);
      this.compareZedGraph.TabIndex = 6;
      // 
      // normalizedCompareZedGraph
      // 
      this.normalizedCompareZedGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.normalizedCompareZedGraph.Location = new System.Drawing.Point(9, 424);
      this.normalizedCompareZedGraph.Name = "normalizedCompareZedGraph";
      this.normalizedCompareZedGraph.ScrollGrace = 0D;
      this.normalizedCompareZedGraph.ScrollMaxX = 0D;
      this.normalizedCompareZedGraph.ScrollMaxY = 0D;
      this.normalizedCompareZedGraph.ScrollMaxY2 = 0D;
      this.normalizedCompareZedGraph.ScrollMinX = 0D;
      this.normalizedCompareZedGraph.ScrollMinY = 0D;
      this.normalizedCompareZedGraph.ScrollMinY2 = 0D;
      this.normalizedCompareZedGraph.Size = new System.Drawing.Size(750, 360);
      this.normalizedCompareZedGraph.TabIndex = 7;
      // 
      // CorrValueText
      // 
      this.CorrValueText.AutoSize = true;
      this.CorrValueText.Location = new System.Drawing.Point(580, 33);
      this.CorrValueText.Name = "CorrValueText";
      this.CorrValueText.Size = new System.Drawing.Size(118, 13);
      this.CorrValueText.TabIndex = 3;
      this.CorrValueText.Text = "Значение корелляции";
      this.CorrValueText.Visible = false;
      // 
      // FCompareForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(767, 796);
      this.Controls.Add(this.normalizedCompareZedGraph);
      this.Controls.Add(this.compareZedGraph);
      this.Controls.Add(this.moveNumeric);
      this.Controls.Add(this.CorrValueText);
      this.Controls.Add(this.compareLabel);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.MinimumSize = new System.Drawing.Size(783, 806);
      this.Name = "FCompareForm";
      this.Text = "Сравнение спайковых характеристик";
      ((System.ComponentModel.ISupportInitialize)(this.moveNumeric)).EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label compareLabel;
    private System.Windows.Forms.NumericUpDown moveNumeric;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem отображатьСоСдвигомToolStripMenuItem;
    private ZedGraph.ZedGraphControl compareZedGraph;
    private ZedGraph.ZedGraphControl normalizedCompareZedGraph;
    private System.Windows.Forms.Label CorrValueText;
  }
}