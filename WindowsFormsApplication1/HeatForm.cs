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

    double eps = 1e-20;
    public HeatForm(List<SpikeDataPacket> list)
    {
      InitializeComponent();
      DGV.ClearSelection();
      DGV.CurrentCell = null;
      fillData(DGV, list);
      fillData(DGV_Norm, buildNormalized(list));
      DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      //DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
      DGV_Norm.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      //DGV_Norm.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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

          if (Math.Abs(_x[1]) > 0 && Math.Abs(_y[1]) > eps)
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

    private List<SpikeDataPacket> buildNormalized(List<SpikeDataPacket> list)
    {
      List<SpikeDataPacket> resultList = new List<SpikeDataPacket>();
      for (int i = 0; i < list.Count; i++)
      {
        SpikeDataPacket temppacket = new SpikeDataPacket();
        double max = eps;
        for (int j = 0; j < list[i].Count; j++)
          if (list[i][j].Item2 > max) max = list[i][j].Item2;
        if (max > eps)
          for (int j = 0; j < list[i].Count; j++)
            temppacket.Add(new Tuple<double, double>(list[i][j].Item1, list[i][j].Item2 / max));
        else temppacket.Add(new Tuple<double, double>(eps,eps));
        resultList.Add(temppacket);
      }
      return resultList;
    }

    void fillData(DataGridView gridview,List<SpikeDataPacket> list)
    {
      int maxRow = list.Count;
      int maxCol = list.Last().Count;

      for (int i = 0; i < list.Count; i++)
      if (list[i].Count < maxCol && list[i].Count>1) maxCol = list[i].Count;

      double factor = 999;
      double minVal = 0;
      double maxVal = 0;
      for (int i = 0; i < list.Count; i++)
        for (int j = 0; j < list[i].Count; j++)
        {
          if (minVal > list[i][j].Item2) minVal = list[i][j].Item2;
          if (maxVal < list[i][j].Item2) maxVal = list[i][j].Item2;
        }
      gridview.RowHeadersVisible = false;
      gridview.ColumnHeadersVisible = false;
      gridview.AllowUserToAddRows = false;
      gridview.AllowUserToOrderColumns = false;
      gridview.CellBorderStyle = DataGridViewCellBorderStyle.None;

      int rowHeight = gridview.ClientSize.Height / maxRow - 1;
      int colWidth = gridview.ClientSize.Width / maxCol - 1;

      for (int c = 0; c < maxCol; c++) gridview.Columns.Add(c.ToString(), "");
      for (int c = 0; c < maxCol; c++) gridview.Columns[c].Width = colWidth;
      gridview.Rows.Add(maxRow);
      for (int r = 0; r < maxRow; r++) gridview.Rows[r].Height = rowHeight;

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
        for (int c = 0; c < maxCol && c<list[r].Count; c++)
        {
          gridview[c, r].Style.BackColor =
                         colors[Convert.ToInt16((list[r][c].Item2 / maxVal) * factor)];
        }
      }
    }

    private Color HeatMapColor(double value, double min, double max)
    {
      //Это старая и ненужная версия, раскрашивает в синий цвет, но она работает, и мне жалко её отсюда удалять
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
