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
  public partial class HeatPictureForm : Form
  {
    String CellName = "";
    double eps = 1e-20;
    List<SpikeDataPacket> NoStimList = new List<SpikeDataPacket>();
    List<SpikeDataPacket>   StimList = new List<SpikeDataPacket>();
    public HeatPictureForm(List<SpikeDataPacket> list,List<SpikeDataPacket> stimlist, String cellname)
    {
      InitializeComponent();
      NoStimList = buildUniform(list);
      StimList = buildUniform(stimlist);
      CellName = cellname;
      HeatPictureForm.ActiveForm.Text = cellname;

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
            if (y > eps)
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
        else temppacket.Add(new Tuple<double, double>(eps, eps));
        resultList.Add(temppacket);
      }
      return resultList;
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

    private void notStimSpikes_Paint(object sender, PaintEventArgs e)
    {
      int maxRow = NoStimList.Count;
      int maxCol = NoStimList.Last().Count;
      int rectheight = 20;
      
      for (int i = 0; i < NoStimList.Count; i++)
        if (NoStimList[i].Count < maxCol && NoStimList[i].Count > 1) maxCol = NoStimList[i].Count;
      int rectwidth = 5;
      notStimSpikes.Width = rectwidth * maxCol;
      NoStimPanel.Width = rectwidth * maxCol+20;
      notStimSpikes.Height = rectheight * NoStimList.Count;
      //Panel.Height = notStimSpikes.Height + 20;
      double factor = 999;
      double minVal = 0;
      double maxVal = 0;
      for (int i = 0; i < NoStimList.Count; i++)
        for (int j = 0; j < NoStimList[i].Count; j++)
        {
          if (minVal > NoStimList[i][j].Item2) minVal = NoStimList[i][j].Item2;
          if (maxVal < NoStimList[i][j].Item2) maxVal = NoStimList[i][j].Item2;
        }
      List<Color> baseColors = new List<Color>();  // create a color list
      baseColors.Add(Color.RoyalBlue);
      baseColors.Add(Color.LightSkyBlue);
      baseColors.Add(Color.LightGreen);
      baseColors.Add(Color.Yellow);
      baseColors.Add(Color.Orange);
      baseColors.Add(Color.Red);
      List<Color> colors = interpolateColors(baseColors, 1000);
      for (int i = 0; i < NoStimList.Count; i++)
      {
        for (int j = 0; j < NoStimList[i].Count && j < maxCol; j++)
        {
          Brush brush = new SolidBrush(colors[Convert.ToInt16((NoStimList[i][j].Item2 / maxVal) * factor)]);
          Pen pen = new Pen(brush, 5);
          e.Graphics.FillRectangle(brush, j * rectwidth, i * rectheight, rectwidth, rectheight);
        }
      }
      
    }

    private void Panel_Scroll(object sender, ScrollEventArgs e)
    {
      //pictureBox1.Refresh();
    }



    private void экспортВBMPToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Bitmap bmp = new Bitmap(notStimSpikes.Width, notStimSpikes.Height);
      notStimSpikes.DrawToBitmap(bmp, notStimSpikes.ClientRectangle);
      bmp.Save("D:\\testBmp.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
    }

    private void StimSpikes_Paint(object sender, PaintEventArgs e)
    {
      int maxRow = StimList.Count;
      int maxCol = StimList.Last().Count;
      int rectheight = 20;

      for (int i = 0; i < StimList.Count; i++)
        if (StimList[i].Count < maxCol && StimList[i].Count > 1) maxCol = StimList[i].Count;
      int rectwidth = 5;
      StimSpikes.Width = rectwidth * maxCol;
      StimPanel.Width = rectwidth * maxCol + 20;
      StimSpikes.Height = rectheight * StimList.Count;
      //Panel.Height = notStimSpikes.Height + 20;
      double factor = 999;
      double minVal = 0;
      double maxVal = 0;
      for (int i = 0; i < StimList.Count; i++)
        for (int j = 0; j < StimList[i].Count; j++)
        {
          if (minVal > StimList[i][j].Item2) minVal = StimList[i][j].Item2;
          if (maxVal < StimList[i][j].Item2) maxVal = StimList[i][j].Item2;
        }
      List<Color> baseColors = new List<Color>();  // create a color list
      baseColors.Add(Color.RoyalBlue);
      baseColors.Add(Color.LightSkyBlue);
      baseColors.Add(Color.LightGreen);
      baseColors.Add(Color.Yellow);
      baseColors.Add(Color.Orange);
      baseColors.Add(Color.Red);
      List<Color> colors = interpolateColors(baseColors, 1000);
      for (int i = 0; i < StimList.Count; i++)
      {
        for (int j = 0; j < StimList[i].Count && j < maxCol; j++)
        {
          Brush brush = new SolidBrush(colors[Convert.ToInt16((StimList[i][j].Item2 / maxVal) * factor)]);
          Pen pen = new Pen(brush, 5);
          e.Graphics.FillRectangle(brush, j * rectwidth, i * rectheight, rectwidth, rectheight);
        }
      }

    }



  }
}
