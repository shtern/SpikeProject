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
    //private string FilePath = "";
      private List<Tuple<double, double>> DataToPlot;
      private List<Tuple<double, double>> SpikeList;
    private double threshold=0;
    public Form1()
    {
      InitializeComponent();

      DataToPlot = new List<Tuple<double, double>>();
      SpikeList = new List<Tuple<double, double>>();
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
            pictureBox1.Refresh();
            break;
          case System.Windows.Forms.DialogResult.Cancel:


            break;
        }
      }
    }
    private void loadData(string FilePath)
    {
        int spike_count = 0;
        int flag = 0;
        double dif = 0;
        threshold = 0.02;
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
          if (y > threshold)
          {
              if (flag == 0)
              {
                  spike_count++;
                  dif = x;
                  flag = 1;
              }
              Tuple<double, double> Spikedata = new Tuple<double, double>(x - dif, y);
              SpikeList.Add(Spikedata);
              Tuple<double, double> XYData = new Tuple<double, double>(x, y);
              DataToPlot.Add(XYData);
          }
          else flag = 0;

        }
      }
      textBox1.Text = Convert.ToString(spike_count);
    }

    private void SpikeGraph_Paint(object sender, PaintEventArgs e)
    {
      Brush brush = new SolidBrush(Color.Black);
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
      pictureBox1.Refresh();
    }



    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        Brush brush = new SolidBrush(Color.Black);
        Pen mainpen = new Pen(brush);
        foreach (Tuple<double, double> iterator in DataToPlot)
        {

        }

        for (int i = 1; i < SpikeList.Count; i++)
        {

            e.Graphics.DrawLine(mainpen,
              (float)SpikeList[i - 1].Item1 * 300,
              (float)(e.ClipRectangle.Height - SpikeList[i - 1].Item2 * 2000),
              (float)SpikeList[i].Item1 * 300,
              (float)(e.ClipRectangle.Height - SpikeList[i].Item2 * 2000));
        }
    }
  }
}
