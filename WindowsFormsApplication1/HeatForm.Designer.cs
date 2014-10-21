namespace SpikeProject
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
      this.DGV_Norm = new System.Windows.Forms.DataGridView();
      this.notnormLabel = new System.Windows.Forms.Label();
      this.normLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.DGV_Norm)).BeginInit();
      this.SuspendLayout();
      // 
      // DGV
      // 
      this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DGV.Location = new System.Drawing.Point(12, 31);
      this.DGV.Name = "DGV";
      this.DGV.Size = new System.Drawing.Size(720, 430);
      this.DGV.TabIndex = 0;
      this.DGV.VisibleChanged += new System.EventHandler(this.DGV_VisibleChanged);
      // 
      // DGV_Norm
      // 
      this.DGV_Norm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.DGV_Norm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DGV_Norm.Location = new System.Drawing.Point(12, 491);
      this.DGV_Norm.Name = "DGV_Norm";
      this.DGV_Norm.Size = new System.Drawing.Size(720, 430);
      this.DGV_Norm.TabIndex = 1;
      // 
      // notnormLabel
      // 
      this.notnormLabel.AutoSize = true;
      this.notnormLabel.Location = new System.Drawing.Point(13, 12);
      this.notnormLabel.Name = "notnormLabel";
      this.notnormLabel.Size = new System.Drawing.Size(103, 13);
      this.notnormLabel.TabIndex = 2;
      this.notnormLabel.Text = "Без нормализации";
      // 
      // normLabel
      // 
      this.normLabel.AutoSize = true;
      this.normLabel.Location = new System.Drawing.Point(13, 475);
      this.normLabel.Name = "normLabel";
      this.normLabel.Size = new System.Drawing.Size(97, 13);
      this.normLabel.TabIndex = 3;
      this.normLabel.Text = "С нормализацией";
      // 
      // HeatForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(744, 941);
      this.Controls.Add(this.normLabel);
      this.Controls.Add(this.notnormLabel);
      this.Controls.Add(this.DGV_Norm);
      this.Controls.Add(this.DGV);
      this.Name = "HeatForm";
      this.Text = "Карта спайковых характеристик";
      this.Load += new System.EventHandler(this.HeatForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.DGV_Norm)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataGridView DGV;
    private System.Windows.Forms.DataGridView DGV_Norm;
    private System.Windows.Forms.Label notnormLabel;
    private System.Windows.Forms.Label normLabel;
  }
}