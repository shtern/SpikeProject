﻿namespace SpikeProject
{
  partial class HeatForm
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
      this.DGV = new System.Windows.Forms.DataGridView();
      ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
      this.SuspendLayout();
      // 
      // DGV
      // 
      this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DGV.Location = new System.Drawing.Point(12, 12);
      this.DGV.Name = "DGV";
      this.DGV.Size = new System.Drawing.Size(1160, 738);
      this.DGV.TabIndex = 0;
      this.DGV.VisibleChanged += new System.EventHandler(this.DGV_VisibleChanged);
      // 
      // HeatForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1184, 762);
      this.Controls.Add(this.DGV);
      this.Name = "HeatForm";
      this.Text = "HeatForm";
      this.Load += new System.EventHandler(this.HeatForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView DGV;
  }
}