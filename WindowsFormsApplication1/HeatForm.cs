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
    double eps = 1e-20;
    public HeatForm(List<SpikeDataPacket> list)
    {
      InitializeComponent();
      DGV.ClearSelection();
      DGV.CurrentCell = null;
      //SpikeList = list;
      SpikeList = buildUniform(list);
      fillData();

    }


    private List<SpikeDataPacket> buildUniform(List<SpikeDataPacket> list)
    {
      double maxLenght = 0;
      double minLength = 0;
      List<SpikeDataPacket> resultList = new List<SpikeDataPacket>();
      minLength = list.First().Last().Item1;
      for (int i = 0; i < list.Count; i++)
      {
        if (list[i].Last().Item1 < minLength) minLength = list[i].Last().Item1;
        if (list[i].Last().Item1 > maxLenght) maxLenght = list[i].Last().Item1;
      }

      double StepWidth = 1e-2;
      for (int j = 0; j < list.Count; j++)
      {
        SpikeDataPacket data = list[j];
        SpikeDataPacket resultListElement = new SpikeDataPacket();
        for (double x = (list[0] != null && list[0].Count > 1) ? list[0][0].Item1 : eps; x < list[j].Last().Item1; x += StepWidth)
        {
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
            resultListElement.Add(new Tuple<double, double>(x, y));
          }
        }
        resultList.Add(resultListElement);
      }
      return resultList;
    }


    void fillData()
    {
      int maxRow = SpikeList.Count;
      int maxCol = SpikeList[0].Count;
      for (int i = 0; i < SpikeList.Count; i++)
        if (SpikeList[i].Count > maxCol) maxCol = SpikeList[i].Count;
      double factor = 999;
      double minVal = 0;
      double maxVal = 0;
      for (int i = 0; i < SpikeList.Count; i++)
        for (int j = 0; j < SpikeList[i].Count; j++)
        {
          if (minVal > SpikeList[i][j].Item2) minVal = SpikeList[i][j].Item2;
          if (maxVal < SpikeList[i][j].Item2) maxVal = SpikeList[i][j].Item2;
        }
      DGV.RowHeadersVisible = false;
      DGV.ColumnHeadersVisible = false;
      DGV.AllowUserToAddRows = false;
      DGV.AllowUserToOrderColumns = false;
      DGV.CellBorderStyle = DataGridViewCellBorderStyle.None;

      int rowHeight = DGV.ClientSize.Height / maxRow - 1;
      int colWidth = DGV.ClientSize.Width / maxCol - 1;

      for (int c = 0; c < maxCol; c++) DGV.Columns.Add(c.ToString(), "");
      for (int c = 0; c < maxCol; c++) DGV.Columns[c].Width = colWidth;
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
        for (int c = 0; c < SpikeList[r].Count; c++)
        {
          DGV[c, r].Style.BackColor =
                         colors[Convert.ToInt16((SpikeList[r][c].Item2 / maxVal) * factor)];
          //DGV[r, c].Style.BackColor = HeatMapColor(SpikeList[r][c].Item2, minVal, maxVal);

        }
      }
      // DGV.ClearSelection();
      // DGV.CurrentCell = null;

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

    private void DGV_VisibleChanged(object sender, EventArgs e)
    {
      DGV.ClearSelection();
      // DGV.CurrentCell = null;
    }

    private void HeatForm_Load(object sender, EventArgs e)
    {
      DGV.ClearSelection();
      //DGV.CurrentCell = null;
    }
  }
}
