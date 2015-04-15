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

  #region definitions
  using SpikeDataPacket = List<Tuple<double, double>>;
  using SpikeData = Tuple<double, double>;
  using PointList = List<PointF>;

  #endregion

  public partial class FCompareForm : Form
  {
    #region Константы
    int Kx = 300;
    int Ky = 2000;
    double eps = 1e-20;
    #endregion

    SpikeDataPacket List1;
    SpikeDataPacket List2;
    PointList PList1;
    PointList PList2;
    int Num1, Num2,move=0;
    List<int> moveList;
    double Corr;

    public FCompareForm(PointList plist1, PointList plist2)
    {
      InitializeComponent();
      PList1 = plist1;
      PList2 = plist2;
    }

    public FCompareForm(SpikeDataPacket list1, SpikeDataPacket list2, int num1, int num2, double corr)
    {
      InitializeComponent();
      List1 = list1;
      List2 = list2;
      Num1 = num1;
      Num2 = num2;
      Corr = corr;

      doCorrTask();
      //PointList plist1 = new PointList();
      //PointList plist2 = new PointList();
      //foreach (SpikeData data in list1)
      //  plist1.Add(new PointF((float)data.Item1, (float)data.Item2));

      //foreach (SpikeData data in list2)
      //  plist2.Add(new PointF((float)data.Item1, (float)data.Item2));
      //PList1 = plist1;
      //PList2 = plist2;
      //compareLabel.Text = "Сравнение характеристики №" + num1 + " с характеристикой №" + num2;
      //NormalizedLabel.Text = "Значение корелляции " + corr;
      //Point coordinates = compareLabel.Location;
      //coordinates.X = this.Width - 350;
      //NormalizedLabel.Location = coordinates;
      //this.Text="Сравнение характеристики №" + num1 + " с характеристикой №" + num2;


    }

    public void doCorrTask()
    {
      PList1 = new PointList();
      PList2 = new PointList();
      foreach (SpikeData data in List1)
        PList1.Add(new PointF((float)data.Item1, (float)data.Item2));

      foreach (SpikeData data in List2)
        PList2.Add(new PointF((float)data.Item1, (float)data.Item2));

      compareLabel.Text = "Сравнение характеристики №" + Num1 + " с характеристикой №" + Num2;
      NormalizedLabel.Text = "Значение корелляции " + Corr;
      Point coordinates = compareLabel.Location;
      coordinates.X = this.Width - 350;
      NormalizedLabel.Location = coordinates;
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

    public double countCorrv2(SpikeDataPacket packet1, SpikeDataPacket packet2)
    {
      //packet2 = movePacket(packet1, packet2);

      int minsize = Math.Min(packet1.Count, packet2.Count);
      int size = (int)Math.Truncate(minsize * 0.8);

      int diff = minsize - size;

      double topsum = 0;
      double sump1 = 0;
      double sump2 = 0;
      double bestCorr = double.MinValue;
      double Corr = double.MinValue;
      

      for (int m = -(int)Math.Truncate(diff * 0.5); m <= (int)Math.Truncate(diff * 0.5); m++)
      {

        Corr = double.MinValue;
        double avg1 = countAverage(packet1.GetRange(diff, packet1.Count - diff - 1));
        double avg2 = countAverage(packet2.GetRange(diff + m, packet2.Count - m - diff - 1));
        sump1 = 0;
        sump2 = 0;
        topsum = 0;
        for (int i = diff; i < size - diff - 1; i++)
          if (i < size)
            topsum += (packet1[i].Item2 - avg1) * (packet2[i + m].Item2 - avg2);

        for (int i = diff; i < size - diff - 1; i++)
          sump1 += Math.Pow(packet1[i].Item2 - avg1, 2);

        for (int i = diff; i < size - diff - 1; i++)
          sump2 += Math.Pow(packet2[i + m].Item2 - avg2, 2);

        Corr = (Math.Sqrt(sump1 * sump2) > eps) ? (topsum / Math.Sqrt(sump1 * sump2)) : 0;
        bestCorr = (Corr > bestCorr) ? Corr : bestCorr;
      }
      return bestCorr;
    }

    public FCompareForm(SpikeDataPacket list1, SpikeDataPacket list2, int num1, int num2, double corr,int PQPQP)
    {
      InitializeComponent();
      List1 = list1;
      List2 = list2;
      Num1 = num1;
      Num2 = num2;
      Corr = corr;
      moveList = new List<int>();
      //move = m;
      //moveNumeric.Value = move;
      moveNumeric.Visible = true;

      int minsize = Math.Min(List1.Count, List2.Count);
      int size = (int)Math.Truncate(minsize * 0.8);

      int diff = minsize - size;

      double topsum = 0;
      double sump1 = 0;
      double sump2 = 0;
      double bestCorr = double.MinValue;
      double tempCorr = double.MinValue;


      for (int m = -(int)Math.Truncate(diff * 0.5); m <= (int)Math.Truncate(diff * 0.5); m++)
      {
        Corr = double.MinValue;
        moveList.Add(m);
        double avg1 = countAverage(List1.GetRange(diff, List1.Count - diff - 1));
        double avg2 = countAverage(List2.GetRange(diff + m, List2.Count - m - diff - 1));
        sump1 = 0;
        sump2 = 0;
        topsum = 0;
        for (int i = diff; i < size - diff - 1; i++)
          if (i < size)
            topsum += (List1[i].Item2 - avg1) * (List2[i + m].Item2 - avg2);

        for (int i = diff; i < size - diff - 1; i++)
          sump1 += Math.Pow(List1[i].Item2 - avg1, 2);

        for (int i = diff; i < size - diff - 1; i++)
          sump2 += Math.Pow(List2[i + m].Item2 - avg2, 2);

        tempCorr = (Math.Sqrt(sump1 * sump2) > eps) ? (topsum / Math.Sqrt(sump1 * sump2)) : 0;
        if (tempCorr - Corr < eps)
        {
          moveNumeric.Value = m;
          PList1 = new PointList();
          PList2 = new PointList();
          SpikeDataPacket templist1 = List1.GetRange(diff, List1.Count - diff - 1), templist2 = List2.GetRange(diff, List1.Count - diff - 1);
          for (int i = 0; i < templist1.Count; i++)
          {
            PList1.Add(new PointF((float)templist1[i].Item1, (float)templist1[i].Item2));
            PList2.Add(new PointF((float)templist1[i].Item1, (float)templist2[i].Item2));

          }
          
          break;
        }
      }

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
        PointF point = new PointF(list[i].X*Kx, NormalizedGraph.Height - ((list[i].Y)/ymax) * 200 );
        Normalized_list.Add(point);
      }


      return Normalized_list;
    }

    private void CompareGraph_Paint(object sender, PaintEventArgs e)
    {
      Brush brush;
      Pen mainpen;
      brush = new SolidBrush(Color.Blue);
      mainpen = new Pen(brush, 5);
      if (PList1.Count > 0)
      {
        PointList TempList = new PointList();
        for (int i = 0; i < PList1.Count; i++)
          TempList.Add(new PointF(PList1[i].X * Kx, NormalizedGraph.Height - PList1[i].Y * Ky));
        PointF[] AverageList = TempList.ToArray();
        if (AverageList.Count() > 1) e.Graphics.DrawLines(mainpen, AverageList);
      }
      brush = new SolidBrush(Color.Aqua);
      mainpen = new Pen(brush, 5);
      if (PList2.Count > 0)
      {
        PointList TempList = new PointList();
        for (int i = 0; i < PList2.Count; i++)
          TempList.Add(new PointF(PList2[i].X * Kx, NormalizedGraph.Height - PList2[i].Y * Ky));
        PointF[] AverageList = TempList.ToArray();
        if (AverageList.Count() > 1) e.Graphics.DrawLines(mainpen, AverageList);
      }
    }

    private void NormalizedGraph_Paint(object sender, PaintEventArgs e)
    {
      Brush brush;
      Pen mainpen;
      brush = new SolidBrush(Color.Blue);
      mainpen = new Pen(brush, 5);
      if (PList1.Count > 0)
      {
        PointF[] AverageList = (Normalize(PList1)).ToArray();
        if (AverageList.Count() > 1) e.Graphics.DrawLines(mainpen, AverageList);
      }
      brush = new SolidBrush(Color.Aqua);
      mainpen = new Pen(brush, 5);
      if (PList2.Count > 0)
      {
        PointF[] AverageList = (Normalize(PList2)).ToArray();
        if (AverageList.Count() > 1) e.Graphics.DrawLines(mainpen, AverageList);
      }
    }

    private void moveNum_ValueChanged(object sender, EventArgs e)
    {
      move = (int)moveNumeric.Value;
      

    }

  }
}
