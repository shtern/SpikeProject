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
    List<PointList> Average_pre;
    List<PointList> Average_post;
    public FCompareForm(List<PointList> average_pre, List<PointList> average_post)
    {
      InitializeComponent();
      Average_post = average_post;
      Average_pre = average_pre;
    }

    private void CompareGraph_Paint(object sender, PaintEventArgs e)
    {
      Brush brush;
      Pen mainpen;
      brush = new SolidBrush(Color.Aqua);
      mainpen = new Pen(brush, 3);
      if (Average_pre.Count > 0)
      {
        //PointF[] AverageList = (Average_pre[(int)numericAfterStim.Value - 1]).ToArray();
        //if (AverageList.Count() > 1) e.Graphics.DrawLines(mainpen, AverageList);
      }

    }

  }
}
