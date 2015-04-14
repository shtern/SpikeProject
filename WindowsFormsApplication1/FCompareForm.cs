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
    #endregion

    SpikeDataPacket List1;
    SpikeDataPacket List2;
    PointList PList1;
    PointList PList2;
    int Num1, Num2,move=0;
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

    public FCompareForm(SpikeDataPacket list1, SpikeDataPacket list2, int num1, int num2, int m,double corr)
    {
      InitializeComponent();
      move = m;
      moveNumeric.Value = move;
      moveNumeric.Visible = true;

      doCorrTask();


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
