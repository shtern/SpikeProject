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
  using SpikePeakList = List<Tuple<int,int, double, double>>;
  using PointList = List<PointF>;
  public partial class MainForm : Form
  {
    #region Константы
    private double threshold = 0.02;
    private double initthreshold = 0;
    private string FilePath = "";
    private int KyTop = 1000;
    private int KyBottom = 1000;
    private int LeftMedian = 0;
    private int RightMedian = 0;
    private int KxTop = 10;
    private int KxBottom = 300;
    double eps = 1e-20;
    double GlobalMin = Double.MaxValue;
    double GlobalMax = Double.MinValue;
    public static int nostimcount { get; set; }
    public static int cellCount {get; set;}
    #endregion

    #region Данные класса
    private SpikeDataPacket GlobalData;
    private List<SpikeDataPacket> MegaMapList = new List<SpikeDataPacket>();
    private List<SpikeDataPacket> MegaMapStimList = new List<SpikeDataPacket>();
    private List<SpikeDataPacket> MegaMapNoStimList = new List<SpikeDataPacket>();
    private List<SpikeDataPacket> MegaMapStimMax = new List<SpikeDataPacket>();
    private List<SpikeDataPacket> MegaMapNoStimMax = new List<SpikeDataPacket>();
    private List<SpikeDataPacket> StimSpikeList;
    private List<SpikeDataPacket> NoStimSpikeList;
    private List<PointF> DrawPointsList;
    private List<PointF> PointsList;
    private List<PointList> AverageDrawPointsStim = new List<PointList>();
    private List<PointList> AverageDrawPointsNoStim = new List<PointList>();
    private List<PointList> AveragePointsStim = new List<PointList>();
    private List<PointList> AveragePointsNoStim = new List<PointList>();
    private SpikePeakList PeakList = new SpikePeakList();
    private List<int> WidthList = new List<int>();
    #endregion

    public MainForm()
    {
      InitializeComponent();
      cellCount = Properties.Settings.Default.cellcount;
      nostimcount = Properties.Settings.Default.stimstart;
      KeyPreview = true;
      threshold = (double)Threshold_Scroll.Value / 1000;
      GlobalData = new List<Tuple<double, double>>();
      StimSpikeList = new List<SpikeDataPacket>();
      NoStimSpikeList = new List<SpikeDataPacket>();
    }

    private void loadDialogOpen(int megacheck)
    {
      using (OpenFileDialog dialog = new OpenFileDialog())
      {
        MegaMapList = new List<SpikeDataPacket>();
        MegaMapStimList = new List<SpikeDataPacket>();
        MegaMapNoStimList = new List<SpikeDataPacket>();
        MegaMapStimMax = new List<SpikeDataPacket>();
        MegaMapNoStimMax = new List<SpikeDataPacket>();
        PeakList = new SpikePeakList();
        WidthList = new List<int>();
        dialog.FileName = "Cell_1.txt";
        if (megacheck == 1) dialog.FileName="\"Cell_13\" \"Cell_1\" \"Cell_2\" \"Cell_3\" \"Cell_4\" \"Cell_5\" \"Cell_6\" \"Cell_7\" \"Cell_8\" \"Cell_9\" \"Cell_10\" \"Cell_11\" \"Cell_12\" ";
        dialog.Multiselect = true;
        dialog.InitialDirectory = Application.StartupPath + @"\..\..";
        switch (dialog.ShowDialog())
        {
          case System.Windows.Forms.DialogResult.OK:
            foreach (String path in dialog.FileNames)
            {
              FilePath = path;
              cellName.Text = System.IO.Path.GetFileNameWithoutExtension(dialog.FileName);
              loadData(FilePath,megacheck);
            }
            break;

          case System.Windows.Forms.DialogResult.Cancel:
            break;
        }
      }
    }

    private void loadData(string FilePath, int megacheck)
    {
      int zerocount = 0;
      GlobalMin = Double.MaxValue;
      GlobalMax = Double.MinValue;
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
            double.TryParse(resultxy[0].Replace(".", ","), out x);
            double.TryParse(resultxy[1].Replace(".", ","), out y);
          }
          else
          {
            double.TryParse(resultxy2[0], out x);
            double.TryParse(resultxy2[1], out y);
          }
          Tuple<double, double> XYData = new Tuple<double, double>(x, y);
          if (XYData.Item2 <= 0) zerocount++;
          GlobalData.Add(XYData);
        }

      }

      if (zerocount < 0.3 * GlobalData.Count) GlobalData.RemoveAll(s => s.Item2 <= 0);  

      foreach (SpikeData data in GlobalData)
      {
        if (data.Item2 > GlobalMax) GlobalMax = data.Item2;
        if (data.Item2 < GlobalMin) GlobalMin = data.Item2;
      }

      for (int i = 0; i < GlobalData.Count; i++)
        GlobalData[i] = new SpikeData(GlobalData[i].Item1, GlobalData[i].Item2 - GlobalMin);
      GlobalMax -= GlobalMin;
      GlobalMin = 0;
      threshold = countThreshold();
      initthreshold = threshold;
      if (megacheck == 1)
      {
        MegaMapList.Add((GlobalData));
        if (MegaMapList.Count == cellCount)
        {
          buildMegaLists();
        }
      }
      else
      {
        buildCharactList();
        buildNoStimAverage();
        buildStimAverage();
        SpikeGraph.Refresh();
        NoStimCharacter.Refresh();
        StimCharacter.Refresh();
      }
    }


    private void buildMegaLists()
    {
      MegaMapStimList = new List<SpikeDataPacket>();
      MegaMapNoStimList = new List<SpikeDataPacket>();
      MegaMapStimMax = new List<SpikeDataPacket>();
      MegaMapNoStimMax = new List<SpikeDataPacket>();
      for (int i = 0; i < MegaMapList.Count; i++)
      {
        MegaMapNoStimList.Add(new SpikeDataPacket());
        MegaMapStimList.Add(new SpikeDataPacket());
        MegaMapNoStimMax.Add(new SpikeDataPacket());
        MegaMapStimMax.Add(new SpikeDataPacket());
        int CountVar=0;
        for (int j = 1; j< MegaMapList[i].Count; j++)
        {
          //int CountVar = 0;
          SpikeData max = new SpikeData(eps,eps);
          SpikeData packet = MegaMapList[i][j];
          double x = packet.Item1, y = packet.Item2;
          if (y > threshold)
          {
            SpikeDataPacket currentSpike = new SpikeDataPacket();
            currentSpike.Add(new SpikeData(x, y));
            while (y > threshold && j < MegaMapList[i].Count)
            {
              if (y < threshold) break;
              x = MegaMapList[i][j].Item1;
              y = MegaMapList[i][j].Item2;
              if (y > max.Item2) max = new SpikeData(x,y);
              SpikeData Spikedata = new SpikeData(x , y);
              if (y > eps)
                currentSpike.Add(Spikedata);
              j++;
            }
            if (currentSpike.Count > nostimcount)// && currentSpike.Count(s => s.Item2 > 1.4 * threshold) > nostimcount)
            {
              CountVar++;
              if (CountVar < nostimcount) { MegaMapNoStimList[i].AddRange(currentSpike); MegaMapNoStimMax[i].Add(max); }
              else { MegaMapStimList[i].AddRange(currentSpike); MegaMapStimMax[i].Add(max); }
            }
          }
        }
        SpikeDataPacket zeropacket = new SpikeDataPacket();
        zeropacket.Add(new SpikeData(0, 0));
        zeropacket.Add(new SpikeData(0, 0));
        zeropacket.Add(new SpikeData(0, 0));
        zeropacket.Add(new SpikeData(0, 0));
        zeropacket.Add(new SpikeData(0, 0));
        if (MegaMapNoStimList[i].Count < 2) MegaMapNoStimList[i].AddRange(zeropacket);
        if (MegaMapStimList[i].Count < 2) MegaMapStimList[i].AddRange(zeropacket);

      }
      HeatPictureForm hpf = new HeatPictureForm(MegaMapNoStimList, MegaMapStimList, MegaMapNoStimMax, MegaMapStimMax);
      hpf.Show();
    }

    public double countAverage(SpikeDataPacket packet)
    {
      if (packet.Count > 0)
      {
        double sum = 0;
        for (int i = 0; i < packet.Count; i++)
          sum += packet[i].Item2;
        return sum / packet.Count;
      }
      else return 0;

    }

    public SpikeDataPacket movePacket(SpikeDataPacket packet1, SpikeDataPacket packet2)
    {
      double max1=double.MinValue;
      double max_x1 = 0;
      double max2 = double.MinValue;
      double max_x2 = 0;
      foreach (SpikeData data in packet1)
      {
        if (data.Item2 > max1)
        {
          max1 = data.Item2;
          max_x1 = data.Item1;
        }
      }

      foreach (SpikeData data in packet2)
      {
        if (data.Item2 > max2)
        {
          max2 = data.Item2;
          max_x2 = data.Item1;
        }
      }

      double diff = max_x1 - max_x2;
      SpikeDataPacket resultpacket = new SpikeDataPacket();
      foreach (SpikeData data in packet2)
        resultpacket.Add(new SpikeData(data.Item1+diff, data.Item2));
      return resultpacket;


    }

    public double countArea(SpikeData point1, SpikeData point2)
    {
      double area = 0;
      if (point1.Item2 > point2.Item2)
        area = (point2.Item1 - point1.Item1) * (point1.Item2 - 1 / 2 * (point1.Item2 - point2.Item2));
      else
        area = (point2.Item1 - point1.Item1) * (point1.Item2 - 1 / 2 * (point2.Item2 - point1.Item2));
      return area;

    }

    public double countCorrArr(SpikeDataPacket packet1, SpikeDataPacket packet2)
    {
      packet2 = movePacket(packet1, packet2);
      double area1 = 0;
      double area2 = 0;
      for (int i = 1; i < packet1.Count; i++)
        area1 += countArea(packet1[i - 1], packet1[i]);
      for (int i = 1; i < packet2.Count; i++)
        area2 += countArea(packet2[i - 1], packet2[i]);
      if (area1 > area2)
        return 2 * (area1 - area2) / (area1 + area2);
      else return 2 * (area2 - area1) / (area1 + area2);

    }


 


    private void buildCharactList()
    {
      
      for (int i = 1; i < GlobalData.Count; i++)
      {
        double x = GlobalData[i].Item1, y = GlobalData[i].Item2;
        double x_max = 0, y_max = double.MinValue;
        int i_max = 0;
        if (y > threshold)
        {
          int istart = i;
          SpikeDataPacket currentSpike = new SpikeDataPacket();

          double ZeroPositionX = ApproxX(GlobalData[i - 1].Item1, GlobalData[i - 1].Item2, x, y);
          if (Math.Abs(ZeroPositionX) > double.MaxValue) ZeroPositionX = x;
          currentSpike.Add(new SpikeData(0, 0));
          while (y > threshold && i < GlobalData.Count)
          {
            if (y < threshold) break;
            x = GlobalData[i].Item1;
            y = GlobalData[i].Item2;
            if (y > y_max)
            {
              x_max=x;
              y_max = y;
              i_max = i-istart;
            }
            SpikeData Spikedata = new SpikeData(x - ZeroPositionX, y - threshold);
            if (y - threshold > eps)
              currentSpike.Add(Spikedata);
            i++;
          }
          if (currentSpike.Count > nostimcount && currentSpike.Count(s => s.Item2 > 1.4 * threshold) > nostimcount)
          {
            PeakList.Add(new Tuple<int,int, double,double>(i_max,i, x_max, y_max));
            WidthList.Add(currentSpike.Count);
            if (NoStimSpikeList.Count < nostimcount) NoStimSpikeList.Add(currentSpike);
            else StimSpikeList.Add(currentSpike);
          }
        }
      }

      numericNoStim.Maximum = NoStimSpikeList.Count;
      numericAfterStim.Maximum = StimSpikeList.Count;
      numericNoStim.Value = NoStimSpikeList.Count;
      numericAfterStim.Value = StimSpikeList.Count;
      KxBottom = countKx();
      LeftMedian = GetMedian(PeakList.Select(t=>t.Item1).ToArray());
      RightMedian = GetMedian(WidthList.ToArray());
    }


    public List<SpikeDataPacket> doCorrCompare()
    {
      List<SpikeDataPacket> fullcor = new List<SpikeDataPacket>();
      for (int i = 0; i < PeakList.Count; i++)
      {
        SpikeDataPacket row = new SpikeDataPacket();
        for (int j = 0; j < PeakList.Count; j++)
        {
          int leftborder = (PeakList[i].Item2 - LeftMedian > 0) ? PeakList[i].Item2 - LeftMedian : 0;
          int rightborder = (PeakList[i].Item2 + RightMedian < GlobalData.Count - 1) ? PeakList[i].Item2 + RightMedian : GlobalData.Count;
          SpikeDataPacket packet1 = GlobalData.GetRange(leftborder,rightborder-leftborder);

          leftborder = (PeakList[j].Item2 - LeftMedian > 0) ? PeakList[j].Item2 - LeftMedian : 0;
          rightborder = (PeakList[j].Item2 + RightMedian < GlobalData.Count - 1) ? PeakList[j].Item2 + RightMedian : GlobalData.Count;
          SpikeDataPacket packet2 = GlobalData.GetRange(leftborder, rightborder - leftborder);
          row.Add(new SpikeData(0, countCorr(packet1, packet2)));
        }
        fullcor.Add(row);
      }
      return fullcor;
    }

    public List<SpikeDataPacket> doCorrCompareMax()
    {
      List<SpikeDataPacket> fullcor = new List<SpikeDataPacket>();
      for (int i = 0; i < PeakList.Count; i++)
      {
        SpikeDataPacket row = new SpikeDataPacket();
        for (int j = 0; j < PeakList.Count; j++)
        {
          List<double> vallist = new List<double>();
          for (int move = -2; move < 3; move++)
          {
            int leftborder = (PeakList[i].Item2 + move - LeftMedian > 0) ? PeakList[i].Item2 + move - LeftMedian : 0;
            int rightborder = (PeakList[i].Item2 + move + RightMedian < GlobalData.Count - 1) ? PeakList[i].Item2 + move + RightMedian : GlobalData.Count;
            SpikeDataPacket packet1 = GlobalData.GetRange(leftborder, rightborder - leftborder);

            leftborder = (PeakList[j].Item2  - LeftMedian > 0) ? PeakList[j].Item2  - LeftMedian : 0;
            rightborder = (PeakList[j].Item2   + RightMedian < GlobalData.Count - 1) ? PeakList[j].Item2  + RightMedian : GlobalData.Count;
            SpikeDataPacket packet2 = GlobalData.GetRange(leftborder, rightborder - leftborder);
            vallist.Add(countCorr(packet1, packet2));
          }
          row.Add(new SpikeData(0, vallist.Max()));
        }
        fullcor.Add(row);
      }
      return fullcor;
    }


    public double countCorr(SpikeDataPacket packet1, SpikeDataPacket packet2)
    {
      packet2 = movePacket(packet1, packet2);
      double avg1 = countAverage(packet1);
      double avg2 = countAverage(packet2);
      double topsum = 0;
      for (int i = 0; i < packet1.Count; i++)
        if (i < packet2.Count)
          topsum += (packet1[i].Item2 - avg1) * (packet2[i].Item2 - avg2);
      double sump1 = 0;
      double sump2 = 0;
      for (int i = 0; i < packet1.Count; i++)
        sump1 += Math.Pow(packet1[i].Item2 - avg1, 2);
      for (int i = 0; i < packet2.Count; i++)
        sump2 += Math.Pow(packet2[i].Item2 - avg2, 2);
      if (Math.Sqrt(sump1 * sump2) > eps)
        return topsum / Math.Sqrt(sump1 * sump2);
      else return 0;
    }

    public static int GetMedian(int[] sourceNumbers)
    {
    
      if (sourceNumbers == null || sourceNumbers.Length == 0)
        return 0;

      //make sure the list is sorted, but use a new array
      int[] sortedPNumbers = (int[])sourceNumbers.Clone();
      sourceNumbers.CopyTo(sortedPNumbers, 0);
      Array.Sort(sortedPNumbers);

      //get the median
      int size = sortedPNumbers.Length;
      int mid = size / 2;
      int median = (size % 2 != 0) ? sortedPNumbers[mid] : (sortedPNumbers[mid] + sortedPNumbers[mid - 1]) / 2;
      return median;
    }

    private double countThreshold()
    {
      double thd = 0;

      int count = 0;
      double avg = 0;
      SpikeDataPacket temppacket = new SpikeDataPacket();

      foreach (SpikeData data in GlobalData)
      {
        if ((data.Item2) < (0.8 * GlobalMax) && (data.Item2) > (0.3 * GlobalMax)) temppacket.Add(new SpikeData(data.Item1,data.Item2));
      }

      foreach (SpikeData data in temppacket)
      {
        count++;
        avg += data.Item2;
      }
      if (count <= 0)
        thd = GlobalMax;
      else thd = avg / (3 * count);
      KyTop = Convert.ToInt32((SpikeGraph.Height - 20) / GlobalMax);
      KyBottom = Convert.ToInt32((StimCharacter.Height - 20) / GlobalMax);
      return thd;
    }

    private int countKx()
    {
      int Kx=1;
      double x_max = double.MinValue;
      foreach (SpikeDataPacket data in StimSpikeList)
      {
        if (data.Last().Item1 > x_max) x_max = data.Last().Item1;
      }
      foreach (SpikeDataPacket data in NoStimSpikeList)
      {
        if (data.Last().Item1 > x_max) x_max = data.Last().Item1;
      }
      Kx = Convert.ToInt32(NoStimCharacter.Width / x_max);
      return Kx;
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

        //double StepWidth = 1e-3;
        double StepWidth = threshold / 10;
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
            DrawPointsList.Add(new PointF((float)x * KxBottom, (float)(NoStimCharacter.Height - Average * KyBottom)));
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

        double StepWidth = threshold / 10;
        //double StepWidth = 1e-3;
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
            DrawPointsList.Add(new PointF((float)x * KxBottom, (float)(StimCharacter.Height - Average * KyBottom)));
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
            (float)(e.ClipRectangle.Height - StimSpikeList[SpikeIdx][i - 1].Item2 * KyBottom),
            (float)StimSpikeList[SpikeIdx][i].Item1 * KxBottom,
            (float)(e.ClipRectangle.Height - StimSpikeList[SpikeIdx][i].Item2 * KyBottom));
        }
      }


      brush = new SolidBrush(Color.Aqua);
      mainpen = new Pen(brush, 5);
      if (AverageDrawPointsStim.Count > 0 && numericAfterStim.Value >= 0 && numericAfterStim.Value <= AverageDrawPointsStim.Count && AvgToolStripMenuItem.Checked == true)
      {
        PointF[] AverageList = (AverageDrawPointsStim[(int)numericAfterStim.Value - 1]).ToArray();
        if (AverageList.Count() > 1) e.Graphics.DrawLines(mainpen, AverageList);
      }

    }

    private void NoStimCharacter_Paint(object sender, PaintEventArgs e)
    {
      Brush brush = new SolidBrush(Color.Black);
      Pen mainpen = new Pen(brush);
      for (int SpikeIdx = 0; SpikeIdx < NoStimSpikeList.Count && SpikeIdx < numericNoStim.Value && SpikeIdx < nostimcount; SpikeIdx++)
      {
        for (int i = 1; i < NoStimSpikeList[SpikeIdx].Count; i++)
        {
          int Ciferka = 9;
          brush = new SolidBrush((Color.FromArgb((byte)(200 - Ciferka * (StimSpikeList.Count - SpikeIdx)), (byte)(200 - Ciferka * (StimSpikeList.Count - SpikeIdx)), (byte)(200 - Ciferka * (StimSpikeList.Count - SpikeIdx)))));
          mainpen = new Pen(brush, 2);
          e.Graphics.DrawLine(mainpen,
            (float)NoStimSpikeList[SpikeIdx][i - 1].Item1 * KxBottom,
            (float)(e.ClipRectangle.Height - NoStimSpikeList[SpikeIdx][i - 1].Item2 * KyBottom),
            (float)NoStimSpikeList[SpikeIdx][i].Item1 * KxBottom,
            (float)(e.ClipRectangle.Height - NoStimSpikeList[SpikeIdx][i].Item2 *  KyBottom));
        }
      }

      brush = new SolidBrush(Color.Blue);
      mainpen = new Pen(brush, 5);
      if (AverageDrawPointsNoStim.Count > 0 && numericNoStim.Value >= 0 && AvgToolStripMenuItem.Checked == true)
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
          (float)(e.ClipRectangle.Height - GlobalData[i - 1].Item2 * KyTop),
          (float)GlobalData[i].Item1 * KxTop,
          (float)(e.ClipRectangle.Height - GlobalData[i].Item2 * KyTop));
      }
      Brush threshholdbrush = new SolidBrush(Color.Red);
      Pen thresholdpen = new Pen(threshholdbrush);
      e.Graphics.DrawLine(thresholdpen, (float)0, (float)(e.ClipRectangle.Height - threshold * KyTop), (float)e.ClipRectangle.Width, (float)(e.ClipRectangle.Height - threshold * KyTop));
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

    private void Threshold_Scroll_ValueChanged(object sender, EventArgs e)
    {
      threshold = (double)Threshold_Scroll.Value / 1000;
      if (FilePath != "")
        loadData(FilePath,0);
      if (NoStimSpikeList.Count > 0)
      {
        numericAfterStim.Value = numericAfterStim.Maximum;
        numericNoStim.Value = numericNoStim.Maximum;
        SpikeGraph.Refresh();
        NoStimCharacter.Refresh();
        StimCharacter.Refresh();
      }

    }

    private void Threshold_Scroll_MouseUp(object sender, MouseEventArgs e)
    {
      threshold = (double)Threshold_Scroll.Value*(0.1*initthreshold);
      if (FilePath != "")
      //loadData(FilePath,0);
      {
        buildCharactList();
        buildNoStimAverage();
        buildStimAverage();
        SpikeGraph.Refresh();
        NoStimCharacter.Refresh();
        StimCharacter.Refresh();
      }
      if (NoStimSpikeList.Count > 0)
      {
        numericAfterStim.Value = numericAfterStim.Maximum;
        numericNoStim.Value = numericNoStim.Maximum;
        SpikeGraph.Refresh();
        NoStimCharacter.Refresh();
        StimCharacter.Refresh();
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

    private void загрузитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
    {
      loadDialogOpen(0);
    }

    private void сравнениеСреднихToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (AverageDrawPointsNoStim.Count > 0 && AverageDrawPointsStim.Count > 0 && AvgToolStripMenuItem.Checked == true)
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

    private void тепловыеКартыToolStripMenuItem_Click(object sender, EventArgs e)
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

        HeatPictureForm hpf = new HeatPictureForm(NoStimSpikeList, StimSpikeList, cellName.Text);
        hpf.Show();

      }
      else
      {
        MessageBox.Show("Нечего отображать", "Карта спайковых характеристик",
        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void AvgToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
      NoStimCharacter.Refresh();
      StimCharacter.Refresh();
    }

    private void экспортВBMPToolStripMenuItem_Click(object sender, EventArgs e)
    {
      String savepath = "D:\\MAPS" + DateTime.Now.ToString("yyyy_MMdd_HHmm");
      if (!System.IO.Directory.Exists(savepath))
        System.IO.Directory.CreateDirectory(savepath);
      if (openDirToolStripMenuItem.Checked == true)
        System.Diagnostics.Process.Start(@savepath);
      Bitmap bmp = new Bitmap(NoStimCharacter.Width, NoStimCharacter.Height);
      NoStimCharacter.DrawToBitmap(bmp, NoStimCharacter.ClientRectangle);
      bmp.Save(savepath + "\\" + cellName.Text + "NoStimGraph.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
      bmp = new Bitmap(StimCharacter.Width, StimCharacter.Height);
      StimCharacter.DrawToBitmap(bmp, StimCharacter.ClientRectangle);
      bmp.Save(savepath + "\\" + cellName.Text + "StimGraph.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
      bmp = new Bitmap(SpikeGraph.Width, SpikeGraph.Height);
      SpikeGraph.DrawToBitmap(bmp, SpikeGraph.ClientRectangle);
      bmp.Save(savepath + "\\" + cellName.Text + "AllSpikesGraph.bmp", System.Drawing.Imaging.ImageFormat.Bmp);

    }

    private void MainForm_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.O && e.Modifiers == Keys.Control)
      {
        loadDialogOpen(0);
      }
      if (e.KeyCode == Keys.M && e.Modifiers == Keys.Control)
      {
        loadDialogOpen(1);
      }
      if (e.KeyCode == Keys.B && e.Modifiers == Keys.Control)
      {
        построитьToolStripMenuItem.ShowDropDown();
      }
    }

    private void загрузитьТеплокартуToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (OpenFileDialog dialog = new OpenFileDialog())
      {
        MegaMapList = new List<SpikeDataPacket>();
        MegaMapStimList = new List<SpikeDataPacket>();
        MegaMapNoStimList = new List<SpikeDataPacket>();
        MegaMapStimMax = new List<SpikeDataPacket>();
        MegaMapNoStimMax = new List<SpikeDataPacket>();
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
              loadData(FilePath,1);

            }
            break;

          case System.Windows.Forms.DialogResult.Cancel:
            break;
        }
      }
    }

    private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
      {
        e.Handled = true;
      }

    }


    private void общиеНастройкиToolStripMenuItem_Click(object sender, EventArgs e)
    {
      new SettingsForm().Show();
    }



    public SpikeDataPacket buildNormalized(SpikeDataPacket list)
    {
      SpikeDataPacket resultList = new SpikeDataPacket();
      double max = double.MinValue;
      for (int i = 0; i < list.Count; i++)
        if (list[i].Item2 > max) max = list[i].Item2;
      foreach ( SpikeData data in list)
        if (Math.Abs(max) > eps) resultList.Add(new SpikeData(data.Item1, data.Item2 / Math.Abs(max)));
        else resultList.Add(new SpikeData(data.Item1, data.Item2));
      return resultList;
    }

    private void матрицуКорToolStripMenuItem_Click(object sender, EventArgs e)
    {
      List<SpikeDataPacket> nostimcor = new List<SpikeDataPacket>();
      for (int i=0; i<NoStimSpikeList.Count; i++)
      {
        SpikeDataPacket row = new SpikeDataPacket();
        for (int j=0; j<NoStimSpikeList.Count;j++)
          row.Add(new SpikeData(0, countCorr(NoStimSpikeList[i], NoStimSpikeList[j])));
        nostimcor.Add(row);
      }
      List<SpikeDataPacket> stimcor = new List<SpikeDataPacket>();
      for (int i=0; i<StimSpikeList.Count; i++)
      {
        SpikeDataPacket row = new SpikeDataPacket();
        for (int j=0; j<StimSpikeList.Count;j++)
          row.Add(new SpikeData(0, countCorr(StimSpikeList[i], StimSpikeList[j])));
        stimcor.Add(row);
      }

      List<SpikeDataPacket> fullist = new List<SpikeDataPacket>();
      fullist.AddRange(NoStimSpikeList);
      fullist.AddRange(StimSpikeList);
      List<SpikeDataPacket> fullcor = new List<SpikeDataPacket>();
      for (int i = 0; i < fullist.Count; i++)
      {
        SpikeDataPacket row = new SpikeDataPacket();
        for (int j = 0; j < fullist.Count; j++)
          row.Add(new SpikeData(0, countCorr(fullist[i], fullist[j])));
        fullcor.Add(row);
      }


      fullcor = doCorrCompareMax();
      HeatPictureForm hpf = new HeatPictureForm(nostimcor,stimcor,"Корреляция");
      HeatPictureForm newhpf = new HeatPictureForm(fullcor, new List<SpikeDataPacket>(), "Корреляция");
      newhpf.Show();
      hpf.Show();

    }



  }
}
