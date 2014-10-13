using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
  #region definiions
  using SpikeDataPacket = List<Tuple<double, double>>;
  using SpikeData = Tuple<double, double>;
  using PointList = List<PointF>;

  #endregion
  public partial class FCompareForm : Form
  {
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
        if (list[i].Y < ymax)
          ymax = list[i].Y;
      }
      ymax = (list[0].Y - ymax) / 2000;
      PointList Normalized_list = new PointList();
      for (int i = 0; i < list.Count; i++)
      {
        PointF point = new PointF(list[i].X, (NormalizedGraph.Height - (((list[0].Y - list[i].Y) / 2000) / ymax) * 250));
        Normalized_list.Add(point);
        //list[i].Y /= ymax;
      }


      return Normalized_list;
    }

    private void CompareGraph_Paint(object sender, PaintEventArgs e)
    {
      Brush brush;
      Pen mainpen;
      brush = new SolidBrush(Color.Blue);
      mainpen = new Pen(brush, 3);
      if (Average_pre.Count > 0)
      {
        PointList TempList = new PointList();
        for (int i = 0; i < Average_pre.Count; i++)
          TempList.Add(new PointF(Average_pre[i].X,   Average_pre[i].Y));
        PointF[] AverageList = TempList.ToArray();
        if (AverageList.Count() > 1) e.Graphics.DrawLines(mainpen, AverageList);
      }
      brush = new SolidBrush(Color.Aqua);
      mainpen = new Pen(brush, 3);
      if (Average_post.Count > 0)
      {
        PointList TempList = new PointList();
        for (int i = 0; i < Average_post.Count; i++)
          TempList.Add(new PointF(Average_post[i].X,   Average_post[i].Y));
        PointF[] AverageList = TempList.ToArray();
        if (AverageList.Count() > 1) e.Graphics.DrawLines(mainpen, AverageList);
      }
    }

    private void NormalizedGraph_Paint(object sender, PaintEventArgs e)
    {
      Brush brush;
      Pen mainpen;
      brush = new SolidBrush(Color.Blue);
      mainpen = new Pen(brush, 3);
      if (Average_pre.Count > 0)
      {
        PointF[] AverageList = (Normalize(Average_pre)).ToArray();
        if (AverageList.Count() > 1) e.Graphics.DrawLines(mainpen, AverageList);
      }
      brush = new SolidBrush(Color.Aqua);
      mainpen = new Pen(brush, 3);
      if (Average_post.Count > 0)
      {
        PointF[] AverageList = (Normalize(Average_post)).ToArray();
        if (AverageList.Count() > 1) e.Graphics.DrawLines(mainpen, AverageList);
      }
    }

  }
}
