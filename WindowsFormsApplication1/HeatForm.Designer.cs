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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeatForm));
      this.DGV = new System.Windows.Forms.DataGridView();
      this.DGV_Norm = new System.Windows.Forms.DataGridView();
      this.notnormLabel = new System.Windows.Forms.Label();
      this.normLabel = new System.Windows.Forms.Label();
      this.NoNormExcel = new System.Windows.Forms.Button();
      this.NormExcel = new System.Windows.Forms.Button();
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
      this.DGV.SelectionChanged += new System.EventHandler(this.DGV_SelectionChanged);
      // 
      // DGV_Norm
      // 
      this.DGV_Norm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.DGV_Norm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DGV_Norm.Location = new System.Drawing.Point(12, 500);
      this.DGV_Norm.Name = "DGV_Norm";
      this.DGV_Norm.Size = new System.Drawing.Size(720, 430);
      this.DGV_Norm.TabIndex = 1;
      this.DGV_Norm.SelectionChanged += new System.EventHandler(this.DGV_Norm_SelectionChanged);
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
      this.normLabel.Location = new System.Drawing.Point(13, 478);
      this.normLabel.Name = "normLabel";
      this.normLabel.Size = new System.Drawing.Size(97, 13);
      this.normLabel.TabIndex = 3;
      this.normLabel.Text = "С нормализацией";
      // 
      // NoNormExcel
      // 
      this.NoNormExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.NoNormExcel.Location = new System.Drawing.Point(657, 2);
      this.NoNormExcel.Name = "NoNormExcel";
      this.NoNormExcel.Size = new System.Drawing.Size(75, 23);
      this.NoNormExcel.TabIndex = 4;
      this.NoNormExcel.Text = "В Excel";
      this.NoNormExcel.UseVisualStyleBackColor = true;
      this.NoNormExcel.Click += new System.EventHandler(this.NoNormExcel_Click);
      // 
      // NormExcel
      // 
      this.NormExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.NormExcel.Location = new System.Drawing.Point(657, 471);
      this.NormExcel.Name = "NormExcel";
      this.NormExcel.Size = new System.Drawing.Size(75, 23);
      this.NormExcel.TabIndex = 5;
      this.NormExcel.Text = "В Excel";
      this.NormExcel.UseVisualStyleBackColor = true;
      this.NormExcel.Click += new System.EventHandler(this.NormExcel_Click);
      // 
      // HeatForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(744, 941);
      this.Controls.Add(this.NormExcel);
      this.Controls.Add(this.NoNormExcel);
      this.Controls.Add(this.normLabel);
      this.Controls.Add(this.notnormLabel);
      this.Controls.Add(this.DGV_Norm);
      this.Controls.Add(this.DGV);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "HeatForm";
      this.Text = "Карта спайковых характеристик";
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
    private System.Windows.Forms.Button NoNormExcel;
    private System.Windows.Forms.Button NormExcel;
  }
}