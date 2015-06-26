using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using ZedGraph;

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
    private double prev_threshold = 0.02;
    private string FilePath = "";
    //private int KyTop = 1000;
    //private int KyBottom = 1000;
    public static int LeftMedian = 0;
    public static int RightMedian = 0;
    //private int KxTop = 10;
    //private int KxBottom = 300;
    double eps = 1e-20;
    double GlobalMin = Double.MaxValue;
    double GlobalMax = Double.MinValue;
    public static int nostimcount { get; set; }
    public static int cellCount { get; set; }
    #endregion

    #region Данные класса
    private SpikeDataPacket GlobalData;
    private SpikeDataPacket GlobalDataOrig;
    private List<SpikeDataPacket> MegaMapList = new List<SpikeDataPacket>();
    private List<SpikeDataPacket> MegaMapStimList = new List<SpikeDataPacket>();
    private List<SpikeDataPacket> MegaMapNoStimList = new List<SpikeDataPacket>();
    private List<SpikeDataPacket> MegaMapStimMax = new List<SpikeDataPacket>();
    private List<SpikeDataPacket> MegaMapNoStimMax = new List<SpikeDataPacket>();
    public List<SpikeDataPacket> StimSpikeList { get; set; }
    public List<SpikeDataPacket> NoStimSpikeList { get; set; }
    public List<SpikeDataPacket> StimSpikeListNoThresh { get; set; }
    public List<SpikeDataPacket> NoStimSpikeListNoThresh { get; set; }
    public SpikePeakList PeakList { get; set; }
    private GraphPane pane_common;
    private GraphPane pane_nostim;
    private GraphPane pane_stim;
    private List<SpikeDataPacket> PreSpikeList = new List<SpikeDataPacket>();
    private List<SpikeDataPacket> PreSpikeListNoThresh = new List<SpikeDataPacket>();
    private List<PointF> DrawPointsList;
    private List<PointF> PointsList;
    private List<PointList> AverageDrawPointsStim = new List<PointList>();
    private List<PointList> AverageDrawPointsNoStim = new List<PointList>();
    private List<PointList> AveragePointsStim = new List<PointList>();
    private List<PointList> AveragePointsNoStim = new List<PointList>();
    private List<int> WidthList = new List<int>();

    #endregion

    public MainForm()
    {
      InitializeComponent();
      cellCount = Properties.Settings.Default.cellcount;
      nostimcount = Properties.Settings.Default.stimstart;
      KeyPreview = true;
      GlobalData = new SpikeDataPacket();
      GlobalDataOrig = new SpikeDataPacket();
      StimSpikeList = new List<SpikeDataPacket>();
      NoStimSpikeList = new List<SpikeDataPacket>();
      StimSpikeListNoThresh = new List<SpikeDataPacket>();
      NoStimSpikeListNoThresh = new List<SpikeDataPacket>();
      PreSpikeList = new List<SpikeDataPacket>();
      PeakList = new SpikePeakList();


      pane_nostim = NoStimZedGraph.GraphPane;
      pane_stim = StimZedGraph.GraphPane;
      pane_common = CommonZedGraph.GraphPane;

      pane_common.Title.Text = "Спайковые характеристики";
      pane_common.XAxis.Title.Text = "Время, с";
      pane_common.YAxis.Title.Text = "Интенсивность свечения, ед";
      pane_common.CurveList.Clear();

      pane_nostim.Title.Text = "До стимуляции";
      pane_nostim.XAxis.Title.Text = "Время, с";
      pane_nostim.YAxis.Title.Text = "Интенсивность свечения, ед";
      pane_nostim.CurveList.Clear();


      pane_stim.Title.Text = "Во время стимуляции";
      pane_stim.XAxis.Title.Text = "Время, с";
      pane_stim.YAxis.Title.Text = "Интенсивность свечения, ед";
      pane_stim.CurveList.Clear();

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
        if (megacheck == 1) dialog.FileName = "\"Cell_13\" \"Cell_1\" \"Cell_2\" \"Cell_3\" \"Cell_4\" \"Cell_5\" \"Cell_6\" \"Cell_7\" \"Cell_8\" \"Cell_9\" \"Cell_10\" \"Cell_11\" \"Cell_12\" ";
        dialog.Multiselect = true;
        dialog.InitialDirectory = Application.StartupPath + @"\..\..";
        switch (dialog.ShowDialog())
        {
          case System.Windows.Forms.DialogResult.OK:
            foreach (String path in dialog.FileNames)
            {
              FilePath = path;
              controlGroupBox.Text = System.IO.Path.GetFileNameWithoutExtension(dialog.FileName);
              loadData(FilePath, megacheck);
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

      GlobalData = new SpikeDataPacket();
      GlobalDataOrig = new SpikeDataPacket();

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
      GlobalDataOrig.AddRange(GlobalData);

      if (megacheck == 1)
      {
        MegaMapList.Add((GlobalData));
        if (MegaMapList.Count == cellCount)
        {
          buildMegaLists();
        }
      }
      else
        proceedData();



    }

    public void proceedData()
    {
      StimSpikeList = new List<SpikeDataPacket>();
      NoStimSpikeList = new List<SpikeDataPacket>();
      StimSpikeListNoThresh = new List<SpikeDataPacket>();
      NoStimSpikeListNoThresh = new List<SpikeDataPacket>();
      AverageDrawPointsStim = new List<PointList>();
      AverageDrawPointsNoStim = new List<PointList>();
      AveragePointsStim = new List<PointList>();
      AveragePointsNoStim = new List<PointList>();
      GlobalMin = Double.MaxValue;
      GlobalMax = Double.MinValue;
      GlobalData = new SpikeDataPacket();
      GlobalData.AddRange(GlobalDataOrig);
      //numericNoStim.Value = 1;
      //numericAfterStim.Value = 1;
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
      prev_threshold = threshold;
      initthreshold = threshold;

      if (MAItem.Checked) doMA();
      if (ApproxItem.Checked) doApprox();



      buildCharactList();
      buildNoStimAverage();
      buildStimAverage();
      RecountMaxScroll();
      Refresh_Graphs();
    }

    private void doApprox()
    {
      SpikeDataPacket approxlist = buildApproxList(GlobalData);
      List<double> xapprox = new List<double>();
      List<double> yapprox = new List<double>();
      foreach (SpikeData approx in approxlist)
      {
        xapprox.Add(approx.Item1);
        yapprox.Add(approx.Item2);
      }

      for (int i = 0; i < GlobalData.Count; i++)
      {
        double diff =0;
        switch (Properties.Settings.Default.approxtype)
        {
          case 0:
            diff = NaturalCubicSpline(xapprox.ToArray(), yapprox.ToArray(), GlobalData[i].Item1);
            break;
          case 1:
            diff = LagrangeInterpolation(xapprox.ToArray(), yapprox.ToArray(), GlobalData[i].Item1);
            break;

        }
         
        GlobalData[i] = new SpikeData(GlobalData[i].Item1, GlobalData[i].Item2 - diff);
      }

    }

    private void doMA()
    {
      double[] yma = new double[GlobalData.Count];
      int param = Convert.ToInt32(MAParamTB.Text);
      for (int i = 0; i < GlobalData.Count; i++)
        yma[i] = GlobalData[i].Item2;

      yma = MovingAverage(yma, param);
      for (int i = 0; i < GlobalData.Count; i++)
      {
        GlobalData[i] = new SpikeData(GlobalData[i].Item1, yma[i]);
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
        int CountVar = 0;
        for (int j = 1; j < MegaMapList[i].Count; j++)
        {
          //int CountVar = 0;
          SpikeData max = new SpikeData(eps, eps);
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
              if (y > max.Item2) max = new SpikeData(x, y);
              SpikeData Spikedata = new SpikeData(x, y);
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
      HeatPictureForm hpf = new HeatPictureForm(MegaMapNoStimList, MegaMapStimList, MegaMapNoStimMax, MegaMapStimMax) { Owner = this };
      hpf.Show(this);
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

    public int findMax(SpikeDataPacket list)
    {
      double max = double.MinValue;
      int max_i = 0;
      for (int i = 0; i < list.Count; i++)
        if (list[i].Item2 > max)
        {
          max = list[i].Item2;
          max_i = i;
        }
      return max_i;

    }



    public static int FirstIndex(int i, int width)
    {
      if (i >= width / 2)
        return (i - width / 2);
      else
        return 0;
    }

    public static int LastIndex(int i, int width, int size)
    {
      if (i + width / 2 < size)
        return (i + width / 2);
      else
        return (size - 1);
    }


    public static double[] MovingAverage(double[] RoughData, int width)
    {
      double[] y = new double[RoughData.Length];
      if (width % 2 == 0)

        return y;

      for (int i = 0; i < RoughData.Length; i++)
      {
        y[i] = 0.0;
        int start = FirstIndex(i, width);
        int stop = LastIndex(i, width, RoughData.Length);
        for (int j = start; j <= stop; j++)
        {
          y[i] = y[i] + RoughData[j];
        }
        y[i] = y[i] / (stop - start + 1);
      }
      return y;
    }

    static double Correlation(double[] data1, double[] data2)
    {
      if (data1.Length != data2.Length)
      {
        throw new Exception("The two data sets being tested are of different sizes");
      }
      if (data1.Length == 0)
      {
        throw new Exception("Data in correlation method has zero length.");
      }
      if (data1.Length == 1)
      {
        throw new Exception("Single data point is insufficient for correlation.");
      }
      // Sum
      double sum1 = 0.0d;
      double sum2 = 0.0d;
      for (int i = 0; i < data1.Length; i++)
      {
        sum1 += data1[i];
        sum2 += data2[i];
      }
      // Mean
      double mean1 = sum1 / data1.Length;
      double mean2 = sum2 / data2.Length;
      // Covariances
      double total = 0.0d;
      for (int i = 0; i < data1.Length; i++)
      {
        total += ((data1[i] - mean1) * (data2[i] - mean2));
      }
      double covariance = total / data1.Length;
      // Standard deviation
      sum1 = 0.0d;
      sum2 = 0.0d;
      for (int i = 0; i < data1.Length; i++)
      {
        sum1 += ((data1[i] - mean1) * (data1[i] - mean1));
        sum2 += ((data2[i] - mean2) * (data2[i] - mean2));

      }
      double stdev1 = Math.Sqrt(sum1 / data1.Length);
      double stdev2 = Math.Sqrt(sum2 / data2.Length);
      if ((stdev1 * stdev2) == 0)
      {
        throw new Exception("One of the standard deviations is zero");
      }
      return (covariance / (stdev1 * stdev2));
    }

    public SpikeDataPacket movePacket(SpikeDataPacket packet1, SpikeDataPacket packet2)
    {
      double max1 = double.MinValue;
      int max_i1 = 0;
      double max2 = double.MinValue;
      int max_i2 = 0;
      for (int i = 0; i < packet1.Count; i++)
      {
        if (packet1[i].Item2 > max1)
        {
          max1 = packet1[i].Item2;
          max_i1 = i;
        }
      }

      for (int i = 0; i < packet2.Count; i++)
      {
        if (packet2[i].Item2 > max2)
        {
          max2 = packet2[i].Item2;
          max_i2 = i;
        }
      }

      int diff = max_i2 - max_i1;
      if (diff != 0)
      {
        SpikeDataPacket resultpacket = new SpikeDataPacket();
        for (int i = 0; i < packet1.Count + diff; i++)
        {
          if (resultpacket.Count > packet1.Count) break;
          if ((i + diff >= 0) && (i + diff < packet2.Count) && (i < packet1.Count))
            resultpacket.Add(new SpikeData(packet1[i].Item1, packet2[i + diff].Item2));
        }

        return resultpacket;
      }
      else return packet2;

    }




    private void buildCharactList()
    {
      PreSpikeList = new List<SpikeDataPacket>();
      PreSpikeListNoThresh = new List<SpikeDataPacket>();
      PeakList = new SpikePeakList();
      NoStimSpikeList = new List<SpikeDataPacket>();
      StimSpikeList = new List<SpikeDataPacket>();
      StimSpikeListNoThresh = new List<SpikeDataPacket>();
      NoStimSpikeListNoThresh = new List<SpikeDataPacket>();

      for (int i = 1; i < GlobalData.Count; i++)
      {
        double x = GlobalData[i].Item1, y = GlobalData[i].Item2;
        double x_max = 0, y_max = double.MinValue;
        int i_max = 0;
        if (y > threshold)
        {
          int istart = i;
          SpikeDataPacket currentSpike = new SpikeDataPacket();
          SpikeDataPacket currentSpikeNoThresh = new SpikeDataPacket();
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
              x_max = x;
              y_max = y;
              i_max = i - istart;
            }
            SpikeData Spikedata = new SpikeData(x - ZeroPositionX, y - threshold);
            SpikeData noThresh = new SpikeData(x, y);
            if (y - threshold > eps && x - ZeroPositionX > eps)
              currentSpike.Add(Spikedata);
            currentSpikeNoThresh.Add(noThresh);
            i++;
          }
          PreSpikeList.Add(currentSpike);
          PreSpikeListNoThresh.Add(currentSpikeNoThresh);
          PeakList.Add(new Tuple<int, int, double, double>(i_max, i, x_max, y_max));
          WidthList.Add(currentSpike.Count);

          //if (currentSpike.Count > nostimcount && currentSpike.Count(s => s.Item2 > 1.4 * threshold) > nostimcount)
          //{
          //  PeakList.Add(new Tuple<int,int, double,double>(i_max,i, x_max, y_max));
          //  WidthList.Add(currentSpike.Count);
          //  if (NoStimSpikeList.Count < nostimcount) NoStimSpikeList.Add(currentSpike);
          //  else StimSpikeList.Add(currentSpike);
          //}

        }
      }
      int RemoveCount = 0;
      LeftMedian = GetMedian(PeakList.Select(t => t.Item1).ToArray());
      RightMedian = GetMedian(WidthList.ToArray());
      for (int i = 0; i < PreSpikeList.Count; i++)
      {
        if (PreSpikeList[i].Count > 0.75 * RightMedian)

          if (NoStimSpikeList.Count < nostimcount)
          {
            NoStimSpikeList.Add(PreSpikeList[i]);
            NoStimSpikeListNoThresh.Add(PreSpikeListNoThresh[i]);
          }
          else
          {
            StimSpikeList.Add(PreSpikeList[i]);
            StimSpikeListNoThresh.Add(PreSpikeListNoThresh[i]);
          }

        else
        {
          PeakList.RemoveAt(i - RemoveCount);
          WidthList.RemoveAt(i - RemoveCount);
          RemoveCount++;
        }
      }
      RecountMaxScroll();
      numericNoStim.Value = NoStimSpikeList.Count;
      numericAfterStim.Value = StimSpikeList.Count;
      //KxBottom = countKx();

    }

    private SpikeData findMin(SpikeDataPacket list)
    {
      double x_min = 0;
      double y_min = double.MaxValue;
      foreach (SpikeData data in list)
        if (data.Item2 < y_min)
        {
          y_min = data.Item2;
          x_min = data.Item1;
        }
      return new SpikeData(x_min, y_min);
    }

    private SpikeDataPacket buildApproxList(SpikeDataPacket inlist)
    {
      SpikeDataPacket approxlist = new SpikeDataPacket();
      approxlist.Add(findMin(inlist.GetRange(0, 80)));
      int param = Convert.ToInt32(ApproxParamText.Text);
      
      int windowsize = (int)Math.Truncate((double)inlist.Count / param);
      for (int i = 0; i + windowsize < inlist.Count; i += windowsize)
        approxlist.Add(findMin(inlist.GetRange(i, windowsize)));
      approxlist.Add(findMin(inlist.GetRange(inlist.Count - 81, 80)));
      return approxlist;
    }

    public static double NewtonDividedDifferenceInterpolation(double[] x, double[] y, double xval)
    {
      double yval;
      int size = x.Length;
      double[] tarray = new double[size];
      for (int i = 0; i < size; i++)
      {
        tarray[i] = y[i];
      }
      for (int i = 0; i < size - 1; i++)
      {
        for (int j = size - 1; j > i; j--)
        {
          tarray[j] = (tarray[j - 1] - tarray[j]) / (x[j - 1 - i] - x[j]);
        }
      }
      yval = tarray[size - 1];
      for (int i = size - 2; i >= 0; i--)
      {
        yval = tarray[i] + (xval - x[i]) * yval;
      }
      return yval;
    }

    public static double LagrangeInterpolation(double[] x, double[] y, double xval)
    {
      double yval = 0.0;
      double Products = y[0];
      for (int i = 0; i < x.Length; i++)
      {
        Products = y[i];
        for (int j = 0; j < x.Length; j++)
        {
          if (i != j)
          {
            Products *= (xval - x[j]) / (x[i] - x[j]);
          }
        }
        yval += Products;
      }
      if (double.IsNaN(yval)) return 0;
      return yval;
    }

    public double NaturalCubicSpline(double[] x, double[] y, double xvalue)
    {
      int i, j, m;
      double S = 0.0;
      double delta = 0.0;
      int n = 5; //max number of coefficients: A,B,C,D for cubic spline
      double[] A = new double[n + 1];
      double[] B = new double[n + 1];
      double[] C = new double[n + 1];
      double[] D = new double[n + 1];
      double[] H = new double[n + 1];
      double[] XA = new double[n + 1];
      double[] XL = new double[n + 1];
      double[] XU = new double[n + 1];
      double[] XZ = new double[n + 1];
      for (i = 0; i < n; i++) A[i] = y[i];
      m = n - 1;
      for (i = 0; i <= m; i++)
        H[i] = x[i + 1] - x[i];
      for (i = 1; i <= m; i++)
        XA[i] = 3 * (A[i + 1] * H[i - 1] - A[i] * (x[i + 1] - x[i - 1]) +
        A[i - 1] * H[i]) / (H[i] * H[i - 1]);
      XL[0] = 1; XU[0] = 0; XZ[0] = 0;
      for (i = 1; i <= m; i++)
      {
        XL[i] = 2 * (x[i + 1] - x[i - 1]) - H[i - 1] * XU[i - 1];
        XU[i] = H[i] / XL[i];
        XZ[i] = (XA[i] - H[i - 1] * XZ[i - 1]) / XL[i];
      }
      XL[n] = 1; XZ[n] = 0; C[n] = 0;
      for (i = 0; i <= m; i++)
      {
        j = m - i;
        C[j] = XZ[j] - XU[j] * C[j + 1];
        B[j] = (A[j + 1] - A[j]) / H[j] - H[j] * (C[j + 1] + 2 * C[j]) / 3;
        D[j] = (C[j + 1] - C[j]) / (3 * H[j]);
      }


      for (i = 0; i <= m; i++)
      {
        if (xvalue >= x[i] && xvalue < x[i + 1])
        {
          delta = xvalue - x[i];
          S = A[i] + B[i] * delta + C[i] * delta * delta + D[i] * delta * delta * delta;
        }
      }
      if (double.IsNaN(S)) return 0;
      return S;
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
          SpikeDataPacket packet1 = GlobalData.GetRange(leftborder, rightborder - leftborder);

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

            leftborder = (PeakList[j].Item2 - LeftMedian > 0) ? PeakList[j].Item2 - LeftMedian : 0;
            rightborder = (PeakList[j].Item2 + RightMedian < GlobalData.Count - 1) ? PeakList[j].Item2 + RightMedian : GlobalData.Count;
            SpikeDataPacket packet2 = GlobalData.GetRange(leftborder, rightborder - leftborder);
            vallist.Add(countCorr(packet1, packet2));
          }
          row.Add(new SpikeData(0, vallist.Max()));
        }
        fullcor.Add(row);
      }
      return fullcor;
    }

    private void DrawCommonZedGraph()
    {
      pane_common.CurveList.Clear();
      pane_common.GraphObjList.Clear();
      pane_common.Legend.IsVisible = false;
      LineObj threshHoldLine = new LineObj(Color.Red, pane_common.XAxis.Scale.Min, threshold, pane_common.XAxis.Scale.Max, threshold);
      pane_common.GraphObjList.Add(threshHoldLine);
      PointPairList list = new PointPairList();
      for (int i = 0; i < GlobalData.Count; i++)
        list.Add(GlobalData[i].Item1, GlobalData[i].Item2);


      pane_common.AddCurve(null, list, Color.Black, SymbolType.None);

      if (separateButton.Checked)
      {
        PointPairList selected_charact = new PointPairList();
        for (int i = 0; i < NoStimSpikeListNoThresh[(int)numericNoStim.Value - 1].Count; i++)
          selected_charact.Add(NoStimSpikeListNoThresh[(int)numericNoStim.Value - 1][i].Item1, NoStimSpikeListNoThresh[(int)numericNoStim.Value - 1][i].Item2);

        LineItem curve = pane_common.AddCurve(null, selected_charact, Color.Violet, SymbolType.None);
        curve.Line.Width = 5;
        curve.Line.IsSmooth = true;

        selected_charact = new PointPairList();
        for (int i = 0; i < StimSpikeListNoThresh[(int)numericAfterStim.Value-1].Count; i++)
          selected_charact.Add(StimSpikeListNoThresh[(int)numericAfterStim.Value-1][i].Item1, StimSpikeListNoThresh[(int)numericAfterStim.Value-1][i].Item2);

        curve =  pane_common.AddCurve(null, selected_charact, Color.Brown, SymbolType.None);
        curve.Line.Width = 5;
        curve.Line.IsSmooth = true;

      }

      //list = new PointPairList();

      //SpikeDataPacket approxlist = buildApproxList(GlobalData);
      //List<double> xapprox = new List<double>();
      //List<double> yapprox = new List<double>();
      //foreach (SpikeData approx in approxlist)
      //{
      //  xapprox.Add(approx.Item1);
      //  yapprox.Add(approx.Item2);
      //}
      //double[] xapproxarr = xapprox.ToArray();
      //double[] yapproxarr = yapprox.ToArray();

      //for (int i = 0; i < GlobalData.Count; i++)
      //{
      //  double diff = NaturalCubicSpline(xapproxarr, yapproxarr, GlobalData[i].Item1);
      //  list.Add(GlobalData[i].Item1, diff);
      //}

      //pane_common.AddCurve(null, list, Color.Orange, SymbolType.None);

      CommonZedGraph.AxisChange();
      CommonZedGraph.Invalidate();

    }

    private void DrawNoStimZedGraph()
    {
      pane_nostim.CurveList.Clear();
      if (NoStimSpikeList.Count == 0) return;
      PointPairList list = new PointPairList();
      if (togetherButton.Checked)
        for (int i = 0; i < NoStimSpikeList.Count && i < numericNoStim.Value; i++)
        {
          list = new PointPairList();
          for (int j = 0; j < NoStimSpikeList[i].Count; j++)
            list.Add(NoStimSpikeList[i][j].Item1, NoStimSpikeList[i][j].Item2);


          LineItem curve = pane_nostim.AddCurve(null, list, Color.FromArgb(100, 50, 50, 50), SymbolType.None);
          curve.Line.Width = 2;
          curve.Line.IsSmooth = true;

        }
      else
      {
        if ((int)numericNoStim.Value - 1 < NoStimSpikeList.Count && (int)numericNoStim.Value>0)
          for (int i = 0; i < NoStimSpikeList[(int)numericNoStim.Value - 1].Count; i++)
            list.Add(NoStimSpikeList[(int)numericNoStim.Value - 1][i].Item1, NoStimSpikeList[(int)numericNoStim.Value - 1][i].Item2);
        LineItem curve = pane_nostim.AddCurve(null, list, Color.Violet, SymbolType.None);
        curve.Line.Width = 2;
        curve.Line.IsSmooth = true;
      }

      if (togetherButton.Checked)
      if (AveragePointsNoStim.Count > 0 && numericNoStim.Value > 0 && AvgToolStripMenuItem.Checked == true && (int)numericNoStim.Value - 1 < AverageDrawPointsNoStim.Count)
      {
        list = new PointPairList();
        for (int j = 0; j < AveragePointsNoStim[(int)numericNoStim.Value - 1].Count; j++)
          list.Add(AveragePointsNoStim[(int)numericNoStim.Value - 1][j].X, AveragePointsNoStim[(int)numericNoStim.Value - 1][j].Y);
        LineItem curve = pane_nostim.AddCurve(null, list, Color.Blue, SymbolType.None);
        curve.Line.Width = 5;
        curve.Line.IsSmooth = true;
      }
      NoStimZedGraph.AxisChange();
      NoStimZedGraph.Invalidate();

    }

    private void DrawStimZedGraph()
    {
      pane_stim.CurveList.Clear();
      if (StimSpikeList.Count == 0) return;
      PointPairList list = new PointPairList();
      if (togetherButton.Checked)
      for (int i = 0; i < StimSpikeList.Count && i < numericAfterStim.Value; i++)
      {
        list = new PointPairList();
        for (int j = 0; j < StimSpikeList[i].Count; j++)
          list.Add(StimSpikeList[i][j].Item1, StimSpikeList[i][j].Item2);

        LineItem curve = pane_stim.AddCurve(null, list, Color.FromArgb(100, 50, 50, 50), SymbolType.None);
        curve.Line.Width = 2;
        curve.Line.IsSmooth = true;
      }
      else
      {
        if ((int)numericAfterStim.Value - 1 < StimSpikeList.Count && (int)numericAfterStim.Value >0)
          for (int i = 0; i < StimSpikeList[(int)numericAfterStim.Value - 1].Count; i++)
            list.Add(StimSpikeList[(int)numericAfterStim.Value - 1][i].Item1, StimSpikeList[(int)numericAfterStim.Value - 1][i].Item2);
        LineItem curve = pane_stim.AddCurve(null, list, Color.Brown, SymbolType.None);
        curve.Line.Width = 2;
        curve.Line.IsSmooth = true;
      }

      if (togetherButton.Checked)
      if (AveragePointsStim.Count > 0 && numericAfterStim.Value > 0 && numericAfterStim.Value <= AveragePointsStim.Count && AvgToolStripMenuItem.Checked == true)
      {
        list = new PointPairList();
        for (int j = 0; j < AveragePointsStim[(int)numericAfterStim.Value - 1].Count; j++)
          list.Add(AveragePointsStim[(int)numericAfterStim.Value - 1][j].X, AveragePointsStim[(int)numericAfterStim.Value - 1][j].Y);
        LineItem curve = pane_stim.AddCurve(null, list, Color.Violet, SymbolType.None);
        curve.Line.Width = 5;
        curve.Line.IsSmooth = true;
      }
      StimZedGraph.AxisChange();
      StimZedGraph.Invalidate();

    }



    public double countCorr(SpikeDataPacket packet1, SpikeDataPacket packet2)
    {
      //if (Properties.Settings.Default.movecharact)
      // packet2 = movePacket(packet1, packet2);
      List<double> list1 = new List<double>();
      List<double> list2 = new List<double>();
      int size = Math.Min(packet1.Count, packet2.Count);
      for (int i = 0; i < size; i++)
      {
        list1.Add(packet1[i].Item2);
        list2.Add(packet2[i].Item2);
      }
      return Correlation(list1.ToArray(), list2.ToArray());
      //double avg1 = countAverage(packet1);
      //double avg2 = countAverage(packet2);
      //double topsum = 0;
      //for (int i = 0; i < packet1.Count; i++)
      //  if (i < packet2.Count)
      //    topsum += (packet1[i].Item2 - avg1) * (packet2[i].Item2 - avg2);
      //double sump1 = 0;
      //double sump2 = 0;
      //for (int i = 0; i < packet1.Count; i++)
      //  sump1 += Math.Pow(packet1[i].Item2 - avg1, 2);
      //for (int i = 0; i < packet2.Count; i++)
      //  sump2 += Math.Pow(packet2[i].Item2 - avg2, 2);
      //if (Math.Sqrt(sump1 * sump2) > eps)
      //  return topsum / Math.Sqrt(sump1 * sump2);
      //else return 0;
    }

    public double countCorrv2(SpikeDataPacket packet1, SpikeDataPacket packet2)
    {

      if (packet1 == packet2) return 1;
      packet2 = movePacket(packet1, packet2);

      int minsize = Math.Min(packet1.Count, packet2.Count);
      int size = (int)Math.Truncate(minsize * 0.8);
      int diff = minsize - size;
      int max_M = Math.Abs((int)Math.Truncate(diff * 0.7));
      int center1 = findMax(packet1), left_bord1 = (center1 - LeftMedian > 0) ? center1 - LeftMedian : 0, right_bord1 = (center1 + RightMedian < packet1.Count) ? center1 + RightMedian : packet1.Count;
      int center2 = findMax(packet2), left_bord2 = (center2 - LeftMedian > max_M) ? center2 - LeftMedian : max_M, right_bord2 = (center2 + RightMedian + max_M < packet2.Count) ? center2 + RightMedian : packet2.Count - max_M;
      int left_bord = Math.Max(Math.Min(left_bord1, left_bord2), max_M), right_bord = Math.Min(right_bord1, right_bord2);




      double topsum = 0;
      double sump1 = 0;
      double sump2 = 0;
      double bestCorr = double.MinValue;
      double Corr = double.MinValue;
      for (int m = -max_M; m <= max_M; m++)
      {
        Corr = double.MinValue;
        //double avg1 = countAverage(packet1.GetRange(left_bord, right_bord - left_bord));
        //double avg2 = countAverage(packet2.GetRange(left_bord + m, right_bord - left_bord));
        //sump1 = 0;
        //sump2 = 0;
        //topsum = 0;
        //for (int i = left_bord; i < right_bord; i++)
        //  // if (i < size)
        //  topsum += (packet1[i].Item2 - avg1) * (packet2[i + m].Item2 - avg2);

        //for (int i = left_bord; i < right_bord; i++)
        //  sump1 += Math.Pow(packet1[i].Item2 - avg1, 2);

        //for (int i = left_bord + m; i < right_bord + m; i++)
        //  sump2 += Math.Pow(packet2[i].Item2 - avg2, 2);

        //Corr = (Math.Sqrt(sump1 * sump2) > eps) ? (topsum / Math.Sqrt(sump1 * sump2)) : 0;
        Corr = countCorr(packet1, packet2);
        if (Corr > bestCorr)
          bestCorr = Corr;
      }
      return bestCorr;
    }

    public double countCorrv3(SpikeDataPacket signal1, SpikeDataPacket signal2)
    {
      int m = signal1.Count, n = signal2.Count;
      //double max1 = double.MinValue;
      //for (int i = 0; i < m; i++)
      //  if (signal1[i].Item2 > max1) max1 = signal1[i].Item2;
      //double max2 = double.MinValue;
      //for (int i = 0; i < n; i++)
      //  if (signal2[i].Item2 > max2) max2 = signal2[i].Item2;



      alglib.complex[] signal1comp = new alglib.complex[m];
      alglib.complex[] signal2comp = new alglib.complex[n];
      for (int i = 0; i < m; i++)
        signal1comp[i] = new alglib.complex(signal1[i].Item2);

      for (int i = 0; i < n; i++)
        signal2comp[i] = new alglib.complex(signal2[i].Item2);


      alglib.complex[] outarr = new alglib.complex[Math.Max(m, n)];
      alglib.complex[] selfarr1 = new alglib.complex[m];
      alglib.complex[] selfarr2 = new alglib.complex[m];
      alglib.corrc1d(signal1comp, m, signal1comp, m, out selfarr1);
      alglib.corrc1d(signal2comp, n, signal2comp, n, out selfarr2);

      double self1 = double.MinValue;
      double self2 = double.MinValue;

      for (int i = 0; i < selfarr1.Count(); i++)
        if (selfarr1[i].x > self1)
          self1 = selfarr1[i].x;
      for (int i = 0; i < selfarr2.Count(); i++)
        if (selfarr2[i].x > self2)
          self2 = selfarr2[i].x;

      alglib.corrc1d(signal1comp, m, signal2comp, n, out outarr);



      double result = double.MinValue;
      for (int i = 0; i < outarr.Count(); i++)
        if (outarr[i].x > result)
          result = outarr[i].x;
      return result / Math.Max(self1, self2);

    }


    #region Корелляция через площадь

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
    #endregion




    public static int GetMedian(int[] sourceNumbers)
    {

      if (sourceNumbers == null || sourceNumbers.Length == 0)
        return 0;

      int[] sortedPNumbers = (int[])sourceNumbers.Clone();
      sourceNumbers.CopyTo(sortedPNumbers, 0);
      Array.Sort(sortedPNumbers);

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
        if ((data.Item2) < (0.8 * GlobalMax) && (data.Item2) > (0.3 * GlobalMax)) temppacket.Add(new SpikeData(data.Item1, data.Item2));
      }

      foreach (SpikeData data in temppacket)
      {
        count++;
        avg += data.Item2;
      }
      if (count <= 0)
        thd = GlobalMax;
      else thd = avg / (3 * count);
      //KyTop = Convert.ToInt32((SpikeGraph.Height - 20) / GlobalMax);
      //KyBottom = Convert.ToInt32((StimCharacter.Height - 20) / GlobalMax);
      return thd;
    }

    private int countKx()
    {
      int Kx = 1;
      double x_max = double.MinValue;
      foreach (SpikeDataPacket data in StimSpikeList)
      {
        if (data.Last().Item1 > x_max) x_max = data.Last().Item1;
      }
      foreach (SpikeDataPacket data in NoStimSpikeList)
      {
        if (data.Last().Item1 > x_max) x_max = data.Last().Item1;
      }
      //Kx = Convert.ToInt32(NoStimCharacter.Width / x_max);
      return Kx;
    }

    public void buildNoStimAverage()
    {
      AveragePointsNoStim = new List<PointList>();
      AverageDrawPointsNoStim = new List<PointList>();
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
            //DrawPointsList.Add(new PointF((float)x * KxBottom, (float)(NoStimCharacter.Height - Average * KyBottom)));
          }
        }
        AveragePointsNoStim.Add(PointsList);
        AverageDrawPointsNoStim.Add(DrawPointsList);
      }

    }

    public void buildStimAverage()
    {
      AveragePointsStim = new List<PointList>();
      AverageDrawPointsStim = new List<PointList>();
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
            //DrawPointsList.Add(new PointF((float)x * KxBottom, (float)(StimCharacter.Height - Average * KyBottom)));
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
      //SpikeGraph.Refresh();
      Refresh_Graphs();
    }

    public void Refresh_Graphs()
    {
      //NoStimCharacter.Refresh();
      //StimCharacter.Refresh();
      DrawCommonZedGraph();
      DrawNoStimZedGraph();
      DrawStimZedGraph();
    }

    public void RecountMaxScroll()
    {
      numericNoStim.Maximum = NoStimSpikeList.Count;
      numericAfterStim.Maximum = StimSpikeList.Count;
    }

    //private void TopScroll_Scroll(object sender, EventArgs e)
    //{
    //  KxTop = 1 + TopScroll.Value / 2;
    //  SpikeGraph.Refresh();
    //}

    //private void BottomScroll_Scroll(object sender, EventArgs e)
    //{
    //  KxBottom = 50 + BottomScroll.Value * 10;
    //  Refresh_Graphs();
    //}

    private void numericNo_ValueChanged(object sender, EventArgs e)
    {
      //NoStimCharacter.Refresh();
      DrawNoStimZedGraph();
      DrawCommonZedGraph();
    }

    private void numericAfterStim_ValueChanged(object sender, EventArgs e)
    {
      //StimCharacter.Refresh();
      DrawStimZedGraph();
      DrawCommonZedGraph();
    }

    private void Threshold_Scroll_ValueChanged(object sender, EventArgs e)
    {
      prev_threshold = threshold;
      threshold = (double)Threshold_Scroll.Value / 1000;
      StimSpikeList = new List<SpikeDataPacket>();
      NoStimSpikeList = new List<SpikeDataPacket>();
      if (FilePath != "")
        loadData(FilePath, 0);
      if (NoStimSpikeList.Count > 0)
      {
        numericAfterStim.Value = numericAfterStim.Maximum;
        numericNoStim.Value = numericNoStim.Maximum;
        //SpikeGraph.Refresh();
        Refresh_Graphs();
      }

    }

    private void Threshold_Scroll_MouseUp(object sender, MouseEventArgs e)
    {
      prev_threshold = threshold;
      threshold = (double)Threshold_Scroll.Value * (0.01 * initthreshold);
      if (threshold == prev_threshold) return;
      freeVariables();
      if (FilePath != "")
      //loadData(FilePath,0);
      {
        buildCharactList();
        buildNoStimAverage();
        buildStimAverage();
        //SpikeGraph.Refresh();
        Refresh_Graphs();
      }
      if (NoStimSpikeList.Count > 0)
      {
        numericAfterStim.Value = numericAfterStim.Maximum;
        numericNoStim.Value = numericNoStim.Maximum;
        //SpikeGraph.Refresh();
        Refresh_Graphs();
      }

    }

    private void freeVariables()
    {
      StimSpikeList = new List<SpikeDataPacket>();
      StimSpikeListNoThresh = new List<SpikeDataPacket>();
      NoStimSpikeList = new List<SpikeDataPacket>();
      NoStimSpikeListNoThresh = new List<SpikeDataPacket>();
      PreSpikeList = new List<SpikeDataPacket>();
      PreSpikeListNoThresh = new List<SpikeDataPacket>();
      AverageDrawPointsStim = new List<PointList>();
      AverageDrawPointsNoStim = new List<PointList>();
      AveragePointsStim = new List<PointList>();
      AveragePointsNoStim = new List<PointList>();
      PeakList = new SpikePeakList();
      WidthList = new List<int>();
    }


    private SpikeDataPacket thresholdCheck(SpikeDataPacket list)
    {
      SpikeDataPacket resultList = new SpikeDataPacket();
      for (int i = 0; i < list.Count; i++)
        if (list[i].Item2 > threshold)
          resultList.Add(list[i]);
      return resultList;
    }

    private void LoadDataItem_Click(object sender, EventArgs e)
    {
      loadDialogOpen(0);
    }

    private void AverageCompItem_Click(object sender, EventArgs e)
    {
      if (AverageDrawPointsNoStim.Count > 0 && AverageDrawPointsStim.Count > 0 && AvgToolStripMenuItem.Checked == true)
      {
        SpikeDataPacket avglist1 = new SpikeDataPacket();
        SpikeDataPacket avglist2 = new SpikeDataPacket();
        foreach (PointF point in AveragePointsNoStim[(int)numericNoStim.Value - 1])
          avglist1.Add(new SpikeData(point.X, point.Y));

        foreach (PointF point in AveragePointsStim[(int)numericAfterStim.Value - 1])
          avglist2.Add(new SpikeData(point.X, point.Y));
        //FCompareForm compareForm = new FCompareForm(AveragePointsNoStim[(int)numericNoStim.Value - 1], AveragePointsStim[(int)numericAfterStim.Value - 1]);
        FCompareForm compareForm = new FCompareForm(avglist1, avglist2);
        compareForm.Show(this);
      }
      else
      {
        MessageBox.Show("Нечего отображать", "Сравнение характеристик",
        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void HeatMapItem_Click(object sender, EventArgs e)
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

        HeatPictureForm hpf = new HeatPictureForm(NoStimSpikeList, StimSpikeList, controlGroupBox.Text) { Owner = this };
        hpf.Show(this);

      }
      else
      {
        MessageBox.Show("Нечего отображать", "Карта спайковых характеристик",
        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void AvgToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
      Refresh_Graphs();
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
        BuildItem.ShowDropDown();
      }
    }

    private void LoadHeatmapItem_Click(object sender, EventArgs e)
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
              controlGroupBox.Text = System.IO.Path.GetFileNameWithoutExtension(dialog.FileName);
              loadData(FilePath, 1);

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


    private void CommonSettingsItem_Click(object sender, EventArgs e)
    {
      new SettingsForm().Show(this);
    }



    public SpikeDataPacket buildNormalized(SpikeDataPacket list)
    {
      SpikeDataPacket resultList = new SpikeDataPacket();
      double max = double.MinValue;
      for (int i = 0; i < list.Count; i++)
        if (list[i].Item2 > max) max = list[i].Item2;
      foreach (SpikeData data in list)
        if (Math.Abs(max) > eps) resultList.Add(new SpikeData(data.Item1, data.Item2 / Math.Abs(max)));
        else resultList.Add(new SpikeData(data.Item1, data.Item2));
      return resultList;
    }

    private void CorrMatrixItem_Click(object sender, EventArgs e)
    {
      

      List<SpikeDataPacket> fullist = new List<SpikeDataPacket>();
      fullist.AddRange(NoStimSpikeList);
      fullist.AddRange(StimSpikeList);
      List<SpikeDataPacket> fullcor = new List<SpikeDataPacket>();

      for (int i = 0; i < fullist.Count; i++)
      {
        SpikeDataPacket row = new SpikeDataPacket();
        for (int j = 0; j < fullist.Count; j++)

          switch (Properties.Settings.Default.methodtype)
          {
            case 2:
              row.Add(new SpikeData(0, countCorrv3(fullist[i], fullist[j])));
              Properties.Settings.Default.moveforcorr = false;
              break;

            case 1:
              row.Add(new SpikeData(0, countCorrv2(fullist[i], fullist[j])));
              Properties.Settings.Default.moveforcorr = true;
              break;

            case 0:
              row.Add(new SpikeData(0, countCorr(fullist[i], fullist[j])));
              Properties.Settings.Default.moveforcorr = false;
              break;
          }
        fullcor.Add(row);
      }




      HeatPictureForm newhpf = new HeatPictureForm(fullcor, new List<SpikeDataPacket>(), "Корреляция") { Owner = this };
      newhpf.Show(this);

    }

    private void RemoveCharactItem_Click(object sender, EventArgs e)
    {
      if (NoStimSpikeList == null || NoStimSpikeList.Count <= 0)
        MessageBox.Show("Не загружены данные", "Редактирование данных о характеристиках",
        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      else
        new EraseCharactForm().Show(this);
    }

    private void MAItem_Click(object sender, EventArgs e)
    {


      if (MAItem.Checked == true)
      {
        MAParamItem.Enabled = false;
        MAParamTB.Enabled = false;
        MAItem.Checked = false;
      }

      else
      {
        MAParamItem.Enabled = true;
        MAParamTB.Enabled = true;
        MAItem.Checked = true;
      }

      if (GlobalData != null && GlobalData.Count > 0 && GlobalDataOrig != null && GlobalDataOrig.Count > 0)
        proceedData();


    }

    private void ApproxItem_Click(object sender, EventArgs e)
    {

      if (ApproxItem.Checked == true)
      {
        ApproxItem.Checked = false;
        ApproxParamItem.Enabled = false;
        ApproxParamText.Enabled = false;
      }
      else
      {
        ApproxItem.Checked = true;
        ApproxParamItem.Enabled = true;
        ApproxParamText.Enabled = true;
      }
        if (GlobalData != null && GlobalData.Count > 0 && GlobalDataOrig != null && GlobalDataOrig.Count > 0)
        proceedData();

    }

    private void checkParam()
    {
      int param = Convert.ToInt32(MAParamTB.Text);
      int res = -1;
      Math.DivRem(param, 2, out res);
      if (res == 0) MAParamTB.Text = (param + 1) + "";
    }

    private void MAParamTB_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter && MAItem.Checked && GlobalData != null && GlobalData.Count > 0 && GlobalDataOrig != null && GlobalDataOrig.Count > 0)
      {
        checkParam();
        proceedData();
        
      }
    }

    private void MAParamTB_KeyPress(object sender, KeyPressEventArgs e)
    {
      int isNum = 0;
      if (!int.TryParse(e.KeyChar.ToString(), out isNum) && !char.IsControl(e.KeyChar))
        e.Handled = true;
    }

    private void обработкаСигналаToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
    {
      checkParam();
    }

    private void togetherButton_CheckedChanged(object sender, EventArgs e)
    {
      Refresh_Graphs();
    }

    private void separateButton_CheckedChanged(object sender, EventArgs e)
    {
      Refresh_Graphs();
    }

    private void ApproxParamText_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter && MAItem.Checked && GlobalData != null && GlobalData.Count > 0 && GlobalDataOrig != null && GlobalDataOrig.Count > 0)
      {
        int param = Convert.ToInt32(ApproxParamText.Text);
        if (param < 4) ApproxParamText.Text = 4 + "";
        proceedData();

      }
    }

    private void ApproxParamText_KeyPress(object sender, KeyPressEventArgs e)
    {
      int isNum = 0;
      if (!int.TryParse(e.KeyChar.ToString(), out isNum) && !char.IsControl(e.KeyChar))
        e.Handled = true;
    }

    #region Старое рисование

    //private void StimCharacter_Paint(object sender, PaintEventArgs e)
    //{
    //  Brush brush = new SolidBrush(Color.FromArgb(100, 50, 50, 50));
    //  Pen mainpen = new Pen(brush, 2);
    //  for (int SpikeIdx = 0; SpikeIdx < StimSpikeList.Count && SpikeIdx < numericAfterStim.Value; SpikeIdx++)
    //  {
    //    for (int i = 1; i < StimSpikeList[SpikeIdx].Count; i++)
    //    {
    //      //int Ciferka = 9;
    //      // brush = new SolidBrush((Color.FromArgb((byte)(200 - Ciferka * (StimSpikeList.Count - SpikeIdx)), (byte)(200 - Ciferka * (StimSpikeList.Count - SpikeIdx)), (byte)(200 - Ciferka * (StimSpikeList.Count - SpikeIdx)))));
    //      // mainpen = new Pen(brush, 2);
    //      e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
    //      e.Graphics.DrawLine(mainpen,
    //        (float)StimSpikeList[SpikeIdx][i - 1].Item1 * KxBottom,
    //        (float)(e.ClipRectangle.Height - StimSpikeList[SpikeIdx][i - 1].Item2 * KyBottom),
    //        (float)StimSpikeList[SpikeIdx][i].Item1 * KxBottom,
    //        (float)(e.ClipRectangle.Height - StimSpikeList[SpikeIdx][i].Item2 * KyBottom));
    //    }
    //  }


    //  brush = new SolidBrush(Color.Aqua);
    //  mainpen = new Pen(brush, 5);
    //  if (AverageDrawPointsStim.Count > 0 && numericAfterStim.Value >= 0 && numericAfterStim.Value <= AverageDrawPointsStim.Count && AvgToolStripMenuItem.Checked == true)
    //  {
    //    PointF[] AverageList = (AverageDrawPointsStim[(int)numericAfterStim.Value - 1]).ToArray();
    //    if (AverageList.Count() > 1) e.Graphics.DrawLines(mainpen, AverageList);
    //  }

    //}

    //private void NoStimCharacter_Paint(object sender, PaintEventArgs e)
    //{
    //  Brush brush = new SolidBrush(Color.FromArgb(100, 50, 50, 50));
    //  Pen mainpen = new Pen(brush, 2);
    //  for (int SpikeIdx = 0; SpikeIdx < NoStimSpikeList.Count && SpikeIdx < numericNoStim.Value && SpikeIdx < nostimcount; SpikeIdx++)
    //  {
    //    for (int i = 1; i < NoStimSpikeList[SpikeIdx].Count; i++)
    //    {
    //      // int Ciferka = 9;
    //      // brush = new SolidBrush((Color.FromArgb((byte)(200 - Ciferka * (StimSpikeList.Count - SpikeIdx)), (byte)(200 - Ciferka * (StimSpikeList.Count - SpikeIdx)), (byte)(200 - Ciferka * (StimSpikeList.Count - SpikeIdx)))));
    //      // mainpen = new Pen(brush, 4);
    //      e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
    //      e.Graphics.DrawLine(mainpen,
    //        (float)NoStimSpikeList[SpikeIdx][i - 1].Item1 * KxBottom,
    //        (float)(e.ClipRectangle.Height - NoStimSpikeList[SpikeIdx][i - 1].Item2 * KyBottom),
    //        (float)NoStimSpikeList[SpikeIdx][i].Item1 * KxBottom,
    //        (float)(e.ClipRectangle.Height - NoStimSpikeList[SpikeIdx][i].Item2 * KyBottom));
    //    }
    //  }

    //  brush = new SolidBrush(Color.Blue);
    //  mainpen = new Pen(brush, 5);
    //  if (AverageDrawPointsNoStim.Count > 0 && numericNoStim.Value >= 0 && AvgToolStripMenuItem.Checked == true)
    //  {
    //    PointF[] AverageList = (AverageDrawPointsNoStim[(int)numericNoStim.Value - 1]).ToArray();

    //    if (AverageList.Count() > 0) e.Graphics.DrawLines(mainpen, AverageList);
    //  }

    //}

    //private void SpikeGraph_Paint(object sender, PaintEventArgs e)
    //{
    //  Brush brush = new SolidBrush(Color.Black);
    //  Pen mainpen = new Pen(brush);
    //  for (int i = 1; i < GlobalData.Count; i++)
    //  {

    //    e.Graphics.DrawLine(mainpen,
    //      (float)GlobalData[i - 1].Item1 * KxTop,
    //      (float)(e.ClipRectangle.Height - GlobalData[i - 1].Item2 * KyTop),
    //      (float)GlobalData[i].Item1 * KxTop,
    //      (float)(e.ClipRectangle.Height - GlobalData[i].Item2 * KyTop));
    //  }
    //  Brush threshholdbrush = new SolidBrush(Color.Red);
    //  Pen thresholdpen = new Pen(threshholdbrush);
    //  e.Graphics.DrawLine(thresholdpen, (float)0, (float)(e.ClipRectangle.Height - threshold * KyTop), (float)e.ClipRectangle.Width, (float)(e.ClipRectangle.Height - threshold * KyTop));
    //}

    #endregion
  }
}
