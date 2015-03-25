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
      if (parent.NoStimSpikeList.Count > 0 && NoStimCheckBox.Checked) NoStimDropText.Enabled = true;
      else NoStimDropText.Enabled = false;
      //if (MainForm.NoStimSpikeList.Count>0) 
    }

    private void StimCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      MainForm parent = (MainForm)this.Owner;
      if (parent.StimSpikeList.Count > 0 && StimCheckBox.Checked) StimDropText.Enabled = true;
      else StimDropText.Enabled = false;
    }

    private void EraseButton_Click(object sender, EventArgs e)
    {
      int[] nostimarr = {-1}, stimarr={-1};
      if (NoStimCheckBox.Checked)
      nostimarr = NoStimDropText.Text.Split(';').Select(n => Convert.ToInt32(n)).ToArray();
      if (StimCheckBox.Checked)
      stimarr = StimDropText.Text.Split(';').Select(n => Convert.ToInt32(n)).ToArray();
      
      MainForm parent = (MainForm)this.Owner;
      if (nostimarr.Count() > 0 && nostimarr[0] >= 0)
        for (int i = 0; i < nostimarr.Count(); i++)
          parent.NoStimSpikeList.RemoveAt(nostimarr[i]-1-i);

      if (stimarr.Count() > 0 && stimarr[0] >= 0)
        for (int i = 0; i < stimarr.Count(); i++)
          parent.StimSpikeList.RemoveAt(stimarr[i]-1-i);

      parent.Refresh_Graphs();
      this.Close();

    }

    private void NoStimDropText_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
        if (StimDropText.Enabled)
          StimDropText.Focus();
        else
          if (!NoStimDropText.Text.Equals(""))
            EraseButton.Focus();
          else EraseCancelButton.Focus();
    }

    private void StimDropText_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
        if (!NoStimDropText.Text.Equals(""))
          EraseButton.Focus();
        else EraseCancelButton.Focus();
    }
  }
}
