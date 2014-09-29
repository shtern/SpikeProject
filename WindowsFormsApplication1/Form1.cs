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
  using SpikeDataPacket = List<Tuple<double, double>>;
  using SpikeData = Tuple<double, double>;
  public partial class Form1 : Form
  {
    #region Константы
    private double threshold = 0.02;
    private string FilePath = "";
    private int KxTop = 10;
    private int KxBottom = 300;
    #endregion

    #region Данные класса
    private List<Tuple<double, double>> DataToPlot;
    private List<SpikeDataPacket> SpikeList;
    #endregion

    public Form1()
    {
      InitializeComponent();

      DataToPlot = new List<Tuple<double, double>>();
      SpikeList = new List<SpikeDataPacket>();
    }

    private void Load_Button_Click(object sender, EventArgs e)
    {
      using (OpenFileDialog dialog = new OpenFileDialog())
      {
        switch (dialog.ShowDialog())
        {
          case System.Windows.Forms.DialogResult.OK:
            FilePath = dialog.FileName;
            loadData(FilePath);

            SpikeGraph.Refresh();
            pictureBox1.Refresh();
            pictureBox2.Refresh();
            break;
          case System.Windows.Forms.DialogResult.Cancel:


            break;
        }
      }
    }

    private void loadData(string FilePath)
    {
      DataToPlot = new List<Tuple<double, double>>();
      SpikeList = new List<SpikeDataPacket>();
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

          Tuple<double, double> XYData = new Tuple<double, double>(x, y);
          DataToPlot.Add(XYData);
          if (y > threshold)
          {
            SpikeDataPacket currentSpike = new SpikeDataPacket();
            double ZeroPosition = x;

            currentSpike.Add(new SpikeData(x - ZeroPosition, y));
            
            while (sr.Peek() >= 0)
            {
              result = sr.ReadLine();
              resultxy = result.Split('\t');

              if (resultxy.Length != 2)
              {
                MessageBox.Show("Bad file exception!!!!!");
                break;
              }
              double.TryParse(resultxy[0], out x);
              double.TryParse(resultxy[1], out y);

              if (y < threshold) break;
              
              SpikeData Spikedata = new SpikeData(x - ZeroPosition, y);

              currentSpike.Add(Spikedata);
              XYData = new SpikeData(x, y);
              DataToPlot.Add(XYData);
            }
            SpikeList.Add(currentSpike);
          }


        }
      }
      textBox1.Text = ViewSpikeScroll.Value.ToString() + " / " + SpikeList.Count.ToString();
    }

    private void Form1_SizeChanged(object sender, EventArgs e)
    {
      SpikeGraph.Refresh();
      pictureBox1.Refresh(); 
      pictureBox2.Refresh();
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void pictureBox2_Paint(object sender, PaintEventArgs e)
    {
      Brush brush = new SolidBrush(Color.Black);
      Pen mainpen = new Pen(brush);
      foreach (Tuple<double, double> iterator in DataToPlot)
      {

      }
      for (int SpikeIdx = 11; SpikeIdx < SpikeList.Count && SpikeIdx <= ViewSpikeScroll.Value; SpikeIdx++)
      {
        for (int i = 1; i < SpikeList[SpikeIdx].Count; i++)
        {
          e.Graphics.DrawLine(mainpen,
            (float)SpikeList[SpikeIdx][i - 1].Item1 * KxBottom,
            (float)(e.ClipRectangle.Height - SpikeList[SpikeIdx][i - 1].Item2 * 2000),
            (float)SpikeList[SpikeIdx][i].Item1 * KxBottom,
            (float)(e.ClipRectangle.Height - SpikeList[SpikeIdx][i].Item2 * 2000));
        }
      }
    }

    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
      Brush brush = new SolidBrush(Color.Black);
      Pen mainpen = new Pen(brush);
      foreach (Tuple<double, double> iterator in DataToPlot)
      {

      }
      for (int SpikeIdx = 0; SpikeIdx < SpikeList.Count && SpikeIdx <= ViewSpikeScroll.Value && SpikeIdx<11; SpikeIdx++)
      {
        for (int i = 1; i < SpikeList[SpikeIdx].Count; i++)
        {
          e.Graphics.DrawLine(mainpen,
            (float)SpikeList[SpikeIdx][i - 1].Item1 * KxBottom,
            (float)(e.ClipRectangle.Height - SpikeList[SpikeIdx][i - 1].Item2 * 2000),
            (float)SpikeList[SpikeIdx][i].Item1 * KxBottom,
            (float)(e.ClipRectangle.Height - SpikeList[SpikeIdx][i].Item2 * 2000));
        }
      }
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
          (float)DataToPlot[i - 1].Item1 * KxTop,
          (float)(e.ClipRectangle.Height - DataToPlot[i - 1].Item2 * 1000),
          (float)DataToPlot[i].Item1 * KxTop,
          (float)(e.ClipRectangle.Height - DataToPlot[i].Item2 * 1000));
      }
      Brush threshholdbrush = new SolidBrush(Color.Red);
      Pen thresholdpen = new Pen(threshholdbrush);
      e.Graphics.DrawLine(thresholdpen, (float)0, (float)(e.ClipRectangle.Height - threshold * 1000), (float)e.ClipRectangle.Width, (float)(e.ClipRectangle.Height - threshold * 1000));
    }

    private void TopScroll_Scroll(object sender, EventArgs e)
    {
      KxTop = 1 + TopScroll.Value / 2;
      SpikeGraph.Refresh();
    }

    private void BottomScroll_Scroll(object sender, EventArgs e)
    {
      KxBottom = 50 + BottomScroll.Value * 10;
      pictureBox1.Refresh();
      pictureBox2.Refresh();
    }

    private void ViewSpikeScroll_Scroll(object sender, EventArgs e)
    {
      pictureBox1.Refresh();
      pictureBox2.Refresh();
      textBox1.Text = ViewSpikeScroll.Value.ToString() + " / " + SpikeList.Count.ToString();
    }

    private void Threshold_Scroll_Scroll(object sender, EventArgs e)
    {
      threshold =(double) Threshold_Scroll.Value / 100;
      if (FilePath!="")
      loadData(FilePath);

      SpikeGraph.Refresh();
      pictureBox1.Refresh();
      pictureBox2.Refresh();

    }


  }
}
