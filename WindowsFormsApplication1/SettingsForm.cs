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
  public partial class SettingsForm : Form
  {
    public SettingsForm()
    {
      InitializeComponent();
      cellCount.Value = Properties.Settings.Default.cellcount;
      charactCount.Value = Properties.Settings.Default.stimstart;
      corrMethodsBox.SelectedIndex = Properties.Settings.Default.methodtype;
    }

    private void cancelbutton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void savebutton_Click(object sender, EventArgs e)
    {
      Properties.Settings.Default.cellcount = (int)cellCount.Value;
      MainForm.cellCount = (int)cellCount.Value;
      Properties.Settings.Default.stimstart = (int)charactCount.Value;
      MainForm.nostimcount = (int)charactCount.Value;
      Properties.Settings.Default.methodtype = corrMethodsBox.SelectedIndex;
      Properties.Settings.Default.Save();
      if (corrMethodsBox.SelectedIndex == 1) Properties.Settings.Default.moveforcorr = true;
      else Properties.Settings.Default.moveforcorr = false;
      this.Close();
    }



  }
}
