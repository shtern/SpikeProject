using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.IO;

namespace SpikeProject
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
    int nostimcount = 11;
    #endregion

    #region Данные класса
    private SpikeDataPacket GlobalData;
    private List<SpikeDataPacket> MegaMapList = new List<SpikeDataPacket>();
    private List<SpikeDataPacket> StimSpikeList;
    private List<SpikeDataPacket> NoStimSpikeList;
    private List<PointF> DrawPointsList;
    private List<PointF> PointsList;
    private List<PointList> AverageDrawPointsStim = new List<PointList>();
    private List<PointList> AverageDrawPointsNoStim = new List<PointList>();
    private List<PointList> AveragePointsStim = new List<PointList>();
    private List<PointList> AveragePointsNoStim = new List<PointList>();
    #endregion

    public Form1()
    {
      InitializeComponent();

      threshold = (double)Threshold_Scroll.Value / 1000;
      GlobalData = new List<Tuple<double, double>>();
      StimSpikeList = new List<SpikeDataPacket>();
      NoStimSpikeList = new List<SpikeDataPacket>();
    }

    private void Load_Button_Click(object sender, EventArgs e)
    {
      using (OpenFileDialog dialog = new OpenFileDialog())
      {
        MegaMapList = new List<SpikeDataPacket>();
        dialog.FileName = "Cell_1.txt";
        dialog.Multiselect = true;
        dialog.InitialDirectory = Application.StartupPath + @"\..\..";
        switch (dialog.ShowDialog())
        {
          case System.Windows.Forms.DialogResult.OK:
            foreach (String path in dialog.FileNames)
            {
              FilePath = path;
              cellName.Text = System.IO.Path.GetFileNameWithoutExtension(dialog.FileName);
              loadData(FilePath);
              SpikeGraph.Refresh();
              NoStimCharacter.Refresh();
              StimCharacter.Refresh();
            }
              break;
            
          case System.Windows.Forms.DialogResult.Cancel:


            break;
        }
      }
    }


    private void loadData(string FilePath)
    {
      GlobalData = new List<Tuple<double, double>>();
      StimSpikeList = new List<SpikeDataPacket>();
      NoStimSpikeList = new List<SpikeDataPacket>();
      AverageDrawPointsStim = new List<PointList>();
      AverageDrawPointsNoStim = new List<PointList>();
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
          string[] resultxy2 = result.Split('\t');
          resultxy2[0] = resultxy[0].Replace(",", ".");
          resultxy2[1] = resultxy[1].Replace(",", ".");
          double parsevar = 0;
          double.TryParse("3,5", out parsevar);
          if (parsevar == 3.5)
          {
            double.TryParse(resultxy[0], out x);
            double.TryParse(resultxy[1], out y);
          }
          else
          {
            double.TryParse(resultxy2[0], out x);
            double.TryParse(resultxy2[1], out y);
          }
          Tuple<double, double> XYData = new Tuple<double, double>(x, y);
          GlobalData.Add(XYData);
        }
      }
      MegaMapList.Add(thresholdCheck(GlobalData));
      if (MegaMapList.Count == 13)
      {
        HeatPictureForm hpf = new HeatPictureForm(MegaMapList, "MegaMap");
        hpf.Show();
       // HeatForm hf = new HeatForm(MegaMapList, "MegaMap");
       // hf.Show();
      }
      buildCharactList();
      buildNoStimAverage();
      buildStimAverage();
    }

    private void buildCharactList()
    {
      for (int i = 1; i < GlobalData.Count; i++)
      {
        double x = GlobalData[i].Item1, y = GlobalData[i].Item2;
        if (y > threshold)
        {
          SpikeDataPacket currentSpike = new SpikeDataPacket();
          double ZeroPositionX = ApproxX(GlobalData[i - 1].Item1, GlobalData[i - 1].Item2, x, y);
          currentSpike.Add(new SpikeData(0, 0));
          while (y > threshold && i < GlobalData.Count)
          {
            if (y < threshold) break;
            x = GlobalData[i].Item1;
            y = GlobalData[i].Item2;
            SpikeData Spikedata = new SpikeData(x - ZeroPositionX, y - threshold);
            if (y - threshold > eps)
              currentSpike.Add(Spikedata);
            i++;
          }
          if (currentSpike.Count > 10 && currentSpike.Count(s => s.Item2 > 1.4 * threshold) > 10)
          {
            if (NoStimSpikeList.Count < nostimcount) NoStimSpikeList.Add(currentSpike);
            else StimSpikeList.Add(currentSpike);
          }
        }
      }
      numericNoStim.Maximum = NoStimSpikeList.Count;
      numericAfterStim.Maximum = StimSpikeList.Count;
      numericNoStim.Value = NoStimSpikeList.Count;
      numericAfterStim.Value = StimSpikeList.Count;
    }

    private void buildNoStimAverage()
    {
      double maxLenght = 0;
      double minLength = 0;
      for (int z = 0; z < NoStimSpikeList.Count; z++)
      {
        minLength = NoStimSpikeList.First().Last().Item1;
        for (int i = 0; i <= z && i < NoStimSpikeList.Count; i++)
        {
          if (NoStimSpikeList[i].Last().Item1 < minLength) minLength = NoStimSpikeList[i].Last().Item1;
          if (NoStimSpikeList[i].Last().Item1 > maxLenght) maxLenght = NoStimSpikeList[i].Last().Item1;
        }

        double StepWidth = 1e-3;
        DrawPointsList = new PointList();
        PointsList = new PointList();
        for (double x = (NoStimSpikeList[0] != null && NoStimSpikeList[0].Count > 1) ? NoStimSpikeList[0][0].Item1 : eps; x < minLength; x += StepWidth)
        {
          double Average = 0;
          int count = 0;
          for (int j = 0; j <= z && j < NoStimSpikeList.Count; j++)
          {
            SpikeDataPacket data = NoStimSpikeList[j];
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

            double k = (_y[1] - _y[0]) / ((_x[1] - _x[0]) > eps ? (_x[1] - _x[0]) : eps);
            double b = _y[0] - k * _x[0];
            double y = k * x + b;
            Average += y;
            count++;
          }
          if (count > eps && Average > eps)
          {
            Average /= count;
            PointsList.Add(new PointF((float)x, (float)Average));
            DrawPointsList.Add(new PointF((float)x * KxBottom, (float)(NoStimCharacter.Height - Average * 2000)));
          }
        }
        AveragePointsNoStim.Add(PointsList);
        AverageDrawPointsNoStim.Add(DrawPointsList);
      }

    }

    private void buildStimAverage()
    {
      double maxLenght = 0;
      double minLength = 0;

      for (int z = 0; z < StimSpikeList.Count; z++)
      {
        minLength = StimSpikeList.First().Last().Item1;
        for (int i = 0; i <= z && i < StimSpikeList.Count; i++)
        {
          if (StimSpikeList[i].Last().Item1 < minLength) minLength = StimSpikeList[i].Last().Item1;
          if (StimSpikeList[i].Last().Item1 > maxLenght) maxLenght = StimSpikeList[i].Last().Item1;
        }

        double StepWidth = 1e-3;
        DrawPointsList = new PointList();
        PointsList = new PointList();
        for (double x = (StimSpikeList[0] != null && StimSpikeList[0].Count > 1) ? StimSpikeList[0][0].Item1 : eps; x < minLength; x += StepWidth)
        {
          double Average = 0;
          int count = 0;
          for (int j = 0; j <= z && j < StimSpikeList.Count; j++)
          {
            SpikeDataPacket data = StimSpikeList[j];
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
            if (Math.Abs(_x[1]) > eps && Math.Abs(_y[1]) > eps)
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
            PointsList.Add(new PointF((float)x, (float)Average));
            DrawPointsList.Add(new PointF((float)x * KxBottom, (float)(StimCharacter.Height - Average * 2000)));
          }
        }
        AveragePointsStim.Add(PointsList);
        AverageDrawPointsStim.Add(DrawPointsList);
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
      for (int SpikeIdx = 0; SpikeIdx < StimSpikeList.Count && SpikeIdx < numericAfterStim.Value; SpikeIdx++)
      {
        for (int i = 1; i < StimSpikeList[SpikeIdx].Count; i++)
        {
          int Ciferka = 9;
          brush = new SolidBrush((Color.FromArgb((byte)(200 - Ciferka * (StimSpikeList.Count - SpikeIdx)), (byte)(200 - Ciferka * (StimSpikeList.Count - SpikeIdx)), (byte)(200 - Ciferka * (StimSpikeList.Count - SpikeIdx)))));
          mainpen = new Pen(brush, 2);
          e.Graphics.DrawLine(mainpen,
            (float)StimSpikeList[SpikeIdx][i - 1].Item1 * KxBottom,
            (float)(e.ClipRectangle.Height - StimSpikeList[SpikeIdx][i - 1].Item2 * 2000),
            (float)StimSpikeList[SpikeIdx][i].Item1 * KxBottom,
            (float)(e.ClipRectangle.Height - StimSpikeList[SpikeIdx][i].Item2 * 2000));
        }
      }


      brush = new SolidBrush(Color.Aqua);
      mainpen = new Pen(brush, 5);
      if (AverageDrawPointsStim.Count > 0 && numericAfterStim.Value >= 0 && numericAfterStim.Value <= AverageDrawPointsStim.Count && AvgCheckBox.Checked == true)
      {
        PointF[] AverageList = (AverageDrawPointsStim[(int)numericAfterStim.Value - 1]).ToArray();
        if (AverageList.Count() > 1) e.Graphics.DrawLines(mainpen, AverageList);
      }

    }

    private void NoStimCharacter_Paint(object sender, PaintEventArgs e)
    {
      Brush brush = new SolidBrush(Color.Black);
      Pen mainpen = new Pen(brush);
      for (int SpikeIdx = 0; SpikeIdx < NoStimSpikeList.Count && SpikeIdx < numericNoStim.Value && SpikeIdx < 11; SpikeIdx++)
      {
        for (int i = 1; i < NoStimSpikeList[SpikeIdx].Count; i++)
        {
          int Ciferka = 9;
          brush = new SolidBrush((Color.FromArgb((byte)(200 - Ciferka * (StimSpikeList.Count - SpikeIdx)), (byte)(200 - Ciferka * (StimSpikeList.Count - SpikeIdx)), (byte)(200 - Ciferka * (StimSpikeList.Count - SpikeIdx)))));
          mainpen = new Pen(brush, 2);
          e.Graphics.DrawLine(mainpen,
            (float)NoStimSpikeList[SpikeIdx][i - 1].Item1 * KxBottom,
            (float)(e.ClipRectangle.Height - NoStimSpikeList[SpikeIdx][i - 1].Item2 * 2000),
            (float)NoStimSpikeList[SpikeIdx][i].Item1 * KxBottom,
            (float)(e.ClipRectangle.Height - NoStimSpikeList[SpikeIdx][i].Item2 * 2000));
        }
      }

      brush = new SolidBrush(Color.Blue);
      mainpen = new Pen(brush, 5);
      if (AverageDrawPointsNoStim.Count > 0 && numericNoStim.Value >= 0 && AvgCheckBox.Checked == true)
      {
        PointF[] AverageList = (AverageDrawPointsNoStim[(int)numericNoStim.Value - 1]).ToArray();

        if (AverageList.Count() > 0) e.Graphics.DrawLines(mainpen, AverageList);
      }

    }

    private void SpikeGraph_Paint(object sender, PaintEventArgs e)
    {
      Brush brush = new SolidBrush(Color.Black);
      Pen mainpen = new Pen(brush);

      for (int i = 1; i < GlobalData.Count; i++)
      {

        e.Graphics.DrawLine(mainpen,
          (float)GlobalData[i - 1].Item1 * KxTop,
          (float)(e.ClipRectangle.Height - GlobalData[i - 1].Item2 * 1000),
          (float)GlobalData[i].Item1 * KxTop,
          (float)(e.ClipRectangle.Height - GlobalData[i].Item2 * 1000));
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
      if (AverageDrawPointsNoStim.Count > 0 && AverageDrawPointsStim.Count > 0 && AvgCheckBox.Checked == true)
      {
        FCompareForm compareForm = new FCompareForm(AveragePointsNoStim[(int)numericNoStim.Value - 1], AveragePointsStim[(int)numericAfterStim.Value - 1]);
        compareForm.Show();
      }
      else
      {
        MessageBox.Show("Нечего отображать", "Сравнение характеристик",
        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void Threshold_Scroll_ValueChanged(object sender, EventArgs e)
    {
      threshold = (double)Threshold_Scroll.Value / 1000;
      if (FilePath != "")
        loadData(FilePath);
      if (NoStimSpikeList.Count > 0)
      {
        numericAfterStim.Value = numericAfterStim.Maximum;
        numericNoStim.Value = numericNoStim.Maximum;
        SpikeGraph.Refresh();
        NoStimCharacter.Refresh();
        StimCharacter.Refresh();
      }

    }

    private void AvgCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      NoStimCharacter.Refresh();
      StimCharacter.Refresh();
    }
   

    private void Threshold_Scroll_MouseUp(object sender, MouseEventArgs e)
    {
      threshold = (double)Threshold_Scroll.Value / 1000;
      if (FilePath != "")
        loadData(FilePath);
      if (NoStimSpikeList.Count > 0)
      {
        numericAfterStim.Value = numericAfterStim.Maximum;
        numericNoStim.Value = numericNoStim.Maximum;
        SpikeGraph.Refresh();
        NoStimCharacter.Refresh();
        StimCharacter.Refresh();
      }

    }

    private void NoStimCharacter_Click(object sender, EventArgs e)
    {
      if (NoStimSpikeList.Count > 0)
      {
        HeatPictureForm hpf = new HeatPictureForm(NoStimSpikeList, cellName.Text);
        hpf.Show();
        HeatForm hf = new HeatForm(NoStimSpikeList, cellName.Text);
        hf.Show();
      }
    }

    private void StimCharacter_Click(object sender, EventArgs e)
    {
      if (StimSpikeList.Count > 0)
      {
        HeatPictureForm hpf = new HeatPictureForm(StimSpikeList, cellName.Text);
        hpf.Show();
        HeatForm hf = new HeatForm(StimSpikeList, cellName.Text);
        hf.Show();
      }
    }

    private SpikeDataPacket thresholdCheck(SpikeDataPacket list)
    {
      SpikeDataPacket resultList = new SpikeDataPacket();
      for (int i = 0; i < list.Count; i++)
        if (list[i].Item2 > threshold)
          resultList.Add(list[i]);
      return resultList;
    }
    private void mapButton_Click(object sender, EventArgs e)
    {
      if (NoStimSpikeList.Count > 0 && StimSpikeList.Count > 0)
      {
        List<SpikeDataPacket> MapList = new List<SpikeDataPacket>();
        MapList.AddRange(NoStimSpikeList);
        SpikeDataPacket separator = new SpikeDataPacket();
        separator.Add(new Tuple<double, double>(0, 0));
        MapList.Add(separator);
        MapList.Add(separator);
        MapList.AddRange(StimSpikeList);

        HeatPictureForm hpf = new HeatPictureForm(MapList,cellName.Text);
        hpf.Show();
        HeatForm hf = new HeatForm(MapList, cellName.Text);
        hf.Show();
      }
      else
      {
        MessageBox.Show("Нечего отображать", "Карта спайковых характеристик",
        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }


  }
}
