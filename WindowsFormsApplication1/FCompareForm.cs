﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace SpikeProject
{

  #region definitions
  using SpikeDataPacket = List<Tuple<double, double>>;
  using SpikeData = Tuple<double, double>;
  using PointList = List<PointF>;

  #endregion

  public partial class FCompareForm : Form
  {
    #region Константы
    //int Kx = 300;
    //int Ky = 2000;
    double eps = 1e-10;
    #endregion

    SpikeDataPacket List1;
    SpikeDataPacket List2;
    SpikeDataPacket List1Last;
    SpikeDataPacket List2Last;
    SpikeDataPacket List1Orig;
    SpikeDataPacket List2Orig;
    double CorrOrig;
    PointList PList1;
    PointList PList2;
    int Num1, Num2;
    List<double> moveList;
    double Corr;
    int left_bord=0, right_bord=0, max_M=0;
    GraphPane compare_pane;
    GraphPane normalized_compare_pane;
    



    public FCompareForm(SpikeDataPacket list1, SpikeDataPacket list2)
    {
      InitializeComponent();
      List1 = list1;
      List2 = list2;
      настройкиToolStripMenuItem.Visible = false;

      compare_pane = compareZedGraph.GraphPane;
      compare_pane.Title.Text = "Сравнение средних до и во время стимуляции";
      compare_pane.XAxis.Title.Text = "Время, с";
      compare_pane.YAxis.Title.Text = "Интенсивность свечения, ед";

      normalized_compare_pane = normalizedCompareZedGraph.GraphPane;
      normalized_compare_pane.Title.Text = "Сравнение средних, нормированных по амплитуде";
      normalized_compare_pane.XAxis.Title.Text = "Время, с";
      normalized_compare_pane.YAxis.Title.Text = "Интенсивность свечения, ед";
      Draw_Compare();
      Draw_Compare_Normalized();
    }

    public FCompareForm(SpikeDataPacket list1, SpikeDataPacket list2, int num1, int num2, double corr)
    {
      InitializeComponent();
      List1 = list1;
      List2 = list2;
      List1Orig = list1;
      List2Orig = list2;
      Num1 = num1;
      Num2 = num2;
      Corr = corr;
      compareLabel.Visible = true;
      CorrValueText.Visible = true;
      CorrOrig = corr;
      List1Last = list1;
      List2Last = movePacket(list1, list2);

      if (list1 != list2)
      {
        if (Properties.Settings.Default.moveforcorr)
        {
          prepareMoveList();
        }

      }
      else
      {
        moveNumeric.Visible = false;
        отображатьСоСдвигомToolStripMenuItem.Available = false;
      }

      doCorrTask();

    }

 


    private void prepareMoveList()
    {
      moveNumeric.Visible = true;
      moveList = new List<double>();
      Corr = double.MinValue;
      List2 = movePacket(List1, List2);
      SpikeDataPacket packet1 = List1, packet2 = List2;
      int minsize = Math.Min(packet1.Count, packet2.Count);
      int size = (int)Math.Truncate(minsize * 0.8);
      int diff = minsize - size;
      max_M = Math.Abs((int)Math.Truncate(diff * 0.7));
      int center1 = findMax(packet1), left_bord1 = (center1 - MainForm.LeftMedian > 0) ? center1 - MainForm.LeftMedian : 0, right_bord1 = (center1 + MainForm.RightMedian < packet1.Count) ? center1 + MainForm.RightMedian : packet1.Count;
      int center2 = findMax(packet2), left_bord2 = (center2 - MainForm.LeftMedian > max_M) ? center2 - MainForm.LeftMedian : max_M, right_bord2 = (center2 + MainForm.RightMedian + max_M < packet2.Count) ? center2 + MainForm.RightMedian : packet2.Count - max_M;
      left_bord = Math.Max(Math.Min(left_bord1, left_bord2), max_M);
      right_bord = Math.Min(right_bord1, right_bord2);

      moveNumeric.Minimum = -max_M;
      moveNumeric.Maximum = max_M;

      double topsum = 0;
      double sump1 = 0;
      double sump2 = 0;
      for (int m = -max_M; m <= max_M; m++)
      {
        double avg1 = countAverage(packet1.GetRange(left_bord, right_bord - left_bord));
        double avg2 = countAverage(packet2.GetRange(left_bord + m, right_bord - left_bord));
        sump1 = 0;
        sump2 = 0;
        topsum = 0;
        for (int i = left_bord; i < right_bord; i++)
          // if (i < size)
          topsum += (packet1[i].Item2 - avg1) * (packet2[i + m].Item2 - avg2);

        for (int i = left_bord; i < right_bord; i++)
          sump1 += Math.Pow(packet1[i].Item2 - avg1, 2);

        for (int i = left_bord + m; i < right_bord + m; i++)
          sump2 += Math.Pow(packet2[i].Item2 - avg2, 2);

        Corr = (Math.Sqrt(sump1 * sump2) > eps) ? (topsum / Math.Sqrt(sump1 * sump2)) : 0;
        moveList.Add(Corr);
        if (Math.Abs(Corr - CorrOrig) < eps)
          moveNumeric.Value = m;
      }
    }

    public void doCorrTask()
    {
      PList1 = new PointList();
      PList2 = new PointList();
      foreach (SpikeData data in List1)
        PList1.Add(new PointF((float)data.Item1, (float)data.Item2));

      foreach (SpikeData data in List2)
        PList2.Add(new PointF((float)data.Item1, (float)data.Item2));

      compare_pane = compareZedGraph.GraphPane;
      compare_pane.Title.Text = "Сравнение средних до и во время стимуляции";
      compare_pane.XAxis.Title.Text = "Время, с";
      compare_pane.YAxis.Title.Text = "Интенсивность свечения, ед";

      normalized_compare_pane = normalizedCompareZedGraph.GraphPane;
      normalized_compare_pane.Title.Text = "Сравнение средних, нормированных по амплитуде";
      normalized_compare_pane.XAxis.Title.Text = "Время, с";
      normalized_compare_pane.YAxis.Title.Text = "Интенсивность свечения, ед";
      Draw_Compare();
      Draw_Compare_Normalized();

      compareLabel.Text = "Сравнение характеристики №" + Num1 + " с характеристикой №" + Num2;
      CorrValueText.Text = "Значение корелляции " + CorrOrig;
      Point coordinates = compareLabel.Location;
      coordinates.X = this.Width - 350;
      CorrValueText.Location = coordinates;
      this.Text = "Сравнение характеристики №" + Num1 + " с характеристикой №" + Num2;

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




 


    public PointList Normalize(PointList list)
    {
      float ymax = list[0].Y;
      for (int i = 0; i < list.Count; i++)
      {
        if (list[i].Y > ymax)
          ymax = list[i].Y;
      }
      
      PointList Normalized_list = new PointList();
      for (int i = 0; i < list.Count; i++)
      {
        //PointF point = new PointF(list[i].X*Kx, NormalizedGraph.Height - ((list[i].Y)/ymax) * 200 );
        PointF point = new PointF(list[i].X, list[i].Y/ ymax);
        Normalized_list.Add(point);
      }


      return Normalized_list;
    }

    public SpikeDataPacket Normalize(SpikeDataPacket list)
    {
      double ymax = list[0].Item2;
      for (int i = 0; i < list.Count; i++)
      {
        if (list[i].Item2 > ymax)
          ymax = list[i].Item2;
      }

      SpikeDataPacket Normalized_list = new SpikeDataPacket();
      
      for (int i = 0; i < list.Count; i++)
        Normalized_list.Add(new SpikeData(list[i].Item1, list[i].Item2 / ymax));

      return Normalized_list;
    }

    private void Draw_Compare()
    {
      compare_pane.CurveList.Clear();
      PointPairList list = new PointPairList();
      for (int i = 0; i < List1.Count; i++)
      {

        list.Add(List1[i].Item1, List1[i].Item2);


        LineItem curve = compare_pane.AddCurve(null, list, Color.Blue, SymbolType.None);
        curve.Line.Width = 5;
        curve.Line.IsSmooth = true;
      }

      list = new PointPairList();
      for (int i = 0; i < List2.Count; i++)
      {

        list.Add(List2[i].Item1, List2[i].Item2);


        LineItem curve = compare_pane.AddCurve(null, list, Color.Violet, SymbolType.None);
        curve.Line.Width = 5;
        curve.Line.IsSmooth = true;
      }
      compareZedGraph.AxisChange();
      compareZedGraph.Invalidate();

    }

    private void Draw_Compare_Normalized()
    {
      normalized_compare_pane.CurveList.Clear();
      PointPairList list = new PointPairList();
      SpikeDataPacket normlist = Normalize(List1);
      //PointList plist = Normalize(PList1);
      for (int i = 0; i < normlist.Count; i++)
      {

        list.Add(normlist[i].Item1, normlist[i].Item2);


        LineItem curve = normalized_compare_pane.AddCurve(null, list, Color.Blue, SymbolType.None);
        curve.Line.Width = 5;
        curve.Line.IsSmooth = true;
      }

      list = new PointPairList();
      normlist = Normalize(List2);
      //plist = Normalize(PList2);
      for (int i = 0; i < normlist.Count; i++)
      {

        list.Add(normlist[i].Item1, normlist[i].Item2);


        LineItem curve = normalized_compare_pane.AddCurve(null, list, Color.Violet, SymbolType.None);
        curve.Line.Width = 5;
        curve.Line.IsSmooth = true;
      }
      normalizedCompareZedGraph.AxisChange();
      normalizedCompareZedGraph.Invalidate();

    }

    private void moveNum_ValueChanged(object sender, EventArgs e)
    {
      List1 = List1Last.GetRange(left_bord, right_bord - left_bord);
      List2 = new SpikeDataPacket();
      for (int i = 0; i < List1.Count; i++)
        List2.Add(new SpikeData(List1[i].Item1, List2Last[left_bord + (int)moveNumeric.Value + i].Item2));
      Corr = moveList[(int)moveNumeric.Value + max_M];
      doCorrTask();
      CorrValueText.Text = "Значение корелляции " + Corr;
      //CompareGraph.Refresh();
      //NormalizedGraph.Refresh();


    }

    private void отображатьСоСдвигомToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (отображатьСоСдвигомToolStripMenuItem.Checked == true)
      {
        отображатьСоСдвигомToolStripMenuItem.Checked = false;
        moveNumeric.Visible = false;
        List1 = List1Orig;
        List2 = List2Orig;
        Corr = CorrOrig;
        doCorrTask();
      }
      else
      {
        отображатьСоСдвигомToolStripMenuItem.Checked = true;
        if (moveList == null)
        {
          prepareMoveList();
        }
        moveNumeric.Visible = true;
        List1 = List1Last;
        List2 = List2Last;
        doCorrTask();
      }
    }
    #region старое рисование

    //private void CompareGraph_Paint(object sender, PaintEventArgs e)
    //{
    //  Brush brush;
    //  Pen mainpen;
    //  brush = new SolidBrush(Color.Blue);
    //  mainpen = new Pen(brush, 5);
    //  if (PList1.Count > 0)
    //  {
    //    PointList TempList = new PointList();
    //    for (int i = 0; i < PList1.Count; i++)
    //      TempList.Add(new PointF(PList1[i].X * Kx, NormalizedGraph.Height - PList1[i].Y * Ky));
    //    PointF[] AverageList = TempList.ToArray();
    //    if (AverageList.Count() > 1) e.Graphics.DrawLines(mainpen, AverageList);
    //  }
    //  brush = new SolidBrush(Color.Aqua);
    //  mainpen = new Pen(brush, 5);
    //  if (PList2.Count > 0)
    //  {
    //    PointList TempList = new PointList();
    //    for (int i = 0; i < PList2.Count; i++)
    //      TempList.Add(new PointF(PList2[i].X * Kx, NormalizedGraph.Height - PList2[i].Y * Ky));
    //    PointF[] AverageList = TempList.ToArray();
    //    if (AverageList.Count() > 1) e.Graphics.DrawLines(mainpen, AverageList);
    //  }
    //}




    //private void NormalizedGraph_Paint(object sender, PaintEventArgs e)
    //{
    //  Brush brush;
    //  Pen mainpen;
    //  brush = new SolidBrush(Color.Blue);
    //  mainpen = new Pen(brush, 5);
    //  if (PList1.Count > 0)
    //  {
    //    PointF[] AverageList = (Normalize(PList1)).ToArray();
    //    if (AverageList.Count() > 1) e.Graphics.DrawLines(mainpen, AverageList);
    //  }
    //  brush = new SolidBrush(Color.Aqua);
    //  mainpen = new Pen(brush, 5);
    //  if (PList2.Count > 0)
    //  {
    //    PointF[] AverageList = (Normalize(PList2)).ToArray();
    //    if (AverageList.Count() > 1) e.Graphics.DrawLines(mainpen, AverageList);
    //  }
    //}

#endregion

    #region старые методы
    public FCompareForm(PointList plist1, PointList plist2)
    {
      InitializeComponent();
      List1 = new SpikeDataPacket();
      List2 = new SpikeDataPacket();
      foreach (PointF point in plist1)
        List1.Add(new SpikeData(point.X, point.Y));

      foreach (PointF point in plist2)
        List2.Add(new SpikeData(point.X, point.Y));

      //PList1 = plist1;
      //PList2 = plist2;
      compare_pane = compareZedGraph.GraphPane;
      compare_pane.Title.Text = "Сравнение средних до и во время стимуляции";
      compare_pane.XAxis.Title.Text = "Время, с";
      compare_pane.YAxis.Title.Text = "Интенсивность свечения, ед";

      normalized_compare_pane = normalizedCompareZedGraph.GraphPane;
      normalized_compare_pane.Title.Text = "Сравнение средних, нормированных по амплитуде";
      normalized_compare_pane.XAxis.Title.Text = "Время, с";
      normalized_compare_pane.YAxis.Title.Text = "Интенсивность свечения, ед";
      Draw_Compare();
      Draw_Compare_Normalized();
    }



    public FCompareForm(SpikeDataPacket list1, SpikeDataPacket list2, int num1, int num2, double corr, int PQPQP)
    {
      InitializeComponent();
      List1 = list1;
      List2 = list2;
      Num1 = num1;
      Num2 = num2;
      Corr = corr;
      compareLabel.Visible = true;
      CorrValueText.Visible = true;

      moveNumeric.Visible = true;
      CorrOrig = corr;
      List1Last = list1;
      List2Last = movePacket(list1, list2);


      //moveList = new List<int>();
      //move = m;
      //moveNumeric.Value = move;
      moveList = new List<double>();
      Corr = double.MinValue;
      List2 = movePacket(List1, List2);
      SpikeDataPacket packet1 = List1, packet2 = List2;
      int minsize = Math.Min(packet1.Count, packet2.Count);
      int size = (int)Math.Truncate(minsize * 0.8);
      int diff = minsize - size;
      max_M = Math.Abs((int)Math.Truncate(diff * 0.7));
      int center1 = findMax(packet1), left_bord1 = (center1 - MainForm.LeftMedian > 0) ? center1 - MainForm.LeftMedian : 0, right_bord1 = (center1 + MainForm.RightMedian < packet1.Count) ? center1 + MainForm.RightMedian : packet1.Count;
      int center2 = findMax(packet2), left_bord2 = (center2 - MainForm.LeftMedian > max_M) ? center2 - MainForm.LeftMedian : max_M, right_bord2 = (center2 + MainForm.RightMedian + max_M < packet2.Count) ? center2 + MainForm.RightMedian : packet2.Count - max_M;
      left_bord = Math.Max(Math.Min(left_bord1, left_bord2), max_M);
      right_bord = Math.Min(right_bord1, right_bord2);

      moveNumeric.Minimum = -max_M;
      moveNumeric.Maximum = max_M;


      if (list1 != list2)
      {


        double topsum = 0;
        double sump1 = 0;
        double sump2 = 0;
        for (int m = -max_M; m <= max_M; m++)
        {
          double avg1 = countAverage(packet1.GetRange(left_bord, right_bord - left_bord));
          double avg2 = countAverage(packet2.GetRange(left_bord + m, right_bord - left_bord));
          sump1 = 0;
          sump2 = 0;
          topsum = 0;
          for (int i = left_bord; i < right_bord; i++)
            // if (i < size)
            topsum += (packet1[i].Item2 - avg1) * (packet2[i + m].Item2 - avg2);

          for (int i = left_bord; i < right_bord; i++)
            sump1 += Math.Pow(packet1[i].Item2 - avg1, 2);

          for (int i = left_bord + m; i < right_bord + m; i++)
            sump2 += Math.Pow(packet2[i].Item2 - avg2, 2);

          Corr = (Math.Sqrt(sump1 * sump2) > eps) ? (topsum / Math.Sqrt(sump1 * sump2)) : 0;
          moveList.Add(Corr);
          if (Math.Abs(Corr - CorrOrig) < eps)
          {
            moveNumeric.Value = m;

            //List1 = packet1.GetRange(left_bord, right_bord - left_bord);
            //List2 = new SpikeDataPacket();
            //for (int i = 0; i < List1.Count; i++)
            //  List2.Add(new SpikeData(List1[i].Item1, packet2[left_bord + m + i].Item2));
            //CompareGraph.Refresh();
            //NormalizedGraph.Refresh();


          }
        }
      }
      else
        moveNumeric.Visible = false;


      doCorrTask();


    }

    #endregion 

  }
}
