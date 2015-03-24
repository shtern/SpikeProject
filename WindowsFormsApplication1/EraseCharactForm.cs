using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpikeProject
{
  public partial class EraseCharactForm : Form
  {
    public EraseCharactForm()
    {
      InitializeComponent();
    }

    private void EraseCancelButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void NoStimCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      MainForm parent = (MainForm)this.Owner;
      if (parent.NoStimSpikeList.Count > 0 && NoStimCheckBox.Checked) StimDropText.Enabled = true;
      else StimDropText.Enabled = false;
      //if (MainForm.NoStimSpikeList.Count>0) 
    }
  }
}
