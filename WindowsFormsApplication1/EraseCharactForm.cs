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
          if (nostimarr[i] - 1 - i >= 0 && nostimarr[i] - 1 - i < parent.NoStimSpikeList.Count && nostimarr[i] - 1 - i<parent.PeakList.Count)
          {
            parent.NoStimSpikeList.RemoveAt(nostimarr[i] - 1 - i);
            parent.PeakList.RemoveAt(nostimarr[i] - 1 - i);
          }
          else MessageBox.Show("Один из индексов неверный", "Редактирование данных о характеристиках",
        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

      if (stimarr.Count() > 0 && stimarr[0] >= 0)
        for (int i = 0; i < stimarr.Count(); i++)
          if (stimarr[i] - 1 - i >= 0 && stimarr[i] - 1 - i < parent.StimSpikeList.Count && nostimarr[i] - 1 - i < parent.PeakList.Count)
          {
            parent.StimSpikeList.RemoveAt(stimarr[i] - 1 - i);
            parent.PeakList.RemoveAt(stimarr[i] - 1 - i + parent.NoStimSpikeList.Count);
          }
          else MessageBox.Show("Один из индексов неверный", "Редактирование данных о характеристиках",
          MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      parent.Refresh_Graphs();
      parent.RecountMaxScroll();
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
