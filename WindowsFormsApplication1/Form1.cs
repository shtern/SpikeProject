using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
  public partial class Form1 : Form
  {
    private string FilePath = "";
    private List<Tuple<double, double>> DataToPlot;
    public Form1()
    {
      InitializeComponent();

      DataToPlot = new List<Tuple<double, double>>();
    }

    private void Load_Button_Click(object sender, EventArgs e)
    {
      using (OpenFileDialog dialog = new OpenFileDialog())
      {
        switch (dialog.ShowDialog())
        {
          case System.Windows.Forms.DialogResult.OK:

            loadData(dialog.FileName);

            SpikeGraph.Refresh();
            break;
          case System.Windows.Forms.DialogResult.Cancel:


            break;
        }
      }
    }
    private void loadData(string FilePath)
    {
      using (StreamReader sr = new StreamReader(FilePath))
      {
        while (sr.Peek() >= 0)
        {
          string result = sr.ReadLine();
          double x, y;
          string[] resultxy = result.Split('\t');
          if (resultxy.Length != 2)
          {
            MessageBox.Show("Bad file exception!!!!!");
            break;
          }
          double.TryParse(resultxy[0], out x);
          double.TryParse(resultxy[1], out y);
          Tuple<double, double> XYdata = new Tuple<double, double>(x, y);

          DataToPlot.Add(XYdata);

        }
      }
    }

    private void SpikeGraph_Paint(object sender, PaintEventArgs e)
    {
      Brush brush = new SolidBrush(Color.DeepSkyBlue);
      Pen mainpen = new Pen(brush);
      foreach (Tuple<double, double> iterator in DataToPlot)
      {
        
      }
      for (int i = 1; i < DataToPlot.Count; i++)
      {
        e.Graphics.DrawLine(mainpen,
          (float)DataToPlot[i - 1].Item1 * 10,
          (float)(e.ClipRectangle.Height - DataToPlot[i - 1].Item2 * 1000),
          (float)DataToPlot[i].Item1 * 10,
          (float)(e.ClipRectangle.Height - DataToPlot[i].Item2 * 1000));
      }
    }

    private void Form1_SizeChanged(object sender, EventArgs e)
    {
      SpikeGraph.Refresh();
    }
  }
}
