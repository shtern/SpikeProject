using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SpikeProject
{
  using SpikeDataPacket = List<Tuple<double, double>>;
  public partial class HeatForm : Form
  {
    public List<SpikeDataPacket> SpikeList;
    public HeatForm(List<SpikeDataPacket> list)
    {
      InitializeComponent();
      SpikeList = list;
      fillData();
    }

    void fillData()
    {
      int maxRow = SpikeList.Count;
      int maxCol = SpikeList[0].Count;
      double factor = 1.0;
      double mincol=0;
      double maxcol=0;
      for (int i = 0; i< SpikeList.Count;i++)
        for (int j = 0; j< SpikeList[i].Count;j++)
        { if (mincol>SpikeList[i][j].Item2) mincol=SpikeList[i][j].Item2;
          if (maxcol<SpikeList[i][j].Item2) maxcol=SpikeList[i][j].Item2;}
      DGV.RowHeadersVisible = false;
      DGV.ColumnHeadersVisible = false;
      DGV.AllowUserToAddRows = false;
      DGV.AllowUserToOrderColumns = false;
      DGV.CellBorderStyle = DataGridViewCellBorderStyle.None;
      //..

      int rowHeight = DGV.ClientSize.Height / maxRow - 1;
      int colWidth = DGV.ClientSize.Width / maxCol - 1;

      for (int c = 0; c < maxRow; c++) DGV.Columns.Add(c.ToString(), "");
      for (int c = 0; c < maxRow; c++) DGV.Columns[c].Width = colWidth;
      DGV.Rows.Add(maxRow);
      for (int r = 0; r < maxRow; r++) DGV.Rows[r].Height = rowHeight;

      List<Color> baseColors = new List<Color>();  // create a color list
      baseColors.Add(Color.RoyalBlue);
      baseColors.Add(Color.LightSkyBlue);
      baseColors.Add(Color.LightGreen);
      baseColors.Add(Color.Yellow);
      baseColors.Add(Color.Orange);
      baseColors.Add(Color.Red);
      List<Color> colors = interpolateColors(baseColors, 1000);

      for (int r = 0; r < maxRow; r++)
      {
        for (int c = 0; c < maxRow; c++)
        {
         // DGV[r, c].Style.BackColor =
           //              colors[Convert.ToInt16(SpikeList[r][c].Item2 * factor)];
          DGV[r, c].Style.BackColor = HeatMapColor(SpikeList[r][c].Item2, mincol, maxcol);

        }
      }

    }

    private Color HeatMapColor(double value, double min, double max)
    {
      Color firstColour = Color.RoyalBlue;
      Color secondColour = Color.LightSkyBlue;

      // Example: Take the RGB
      //135-206-250 // Light Sky Blue
      // 65-105-225 // Royal Blue
      // 70-101-25 // Delta

      int rOffset = Math.Max(firstColour.R, secondColour.R);
      int gOffset = Math.Max(firstColour.G, secondColour.G);
      int bOffset = Math.Max(firstColour.B, secondColour.B);

      int deltaR = Math.Abs(firstColour.R - secondColour.R);
      int deltaG = Math.Abs(firstColour.G - secondColour.G);
      int deltaB = Math.Abs(firstColour.B - secondColour.B);

      double val = (value - min) / (max - min);
      int r = rOffset - Convert.ToByte(deltaR * (1 - val));
      int g = gOffset - Convert.ToByte(deltaG * (1 - val));
      int b = bOffset - Convert.ToByte(deltaB * (1 - val));

      return Color.FromArgb(255, r, g, b);
    }


    List<Color> interpolateColors(List<Color> stopColors, int count)
    {
      SortedDictionary<float, Color> gradient = new SortedDictionary<float, Color>();
      for (int i = 0; i < stopColors.Count; i++)
        gradient.Add(1f * i / (stopColors.Count - 1), stopColors[i]);
      List<Color> ColorList = new List<Color>();

      using (Bitmap bmp = new Bitmap(count, 1))
      using (Graphics G = Graphics.FromImage(bmp))
      {
        Rectangle bmpCRect = new Rectangle(Point.Empty, bmp.Size);
        LinearGradientBrush br = new LinearGradientBrush
                                (bmpCRect, Color.Empty, Color.Empty, 0, false);
        ColorBlend cb = new ColorBlend();
        cb.Positions = new float[gradient.Count];
        for (int i = 0; i < gradient.Count; i++)
          cb.Positions[i] = gradient.ElementAt(i).Key;
        cb.Colors = gradient.Values.ToArray();
        br.InterpolationColors = cb;
        G.FillRectangle(br, bmpCRect);
        for (int i = 0; i < count; i++) ColorList.Add(bmp.GetPixel(i, 0));
        br.Dispose();
      }
      return ColorList;
    }
  }
}
