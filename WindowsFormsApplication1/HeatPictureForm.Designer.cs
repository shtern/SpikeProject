namespace SpikeProject
{
  partial class HeatPictureForm
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
      this.notStimSpikes = new System.Windows.Forms.PictureBox();
      this.Panel = new System.Windows.Forms.Panel();
      this.exportButton = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.pictureBox2 = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.notStimSpikes)).BeginInit();
      this.Panel.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
      this.SuspendLayout();
      // 
      // notStimSpikes
      // 
      this.notStimSpikes.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.notStimSpikes.Location = new System.Drawing.Point(3, 3);
      this.notStimSpikes.Name = "notStimSpikes";
      this.notStimSpikes.Size = new System.Drawing.Size(730, 340);
      this.notStimSpikes.TabIndex = 0;
      this.notStimSpikes.TabStop = false;
      this.notStimSpikes.Paint += new System.Windows.Forms.PaintEventHandler(this.notStimSpikes_Paint);
      // 
      // Panel
      // 
      this.Panel.AutoScroll = true;
      this.Panel.Controls.Add(this.notStimSpikes);
      this.Panel.Location = new System.Drawing.Point(12, 12);
      this.Panel.Name = "Panel";
      this.Panel.Size = new System.Drawing.Size(689, 330);
      this.Panel.TabIndex = 1;
      this.Panel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Panel_Scroll);
      // 
      // exportButton
      // 
      this.exportButton.Location = new System.Drawing.Point(961, 118);
      this.exportButton.Name = "exportButton";
      this.exportButton.Size = new System.Drawing.Size(75, 23);
      this.exportButton.TabIndex = 2;
      this.exportButton.Text = "Export";
      this.exportButton.UseVisualStyleBackColor = true;
      this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
      // 
      // panel1
      // 
      this.panel1.AutoScroll = true;
      this.panel1.Controls.Add(this.pictureBox2);
      this.panel1.Location = new System.Drawing.Point(15, 395);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(689, 330);
      this.panel1.TabIndex = 3;
      // 
      // pictureBox2
      // 
      this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.pictureBox2.Location = new System.Drawing.Point(3, 3);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new System.Drawing.Size(730, 340);
      this.pictureBox2.TabIndex = 0;
      this.pictureBox2.TabStop = false;
      // 
      // HeatPictureForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1135, 807);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.exportButton);
      this.Controls.Add(this.Panel);
      this.Name = "HeatPictureForm";
      this.Text = "HeatPictureForm";
      ((System.ComponentModel.ISupportInitialize)(this.notStimSpikes)).EndInit();
      this.Panel.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox notStimSpikes;
    private System.Windows.Forms.Panel Panel;
    private System.Windows.Forms.Button exportButton;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.PictureBox pictureBox2;
  }
}