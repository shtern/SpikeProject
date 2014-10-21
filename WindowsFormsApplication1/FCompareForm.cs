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

    PointList Average_pre;
    PointList Average_post;

    public FCompareForm(PointList average_pre, PointList average_post)
    {
      InitializeComponent();
      Average_post = average_post;
      Average_pre = average_pre;
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
      if (Average_pre.Count > 0)
      {
        PointList TempList = new PointList();
        for (int i = 0; i < Average_pre.Count; i++)
          TempList.Add(new PointF(Average_pre[i].X * Kx, NormalizedGraph.Height - Average_pre[i].Y * Ky));
        PointF[] AverageList = TempList.ToArray();
        if (AverageList.Count() > 1) e.Graphics.DrawLines(mainpen, AverageList);
      }
      brush = new SolidBrush(Color.Aqua);
      mainpen = new Pen(brush, 5);
      if (Average_post.Count > 0)
      {
        PointList TempList = new PointList();
        for (int i = 0; i < Average_post.Count; i++)
          TempList.Add(new PointF(Average_post[i].X * Kx, NormalizedGraph.Height - Average_post[i].Y * Ky));
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
      if (Average_pre.Count > 0)
      {
        PointF[] AverageList = (Normalize(Average_pre)).ToArray();
        if (AverageList.Count() > 1) e.Graphics.DrawLines(mainpen, AverageList);
      }
      brush = new SolidBrush(Color.Aqua);
      mainpen = new Pen(brush, 5);
      if (Average_post.Count > 0)
      {
        PointF[] AverageList = (Normalize(Average_post)).ToArray();
        if (AverageList.Count() > 1) e.Graphics.DrawLines(mainpen, AverageList);
      }
    }

  }
}
