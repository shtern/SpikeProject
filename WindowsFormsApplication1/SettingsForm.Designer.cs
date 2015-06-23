namespace SpikeProject
{
  partial class SettingsForm
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
      this.savebutton = new System.Windows.Forms.Button();
      this.cancelbutton = new System.Windows.Forms.Button();
      this.cellcolllbl = new System.Windows.Forms.Label();
      this.cellCount = new System.Windows.Forms.NumericUpDown();
      this.charactcountlbl = new System.Windows.Forms.Label();
      this.charactCount = new System.Windows.Forms.NumericUpDown();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.corrMethodsBox = new System.Windows.Forms.ComboBox();
      this.moveCharactLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.cellCount)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.charactCount)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // savebutton
      // 
      this.savebutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.savebutton.Location = new System.Drawing.Point(238, 248);
      this.savebutton.Name = "savebutton";
      this.savebutton.Size = new System.Drawing.Size(75, 23);
      this.savebutton.TabIndex = 0;
      this.savebutton.Text = "Сохранить";
      this.savebutton.UseVisualStyleBackColor = true;
      this.savebutton.Click += new System.EventHandler(this.savebutton_Click);
      // 
      // cancelbutton
      // 
      this.cancelbutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelbutton.Location = new System.Drawing.Point(338, 248);
      this.cancelbutton.Name = "cancelbutton";
      this.cancelbutton.Size = new System.Drawing.Size(75, 23);
      this.cancelbutton.TabIndex = 1;
      this.cancelbutton.Text = "Отменить";
      this.cancelbutton.UseVisualStyleBackColor = true;
      this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
      // 
      // cellcolllbl
      // 
      this.cellcolllbl.AutoSize = true;
      this.cellcolllbl.Location = new System.Drawing.Point(26, 36);
      this.cellcolllbl.Name = "cellcolllbl";
      this.cellcolllbl.Size = new System.Drawing.Size(107, 13);
      this.cellcolllbl.TabIndex = 3;
      this.cellcolllbl.Text = "Количество клеток:";
      // 
      // cellCount
      // 
      this.cellCount.Location = new System.Drawing.Point(326, 36);
      this.cellCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.cellCount.Name = "cellCount";
      this.cellCount.Size = new System.Drawing.Size(51, 20);
      this.cellCount.TabIndex = 4;
      this.cellCount.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
      // 
      // charactcountlbl
      // 
      this.charactcountlbl.AutoSize = true;
      this.charactcountlbl.Location = new System.Drawing.Point(26, 101);
      this.charactcountlbl.Name = "charactcountlbl";
      this.charactcountlbl.Size = new System.Drawing.Size(234, 13);
      this.charactcountlbl.TabIndex = 5;
      this.charactcountlbl.Text = "Количество спайковых хар-к до стимуляции:";
      // 
      // charactCount
      // 
      this.charactCount.Location = new System.Drawing.Point(326, 99);
      this.charactCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.charactCount.Name = "charactCount";
      this.charactCount.Size = new System.Drawing.Size(51, 20);
      this.charactCount.TabIndex = 6;
      this.charactCount.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.corrMethodsBox);
      this.groupBox1.Controls.Add(this.moveCharactLabel);
      this.groupBox1.Controls.Add(this.cellCount);
      this.groupBox1.Controls.Add(this.charactCount);
      this.groupBox1.Controls.Add(this.cellcolllbl);
      this.groupBox1.Controls.Add(this.charactcountlbl);
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(401, 214);
      this.groupBox1.TabIndex = 7;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Параметры клеток";
      // 
      // corrMethodsBox
      // 
      this.corrMethodsBox.FormattingEnabled = true;
      this.corrMethodsBox.Items.AddRange(new object[] {
            "Коэффициент Пирсона",
            "Коэффициент Пирсона со сдвигами",
            "Кросс-корреляция"});
      this.corrMethodsBox.Location = new System.Drawing.Point(226, 159);
      this.corrMethodsBox.Name = "corrMethodsBox";
      this.corrMethodsBox.Size = new System.Drawing.Size(151, 21);
      this.corrMethodsBox.TabIndex = 9;
      // 
      // moveCharactLabel
      // 
      this.moveCharactLabel.AutoSize = true;
      this.moveCharactLabel.Location = new System.Drawing.Point(26, 162);
      this.moveCharactLabel.Name = "moveCharactLabel";
      this.moveCharactLabel.Size = new System.Drawing.Size(151, 13);
      this.moveCharactLabel.TabIndex = 7;
      this.moveCharactLabel.Text = "Метод подсчета корелляции";
      // 
      // SettingsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(434, 282);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.cancelbutton);
      this.Controls.Add(this.savebutton);
      this.MaximumSize = new System.Drawing.Size(450, 320);
      this.MinimumSize = new System.Drawing.Size(450, 320);
      this.Name = "SettingsForm";
      this.Text = "Настройки";
      ((System.ComponentModel.ISupportInitialize)(this.cellCount)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.charactCount)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button savebutton;
    private System.Windows.Forms.Button cancelbutton;
    private System.Windows.Forms.Label cellcolllbl;
    private System.Windows.Forms.NumericUpDown cellCount;
    private System.Windows.Forms.Label charactcountlbl;
    private System.Windows.Forms.NumericUpDown charactCount;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label moveCharactLabel;
    private System.Windows.Forms.ComboBox corrMethodsBox;
  }
}