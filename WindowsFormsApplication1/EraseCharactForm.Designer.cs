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
      this.EraseButton.Location = new System.Drawing.Point(344, 212);
      this.EraseButton.Name = "EraseButton";
      this.EraseButton.Size = new System.Drawing.Size(136, 23);
      this.EraseButton.TabIndex = 0;
      this.EraseButton.Text = "Удалить выбранное";
      this.EraseButton.UseVisualStyleBackColor = true;
      this.EraseButton.Click += new System.EventHandler(this.EraseButton_Click);
      // 
      // EraseCancelButton
      // 
      this.EraseCancelButton.Location = new System.Drawing.Point(498, 212);
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
      this.NoStimCheckBox.Location = new System.Drawing.Point(50, 81);
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
      this.StimCheckBox.Location = new System.Drawing.Point(50, 146);
      this.StimCheckBox.Name = "StimCheckBox";
      this.StimCheckBox.Size = new System.Drawing.Size(121, 17);
      this.StimCheckBox.TabIndex = 5;
      this.StimCheckBox.Text = "После стимуляции";
      this.StimCheckBox.UseVisualStyleBackColor = true;
      this.StimCheckBox.CheckedChanged += new System.EventHandler(this.StimCheckBox_CheckedChanged);
      // 
      // StimDropText
      // 
      this.StimDropText.Enabled = false;
      this.StimDropText.Location = new System.Drawing.Point(344, 143);
      this.StimDropText.Name = "StimDropText";
      this.StimDropText.Size = new System.Drawing.Size(229, 20);
      this.StimDropText.TabIndex = 6;
      this.StimDropText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StimDropText_KeyDown);
      // 
      // NoStimDropText
      // 
      this.NoStimDropText.Enabled = false;
      this.NoStimDropText.Location = new System.Drawing.Point(344, 79);
      this.NoStimDropText.Name = "NoStimDropText";
      this.NoStimDropText.Size = new System.Drawing.Size(229, 20);
      this.NoStimDropText.TabIndex = 7;
      this.NoStimDropText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoStimDropText_KeyDown);
      // 
      // erasemainlabel
      // 
      this.erasemainlabel.AutoSize = true;
      this.erasemainlabel.Location = new System.Drawing.Point(112, 23);
      this.erasemainlabel.Name = "erasemainlabel";
      this.erasemainlabel.Size = new System.Drawing.Size(419, 26);
      this.erasemainlabel.TabIndex = 8;
      this.erasemainlabel.Text = "Отметьте галочкой, из какого набора характеристик Вы хотите удалить данные,\r\nи пе" +
    "речислите через точку с запятой их порядковые номера";
      // 
      // EraseCharactForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(604, 261);
      this.Controls.Add(this.erasemainlabel);
      this.Controls.Add(this.NoStimDropText);
      this.Controls.Add(this.StimDropText);
      this.Controls.Add(this.StimCheckBox);
      this.Controls.Add(this.NoStimCheckBox);
      this.Controls.Add(this.EraseCancelButton);
      this.Controls.Add(this.EraseButton);
      this.MaximumSize = new System.Drawing.Size(620, 300);
      this.MinimumSize = new System.Drawing.Size(620, 300);
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