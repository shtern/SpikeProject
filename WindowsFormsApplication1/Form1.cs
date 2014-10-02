using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
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
    double eps = 1e-20;
    #endregion

    #region Данные класса
    private List<Tuple<double, double>> DataToPlot;
    private List<SpikeDataPacket> SpikeList;
  
    #endregion

    public Form1()
    {
      InitializeComponent();
      threshold = (double)Threshold_Scroll.Value / 1000;
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

    private List<Tuple<double, double>> buildAverage(bool first)
    {
      List<Tuple<double, double>> AverageList = new List<Tuple<double, double>>();
      double maxLenght = 0;
      int down_border = 0;
      int up_border = SpikeList.Count;
      if (first == true)
      {
        down_border = 0;
        up_border = 11;
      }
      else
      {
        down_border = 11;
        up_border = SpikeList.Count;
      }

      for (int i = down_border; i < up_border && i < ViewSpikeScroll.Value && i < SpikeList.Count; i++)
      {
        if (SpikeList[i].Last().Item1 > maxLenght) maxLenght = SpikeList[i].Last().Item1;
      }

      double StepWidth = 0.001;
      List<double> average = new List<double>();
      AverageList = new List<Tuple<double, double>>();
      for (double x = StepWidth; x < maxLenght; x += StepWidth)
      {
        double Average = 0;
        int count = 0;
        for (int j = down_border; j < up_border && j < ViewSpikeScroll.Value && j < SpikeList.Count; j++)
        //foreach (SpikeDataPacket data in SpikeList)
        {
          SpikeDataPacket data = SpikeList[j];
          double[] _x = new double[2];
          double[] _y = new double[2];
          for (int i = 0; i < data.Count; i++)
          {
            if (data[i].Item1 <= x)
            {
              _x[0] = data[i].Item1;
              _y[0] = data[i].Item2;
            }
            if (data[i].Item1 >= x)
            {
              _x[1] = data[i].Item1;
              _y[1] = data[i].Item2;
              break;

            }

          }
          if (Math.Abs(_x[0]) > eps && Math.Abs(_y[0]) > eps && Math.Abs(_x[1]) > eps && Math.Abs(_y[1]) > eps)
          {
            double k = (_y[1] - _y[0]) / (_x[1] - _x[0]);
            double b = _y[0] - k * _x[0];
            double y = k * x + b;
            Average += y;
            count++;
          }
        }
        if (count > 0)
          Average /= count;
        AverageList.Add(new Tuple<double, double>(x, Average));
      }
      return AverageList;
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


      brush = new SolidBrush(Color.Aqua);
      mainpen = new Pen(brush, 3);
      List<Tuple<double, double>> AverageList = buildAverage(false);
      for (int i = 1; i < AverageList.Count; i++)
      {
        e.Graphics.DrawLine(mainpen,
          (float)AverageList[i - 1].Item1 * KxBottom,
          (float)(e.ClipRectangle.Height - AverageList[i - 1].Item2 * 2000),
          (float)AverageList[i].Item1 * KxBottom,
          (float)(e.ClipRectangle.Height - AverageList[i].Item2 * 2000));
      }
       
    }

    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
      Brush brush = new SolidBrush(Color.Black);
      Pen mainpen = new Pen(brush);
      for (int SpikeIdx = 0; SpikeIdx < SpikeList.Count && SpikeIdx <= ViewSpikeScroll.Value && SpikeIdx < 11; SpikeIdx++)
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
      List<Tuple<double, double>> AverageList = buildAverage(true);
      brush = new SolidBrush(Color.Aqua);
      mainpen = new Pen(brush, 3);
      for (int i = 1; i < AverageList.Count; i++)
      {
        e.Graphics.DrawLine(mainpen,
          (float)AverageList[i - 1].Item1 * KxBottom,
          (float)(e.ClipRectangle.Height - AverageList[i - 1].Item2 * 2000),
          (float)AverageList[i].Item1 * KxBottom,
          (float)(e.ClipRectangle.Height - AverageList[i].Item2 * 2000));
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
      threshold = (double)Threshold_Scroll.Value / 1000;
      if (FilePath != "")
        loadData(FilePath);

      SpikeGraph.Refresh();
      pictureBox1.Refresh();
      pictureBox2.Refresh();

    }




  }
}
