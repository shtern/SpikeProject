namespace SpikeProject
{
  partial class EraseCharactForm
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
      this.EraseButton = new System.Windows.Forms.Button();
      this.EraseCancelButton = new System.Windows.Forms.Button();
      this.NoStimCheckBox = new System.Windows.Forms.CheckBox();
      this.StimCheckBox = new System.Windows.Forms.CheckBox();
      this.StimDropText = new System.Windows.Forms.TextBox();
      this.NoStimDropText = new System.Windows.Forms.TextBox();
      this.erasemainlabel = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // EraseButton
      // 
      this.EraseButton.Location = new System.Drawing.Point(344, 306);
      this.EraseButton.Name = "EraseButton";
      this.EraseButton.Size = new System.Drawing.Size(75, 23);
      this.EraseButton.TabIndex = 0;
      this.EraseButton.Text = "Удалить";
      this.EraseButton.UseVisualStyleBackColor = true;
      // 
      // EraseCancelButton
      // 
      this.EraseCancelButton.Location = new System.Drawing.Point(498, 306);
      this.EraseCancelButton.Name = "EraseCancelButton";
      this.EraseCancelButton.Size = new System.Drawing.Size(75, 23);
      this.EraseCancelButton.TabIndex = 1;
      this.EraseCancelButton.Text = "Отмена";
      this.EraseCancelButton.UseVisualStyleBackColor = true;
      this.EraseCancelButton.Click += new System.EventHandler(this.EraseCancelButton_Click);
      // 
      // NoStimCheckBox
      // 
      this.NoStimCheckBox.AutoSize = true;
      this.NoStimCheckBox.Location = new System.Drawing.Point(50, 111);
      this.NoStimCheckBox.Name = "NoStimCheckBox";
      this.NoStimCheckBox.Size = new System.Drawing.Size(104, 17);
      this.NoStimCheckBox.TabIndex = 4;
      this.NoStimCheckBox.Text = "До стимуляции";
      this.NoStimCheckBox.UseVisualStyleBackColor = true;
      this.NoStimCheckBox.CheckedChanged += new System.EventHandler(this.NoStimCheckBox_CheckedChanged);
      // 
      // StimCheckBox
      // 
      this.StimCheckBox.AutoSize = true;
      this.StimCheckBox.Location = new System.Drawing.Point(50, 176);
      this.StimCheckBox.Name = "StimCheckBox";
      this.StimCheckBox.Size = new System.Drawing.Size(121, 17);
      this.StimCheckBox.TabIndex = 5;
      this.StimCheckBox.Text = "После стимуляции";
      this.StimCheckBox.UseVisualStyleBackColor = true;
      // 
      // StimDropText
      // 
      this.StimDropText.Enabled = false;
      this.StimDropText.Location = new System.Drawing.Point(344, 111);
      this.StimDropText.Name = "StimDropText";
      this.StimDropText.Size = new System.Drawing.Size(229, 20);
      this.StimDropText.TabIndex = 6;
      // 
      // NoStimDropText
      // 
      this.NoStimDropText.Enabled = false;
      this.NoStimDropText.Location = new System.Drawing.Point(344, 176);
      this.NoStimDropText.Name = "NoStimDropText";
      this.NoStimDropText.Size = new System.Drawing.Size(229, 20);
      this.NoStimDropText.TabIndex = 7;
      // 
      // erasemainlabel
      // 
      this.erasemainlabel.AutoSize = true;
      this.erasemainlabel.Location = new System.Drawing.Point(173, 26);
      this.erasemainlabel.Name = "erasemainlabel";
      this.erasemainlabel.Size = new System.Drawing.Size(35, 13);
      this.erasemainlabel.TabIndex = 8;
      this.erasemainlabel.Text = "label1";
      // 
      // EraseCharactForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(604, 362);
      this.Controls.Add(this.erasemainlabel);
      this.Controls.Add(this.NoStimDropText);
      this.Controls.Add(this.StimDropText);
      this.Controls.Add(this.StimCheckBox);
      this.Controls.Add(this.NoStimCheckBox);
      this.Controls.Add(this.EraseCancelButton);
      this.Controls.Add(this.EraseButton);
      this.MaximumSize = new System.Drawing.Size(620, 400);
      this.MinimumSize = new System.Drawing.Size(620, 400);
      this.Name = "EraseCharactForm";
      this.Text = "Удалить характеристики";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button EraseButton;
    private System.Windows.Forms.Button EraseCancelButton;
    private System.Windows.Forms.CheckBox NoStimCheckBox;
    private System.Windows.Forms.CheckBox StimCheckBox;
    private System.Windows.Forms.TextBox StimDropText;
    private System.Windows.Forms.TextBox NoStimDropText;
    private System.Windows.Forms.Label erasemainlabel;
  }
}