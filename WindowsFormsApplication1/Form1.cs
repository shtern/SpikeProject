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
  using PointList = List<PointF>;
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
    private List<PointF> PointsList;
    private List<PointList> AveragePointsStim = new List<PointList>();
    private List<PointList> AveragePointsNoStim = new List<PointList>();
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
        dialog.FileName = "Cell_1.txt";
        dialog.InitialDirectory = Application.StartupPath + @"";
        switch (dialog.ShowDialog())
        {
          case System.Windows.Forms.DialogResult.OK:
            FilePath = dialog.FileName;
            loadData(FilePath);

            SpikeGraph.Refresh();
            NoStimCharacter.Refresh();
            StimCharacter.Refresh();
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
      AveragePointsStim = new List<PointList>();
      AveragePointsNoStim = new List<PointList>();
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
            double ZeroPositionX = ApproxX(DataToPlot[DataToPlot.Count - 2].Item1, DataToPlot[DataToPlot.Count - 2].Item2, x, y);
            currentSpike.Add(new SpikeData(x - ZeroPositionX, y - threshold));

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

              SpikeData Spikedata = new SpikeData(x - ZeroPositionX, y - threshold);

              currentSpike.Add(Spikedata);
              XYData = new SpikeData(x, y);
              DataToPlot.Add(XYData);
            }
            if(currentSpike.Count > 30) SpikeList.Add(currentSpike);
          }
        }
      }
      if (SpikeList.Count > 11)
      {
        numericNoStim.Maximum = 10;
        numericAfterStim.Maximum = (SpikeList.Count - 11);
        buildAverage(true, AveragePointsNoStim);
        buildAverage(false, AveragePointsStim);
      }
      else
      {
        numericAfterStim.Maximum = 0;
        numericNoStim.Maximum = 0;
      }

    }

    private void FindSpikeChar()
    {

    }

    private void buildAverage(bool first, List<PointList> TargetAverageList)
    {
      double maxLenght = 0;
      double minLength = 0;
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
      for (int z = down_border + 1; z < up_border && z < SpikeList.Count; z++)
      {
        minLength = SpikeList.Last().Last().Item1;
        for (int i = down_border; i < up_border && i < z && i < SpikeList.Count; i++)
        {
          if (SpikeList[i].Last().Item1 < minLength) minLength = SpikeList[i].Last().Item1;
          if (SpikeList[i].Last().Item1 > maxLenght) maxLenght = SpikeList[i].Last().Item1;
        }

        double StepWidth = 0.001;
        PointsList = new PointList();
        for (double x = StepWidth; x < minLength; x += StepWidth)
        {

          double Average = 0;
          int count = 0;
          for (int j = down_border; j < up_border && j < z && j < SpikeList.Count; j++)
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
          if (count > 0 && Average > eps)
          {
            Average /= count;
            if (Average > threshold)
              PointsList.Add(new PointF((float)x * KxBottom, (float)(StimCharacter.Height - Average * 2000)));
          }
        }
        TargetAverageList.Add(PointsList);
      }

    }

    private double ApproxX(double x0, double y0, double x1, double y1)
    {
      // zero fix
      if (x1 == x0) x0 += 1.1e-12;

      double k = (y1 - y0) / (x1 - x0);
      double b = y0 - k * x0;
      double targetx = 0;
      targetx = (threshold - b) / k;

      return targetx;
    }

    private void Form1_SizeChanged(object sender, EventArgs e)
    {
      SpikeGraph.Refresh();
      NoStimCharacter.Refresh();
      StimCharacter.Refresh();
    }

    private void StimCharacter_Paint(object sender, PaintEventArgs e)
    {
      Brush brush = new SolidBrush(Color.Black);
      Pen mainpen = new Pen(brush);
      for (int SpikeIdx = 11; SpikeIdx < SpikeList.Count && SpikeIdx <= numericAfterStim.Value + 10; SpikeIdx++)
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
      if (AveragePointsStim.Count > 0 && numericAfterStim.Value - 1 > 0 && numericAfterStim.Value < AveragePointsStim.Count)
      {
        PointF[] AverageList = (AveragePointsStim[(int)numericAfterStim.Value - 1]).ToArray();
        if (AverageList.Count() > 1) e.Graphics.DrawLines(mainpen, AverageList);
      }

    }

    private void NoStimCharacter_Paint(object sender, PaintEventArgs e)
    {
      Brush brush = new SolidBrush(Color.Black);
      Pen mainpen = new Pen(brush);
      for (int SpikeIdx = 0; SpikeIdx < SpikeList.Count && SpikeIdx < numericNoStim.Value && SpikeIdx < 11; SpikeIdx++)
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
      brush = new SolidBrush(Color.BlueViolet);
      mainpen = new Pen(brush, 3);
      if (AveragePointsNoStim.Count > 0 && numericNoStim.Value - 1 > 0)
      {
        PointF[] AverageList = (AveragePointsNoStim[(int)numericNoStim.Value - 1]).ToArray();
        if (AverageList.Count() > 0) e.Graphics.DrawLines(mainpen, AverageList);
      }

    }

    private void SpikeGraph_Paint(object sender, PaintEventArgs e)
    {
      Brush brush = new SolidBrush(Color.Black);
      Pen mainpen = new Pen(brush);

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
      NoStimCharacter.Refresh();
      StimCharacter.Refresh();
    }

    private void Threshold_Scroll_Scroll(object sender, EventArgs e)
    {
      
    }

    private void numericNo_ValueChanged(object sender, EventArgs e)
    {
      NoStimCharacter.Refresh();
    }

    private void numericAfterStim_ValueChanged(object sender, EventArgs e)
    {
      StimCharacter.Refresh();
    }

    private void compareButton_Click(object sender, EventArgs e)
    {
      FCompareForm compareForm = new FCompareForm(AveragePointsNoStim[(int)numericNoStim.Value-1], AveragePointsStim[(int)numericAfterStim.Value-1]);
      compareForm.Show();
    }

    private void Threshold_Scroll_ValueChanged(object sender, EventArgs e)
    {
      threshold = (double)Threshold_Scroll.Value / 1000;
      if (FilePath != "")
        loadData(FilePath);
      if (SpikeList.Count > 0)
      {
        SpikeGraph.Refresh();
        NoStimCharacter.Refresh();
        StimCharacter.Refresh();
      }

    }


  }
}
