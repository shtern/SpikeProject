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
      bool done = false;
      if (NoStimCheckBox.Checked)
        try
        {
          nostimarr = NoStimDropText.Text.Split(';').Select(n => Convert.ToInt32(n)).ToArray();
        }
        catch
        {
            //MessageBox.Show("Один из индексов неверный", "Редактирование данных о характеристиках",
            //MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            done = false;
            
        }
      if (StimCheckBox.Checked)
        try
        {
           stimarr = StimDropText.Text.Split(';').Select(n => Convert.ToInt32(n)).ToArray();
        }
        catch
        {
            //MessageBox.Show("Один из индексов неверный", "Редактирование данных о характеристиках",
            //MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            done = false;
            
        }
      MainForm parent = (MainForm)this.Owner;
      if (nostimarr.Count() > 0 && nostimarr[0] >= 0)
      {
        Array.Sort(nostimarr);
        nostimarr = nostimarr.Distinct().ToArray();
        for (int i = 0; i < nostimarr.Count(); i++)
          if (nostimarr[i] - 1 - i >= 0 && nostimarr[i] - 1 - i < parent.NoStimSpikeList.Count && nostimarr[i] - 1 - i < parent.PeakList.Count)
          {
            done = true;
            parent.NoStimSpikeList.RemoveAt(nostimarr[i] - 1 - i);
            parent.PeakList.RemoveAt(nostimarr[i] - 1 - i);
          }
          else MessageBox.Show("Получен и проигнорирован неверный индекс", "Редактирование данных о характеристиках",
        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }

      if (stimarr.Count() > 0 && stimarr[0] >= 0)
      {
        Array.Sort(stimarr);
        stimarr = stimarr.Distinct().ToArray();
        for (int i = 0; i < stimarr.Count(); i++)
          if (stimarr[i] - 1 - i >= 0 && stimarr[i] - 1 - i < parent.StimSpikeList.Count && stimarr[i] - 1 - i + parent.NoStimSpikeList.Count < parent.PeakList.Count)
          {
            done = true;
            parent.StimSpikeList.RemoveAt(stimarr[i] - 1 - i);
            parent.PeakList.RemoveAt(stimarr[i] - 1 - i + parent.NoStimSpikeList.Count);
          }
          else MessageBox.Show("Получен и проигнорирован неверный индекс", "Редактирование данных о характеристиках",
          MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      parent.Refresh_Graphs();
      parent.RecountMaxScroll();
      if (done)
      this.Close();
      else
        MessageBox.Show("Один(или более) из индексов неверный, либо список удаления пуст", "Редактирование данных о характеристиках",
        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

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
        if (!StimDropText.Text.Equals(""))
          EraseButton.Focus();
        else EraseCancelButton.Focus();
    }

    private void NoStimDropText_KeyPress(object sender, KeyPressEventArgs e)
    {
      int isNum = 0;
      if (e.KeyChar == ';')
        e.Handled = false;
      else if (!int.TryParse(e.KeyChar.ToString(), out isNum) && !char.IsControl(e.KeyChar))
        e.Handled = true;
    }

    private void StimDropText_KeyPress(object sender, KeyPressEventArgs e)
    {
      int isNum = 0;
      if (e.KeyChar == ';')
        e.Handled = false;
      else if (!int.TryParse(e.KeyChar.ToString(), out isNum) && !char.IsControl(e.KeyChar))
        e.Handled = true;
    }
  }
}
