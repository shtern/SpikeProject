using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Windows;
namespace SpikeProject
{
  using SpikeDataPacket = List<Tuple<double, double>>;
  using SpikeData = Tuple<double, double>;
  using PointList = List<PointF>;

  public partial class HeatPictureForm : Form
  {
    String CellName = "";
    PictureBox ScaleBox;
    bool doScale = false;
    double eps = 1e-20;
    int rectheight = 20;
    int rectwidth = 5;
    int ValueLabelWidth = 0;
    Bitmap NoStimBmp;
    Bitmap NormNoStimBmp;
    Bitmap StimBmp;
    Bitmap NormStimBmp;
    double Maximum = double.MinValue;
    double Minimum = double.MaxValue;
    double OldMinimum=double.MaxValue;
    MainForm parent;
    List<SpikeDataPacket> NoStimList = new List<SpikeDataPacket>();
    List<SpikeDataPacket> StimList = new List<SpikeDataPacket>();
    List<SpikeDataPacket> NormNoStimList = new List<SpikeDataPacket>();
    List<SpikeDataPacket> NormStimList = new List<SpikeDataPacket>();


    public HeatPictureForm(List<SpikeDataPacket> list,List<SpikeDataPacket> stimlist, String cellname)
    {
      InitializeComponent();
      
      if (list.Count > 0)
      {
        NoStimList = buildUniform(list);
        NormNoStimList = buildUniform(buildNormalized(list));
      }
      if (stimlist.Count > 0)
      {
        StimList = buildUniform(stimlist);
        NormStimList = buildUniform(buildNormalized(stimlist));
      }
      if (cellname.Equals("Корреляция"))
      {
        rectwidth = 25;
        NoStimList = list;
        StimList = stimlist;
        нормализацияToolStripMenuItem.Visible = false;
        ScaleBox = new PictureBox();
        doScale = true;
        открытьСравнениеХарактеристикToolStripMenuItem.Checked = true;

      }
      else
      {
        действиеПриНажатииToolStripMenuItem.Visible = false;
      }

      this.Text = cellname;
      CellName = cellname;
      if (CellName=="Корреляция")
        switch (Properties.Settings.Default.methodtype)
        {
          case 0:
            this.Text = "Коэффициент Пирсона";
            break;

          case 1:
            this.Text = "Коэффициент Пирсона со сдвигом";
            break;
          case 2:
            this.Text = "Кросс-корреляция";
            break;
          case 3:
            this.Text = "Площадь";
            break;
        }

      
      NoStimBmp = DrawTask(NoStimList);
      StimBmp = DrawTask(StimList);
      NormNoStimBmp = DrawTask(NormNoStimList);
      NormStimBmp = DrawTask(NormStimList);

      notStimSpikesSetPic();
      StimSpikesSetPic();
      if (stimlist.Count > 1)
        this.Height = NoStimPanel.Height + StimPanel.Height + 300;
      else
      {
        this.Height = NoStimPanel.Height + 100;
        NoStimLabel.Visible = false;
      }
      this.Width = Math.Max(NoStimPanel.Width, StimPanel.Width) + 50;

      if (NoStimBmp != null || NormNoStimList != null || list.Count > 1)
      for (int i = 0; i < list.Count; i++)
      {
        Label numlabel = new Label();
        numlabel.Text = (int)(list.Count - i) + "";
        Point lbllocation = NoStimPanel.Location;
        lbllocation.X -= 20;
        lbllocation.Y += (list.Count - 1 - i) * rectheight;
        numlabel.Location = lbllocation;
        this.Controls.Add(numlabel);
      }

      if (StimBmp != null || NormStimList != null || stimlist.Count>1)
        for (int i = 0; i < stimlist.Count; i++)
        {
          Label numlabel = new Label();
          numlabel.Text = (int)(stimlist.Count - i) + "";
          Point lbllocation = StimPanel.Location;
          lbllocation.X -= 20;
          lbllocation.Y += (stimlist.Count - 1 - i) * rectheight;
          numlabel.Location = lbllocation;
          this.Controls.Add(numlabel);
        }

      if (doScale)
      {
        this.Width += ScaleBox.Width + ValueLabelWidth + 150;
        
        
          ScaleBox.Height = NoStimBmp.Height;
          ScaleBox.Width = rectwidth;
          int rectcol = (ScaleBox.Height / rectheight) ;
          double step = Math.Abs(Maximum - Minimum) / (rectcol-1);
          List<SpikeDataPacket> ScaleList = new List<SpikeDataPacket>();
          double buildvalue = OldMinimum;
          Point location = NoStimPanel.Location;
          location.X += notStimSpikes.Width + 100;
          ScaleBox.Location = location;
          this.Controls.Add(ScaleBox);
          for (int i = 0; i < rectcol; i++)
          {
            SpikeDataPacket row = new SpikeDataPacket();
            row.Add(new SpikeData(0, buildvalue));
            ScaleList.Add(row);
            
            Label valuelbl = new Label();
            valuelbl.Text = (Math.Round(buildvalue, 2)).ToString();
            Point lbllocation = ScaleBox.Location;
            lbllocation.X += ScaleBox.Width + 4;
            lbllocation.Y += (rectcol - 1 - i) * rectheight + 1;
            valuelbl.Location = lbllocation;
            ValueLabelWidth = valuelbl.Width;
            this.Controls.Add(valuelbl);
            buildvalue += step;
          }
          ScaleList.Reverse();
          ScaleBox.Image = DrawTask(ScaleList);


        
        for (int i = 0; i < list.Count; i++)
        {
          Label numlabel = new Label();
          numlabel.Text = (int)(list.Count - i) + "";
          Point lbllocation = NoStimPanel.Location;
          lbllocation.X += (list.Count-1-i)*rectwidth;
          lbllocation.Y -= 15;
          numlabel.Location = lbllocation;
          this.Controls.Add(numlabel);
        }

      }

    }


    #region MAX

    public HeatPictureForm(List<SpikeDataPacket> list, List<SpikeDataPacket> stimlist, List<SpikeDataPacket> listmax, List<SpikeDataPacket> stimlistmax)
    {
      InitializeComponent();

      if (list.Count > 0)
      {
        NoStimList = buildUniform(list);
        NormNoStimList = buildUniform(buildNormalized(list));
      }
      if (stimlist.Count > 0)
      {
        StimList = buildUniform(stimlist);
        NormStimList = buildUniform(buildNormalized(stimlist));
      }
      CellName = "MegaMap";
      //List<Double> averagelist = buildMax(listmax);
      this.Text = CellName;
      NoStimBmp = DrawTask(NoStimList);
      StimBmp = DrawTask(StimList);
      NormNoStimBmp = DrawTask(NormNoStimList);
      NormStimBmp = DrawTask(NormStimList);
      notStimSpikesSetPic();
      StimSpikesSetPic();
      paintMax(buildUniform(list), listmax);
      paintMax(buildUniform(stimlist), stimlistmax);
      this.Height = NoStimPanel.Height + StimPanel.Height + 300;
      this.Width = Math.Max(NoStimPanel.Width, StimPanel.Width) + 50;
    }

    private  List<Double> buildMax(List<SpikeDataPacket> listmax)
    {
      List<Double> nostimmaxpoints = new List<double>();
      List<Double> averagelist = new List<double>();
      double eps = 10;

      //for (int i = 0; i < listmax.Count; i++)
      //  if (listmax[i].Count > maxcount) maxcount = listmax[i].Count;
      //for (int i=0; i<listmax[0].Count; i++)
      //{
      //  averagelist = new List<double>();
      //  for (int j = 0; j< listmax.Count;j++)
      //    if (i<listmax[j].Count)
      //    if (Math.Abs(listmax[j][i].Item1-listmax[0][i].Item1)<eps) averagelist.Add(listmax[j][i].Item1);
      //  if (averagelist.Count > listmax.Count / 2) nostimmaxpoints.Add(averagelist.Average());
      //}
      for (int i = 0; i < listmax[0].Count; i++)
      {
        averagelist = new List<double>();
        for (int j = 1; j < listmax.Count; j++)
        {
          double closest = ClosestVal(listmax[j], listmax[0][i].Item1);
          if (Math.Abs(listmax[0][i].Item1 -closest) < eps) averagelist.Add(closest);
        }
        if (averagelist.Count > listmax.Count / 2) nostimmaxpoints.Add(averagelist.Average());
       }

      if (nostimmaxpoints.Count == listmax[0].Count) return nostimmaxpoints;
      else
        return null;
    }

    private void paintMax(List<SpikeDataPacket> list, List<SpikeDataPacket> listmax)
    {
      List<Double> maxpoints = buildMax(listmax);
      SpikeDataPacket range = new SpikeDataPacket();
      if (maxpoints == null || maxpoints.Count == 0)
      {
        MessageBox.Show("Не удалось выделить характеристики", "Мегакарта",
        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        return;
      }
      foreach (double maxpoint in maxpoints) 
      {
        List<SpikeDataPacket> bmplist = new List<SpikeDataPacket>();
        for (int i = 0; i < list.Count; i++)
        {
          int closest = ClosestPos(list[0], maxpoint);
          if (closest-30>0 && closest+70<list[i].Count)
             range = list[i].GetRange(closest - 30, 100);
          bmplist.Add(range);
          
        }
        Bitmap bmp = DrawTask(bmplist);
        if (bmp == null)
        {
          MessageBox.Show("Не удалось выделить характеристики", "Мегакарта",
          MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          return;
        }
        String savepath = "D:\\MAPS" + DateTime.Now.ToString("yyyy_MMdd_HHmm");
        if (!System.IO.Directory.Exists(savepath))
          System.IO.Directory.CreateDirectory(savepath);
        bmp.Save(savepath + "\\Maximum" + DateTime.Now.ToString("HHmmss") + maxpoint + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
      }
    }


    public static int ClosestPos(SpikeDataPacket list, double target)
    {
      // NB Method will return int.MaxValue for a sequence containing no elements.
      // Apply any defensive coding here as necessary.
      Double closest = Double.MaxValue;
      Double minDifference = Double.MaxValue;
      int position = 0;

      for (int i = 0; i<list.Count; i++)
      {
        var difference = Math.Abs((long)list[i].Item1 - target);
        if (minDifference > difference)
        {
          minDifference = (int)difference;
          closest = list[i].Item1;
          position = i;
        }
      }

      return position;
    }

    public static double ClosestVal(SpikeDataPacket list, double target)
    {
      // NB Method will return int.MaxValue for a sequence containing no elements.
      // Apply any defensive coding here as necessary.
      Double closest = Double.MaxValue;
      Double minDifference = Double.MaxValue;
      if (list.Count == 0) return 0;
      for (int i = 0; i < list.Count; i++)
      {
        var difference = Math.Abs((long)list[i].Item1 - target);
        if (minDifference > difference)
        {
          minDifference = (int)difference;
          closest = list[i].Item1;
        }
      }
      return closest;
    }

    #endregion


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

    public List<SpikeDataPacket> buildNormalized(List<SpikeDataPacket> list)
    {
      List<SpikeDataPacket> resultList = new List<SpikeDataPacket>();
      for (int i = 0; i < list.Count; i++)
      {
        SpikeDataPacket temppacket = new SpikeDataPacket();
        double max = double.MinValue;
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

    private void notStimSpikesSetPic()
    {

      if (вклToolStripMenuItem.Checked)
      {
        if (NormNoStimBmp != null)
        {
          notStimSpikes.Image = NormNoStimBmp;
          notStimSpikes.Width = NormNoStimBmp.Width;
          notStimSpikes.Height = NormNoStimBmp.Height;
          if ( NormNoStimBmp.Width < Screen.FromControl(this).Bounds.Width )
          NoStimPanel.Width = NormNoStimBmp.Width;
          NoStimPanel.Height = NormNoStimBmp.Height + 20;

        }
        else notStimSpikes.Visible = false;
      }
      else
      {
        if (NoStimBmp != null)
        {
          notStimSpikes.Image = NoStimBmp;
          notStimSpikes.Width = NoStimBmp.Width;
          notStimSpikes.Height = NoStimBmp.Height;
          if (NoStimBmp.Width < Screen.FromControl(this).Bounds.Width)
          NoStimPanel.Width = NoStimBmp.Width;
          NoStimPanel.Height = NoStimBmp.Height + 20;
         
        }
        else notStimSpikes.Visible = false;
      };
    }

    private void StimSpikesSetPic()
    {
      if (вклToolStripMenuItem.Checked)
      {
        if (NormStimBmp != null)
        {
          StimSpikes.Image = NormStimBmp;
          StimSpikes.Width = NormStimBmp.Width;
          StimSpikes.Height = NormStimBmp.Height;
          if (NormStimBmp.Width < Screen.FromControl(this).Bounds.Width)
            StimPanel.Width = NormStimBmp.Width;
          StimPanel.Height = NormStimBmp.Height + 20;
          
        }
        else
        {
          NoStimLabel.Visible = false;
          StimSpikes.Visible = false;
          StimPanel.Visible = false;
        }
      }
      else
      {
        if (StimBmp != null)
        {

          StimSpikes.Image = StimBmp;
          StimSpikes.Width = StimBmp.Width;
          if (StimBmp.Width < Screen.FromControl(this).Bounds.Width)
            StimPanel.Width = StimBmp.Width;
          StimSpikes.Height = StimBmp.Height;
          StimPanel.Height = StimBmp.Height + 20;
        }
        else
        {
          StimLabel.Visible = false;
          StimSpikes.Visible = false;
          StimPanel.Visible = false;
        }
      };
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



    private Bitmap DrawTask(List<SpikeDataPacket> DrawList)
    {
      if (DrawList.Count <= 0) return null;
      int maxRow = DrawList.Count;
      int maxCol = DrawList.Last().Count;
      List<SpikeDataPacket> newlist = new List<SpikeDataPacket>();
      for (int i = 0; i < DrawList.Count; i++)
        if (DrawList[i].Count < maxCol && DrawList[i].Count > 1) maxCol = DrawList[i].Count;
      
      if (maxCol == 0) return null;
      Bitmap bmp = new Bitmap(rectwidth * maxCol, rectheight * DrawList.Count);
      double factor = 999;
      double minVal = Double.MaxValue;
      double maxVal = Double.MinValue;
      for (int i = 0; i < DrawList.Count; i++)
        for (int j = 0; j < DrawList[i].Count; j++)
        {
          if (DrawList[i][j].Item2 < minVal) 
            minVal = DrawList[i][j].Item2;
          if (DrawList[i][j].Item2 > maxVal) 
            maxVal = DrawList[i][j].Item2;
        }

      OldMinimum = minVal;
      if (minVal < 0)
      {
        for (int i = 0; i < DrawList.Count; i++)
        {
          SpikeDataPacket row = new SpikeDataPacket();
          for (int j = 0; j < DrawList[i].Count; j++)
            row.Add(new SpikeData(DrawList[i][j].Item1, DrawList[i][j].Item2 + Math.Abs(minVal)));
          newlist.Add(row);
        }
        maxVal += Math.Abs(minVal);
        
        minVal = 0;
        DrawList = newlist;

      }
      if (doScale)
      {
        Maximum = maxVal;
        Minimum = minVal;
      }
      List<Color> baseColors = new List<Color>();  // create a color list
      baseColors.Add(Color.RoyalBlue);
      baseColors.Add(Color.LightSkyBlue);
      baseColors.Add(Color.LightGreen);
      baseColors.Add(Color.Yellow);
      baseColors.Add(Color.Orange);
      baseColors.Add(Color.Red);

      Graphics graph = Graphics.FromImage(bmp);
      List<Color> colors = interpolateColors(baseColors, 10000);
      for (int i = 0; i < DrawList.Count; i++)
      {
        for (int j = 0; j < DrawList[i].Count && j < maxCol; j++)
        {
          int br_num = (int)(Math.Abs((DrawList[i][j].Item2 - minVal) *10/ (maxVal - minVal)) * factor);
          Brush brush = new SolidBrush(colors[br_num]);
          //Brush brush = new SolidBrush(colors[(System.Int32)(Math.Abs((DrawList[i][j].Item2 ) / (maxVal )) * factor)]);
          Pen pen = new Pen(brush, 5);
         // e.Graphics.FillRectangle(brush, j * rectwidth, i * rectheight, rectwidth, rectheight);
          graph.FillRectangle(brush, j * rectwidth, i * rectheight, rectwidth, rectheight);
          //brush.Dispose();
        }
      }
      graph.Flush();
      //graph.Dispose();
      return bmp;
    }

    private void экспортВBMPToolStripMenuItem_Click(object sender, EventArgs e)
    {
      String savepath = "D:\\MAPS"+DateTime.Now.ToString("yyyy_MMdd_HHmm");
      if (!System.IO.Directory.Exists(savepath))
      System.IO.Directory.CreateDirectory(savepath);
      if (doOpenMenuItem.Checked==true)
      System.Diagnostics.Process.Start(@savepath);
      if (вклToolStripMenuItem.Checked)
      {
        if (NormNoStimBmp != null)
          NormNoStimBmp.Save(savepath + "\\" + CellName + "NoStimNormalized.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
        if (NormStimBmp != null)
          NormStimBmp.Save(savepath + "\\" + CellName + "StimNormalized.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
      }
      else
      {
        if (NoStimBmp != null)
          NoStimBmp.Save(savepath+ "\\" + CellName + "NoStim.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
        if (StimBmp != null)
          StimBmp.Save(savepath+ "\\" + CellName + "Stim.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
      }


    }

    private void выклToolStripMenuItem_Click(object sender, EventArgs e)
    {
      UncheckOtherToolStripMenuItems((ToolStripMenuItem)sender);
      notStimSpikesSetPic();
      StimSpikesSetPic();
    }

    private void вклToolStripMenuItem_Click(object sender, EventArgs e)
    {
      UncheckOtherToolStripMenuItems((ToolStripMenuItem)sender);
      notStimSpikesSetPic();
      StimSpikesSetPic();

    }

    public void UncheckOtherToolStripMenuItems(ToolStripMenuItem selectedMenuItem)
    {
      selectedMenuItem.Checked = true;

      foreach (var ltoolStripMenuItem in (from object
                                              item in selectedMenuItem.Owner.Items
                                          let ltoolStripMenuItem = item as ToolStripMenuItem
                                          where ltoolStripMenuItem != null
                                          where !item.Equals(selectedMenuItem)
                                          select ltoolStripMenuItem))
        (ltoolStripMenuItem).Checked = false;

      // Для показа меню после нажатия
      //selectedMenuItem.Owner.Show();
    }

    private void doOpenMenuItem_Click(object sender, EventArgs e)
    {
      if (doOpenMenuItem.Checked == true) doOpenMenuItem.Checked = false;
      else doOpenMenuItem.Checked = true;
    }

    private void HeatPictureForm_Resize(object sender, EventArgs e)
    {
      if (StimBmp != null && StimBmp.Width > Screen.FromControl(this).Bounds.Width)
        StimPanel.Width = this.Width - 50;
      if (NoStimBmp != null && NoStimBmp.Width > Screen.FromControl(this).Bounds.Width)
        NoStimPanel.Width = this.Width - 50;
    }

    private void notStimSpikes_Click(object sender, EventArgs e)
    {
      MouseEventArgs me = (MouseEventArgs)e;
      Point coordinates = me.Location;
      int x = coordinates.X / rectwidth;
      int y = coordinates.Y / rectheight;
      if (x<NoStimList.Count && x >= 0)
        if (y < NoStimList[x].Count && y >= 0)
        {
          if (сообщитьЗначениеКорелляцииToolStripMenuItem.Checked==true)
          MessageBox.Show(NoStimList[x][y].Item2 + "\nX:" + (int)(y + 1) + " Y:" + (int)(x + 1), "Значение в клетке",
          MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          FCompareForm compareForm =null;
          parent = (MainForm)this.Owner;
          if (parent != null && открытьСравнениеХарактеристикToolStripMenuItem.Checked==true)
          {
            SpikeDataPacket list1, list2;
            if (x >= parent.NoStimSpikeList.Count)
              list1 = parent.StimSpikeList[x - parent.NoStimSpikeList.Count];
            else list1 = parent.NoStimSpikeList[x];
            if (y >= parent.NoStimSpikeList.Count)
              list2 = parent.StimSpikeList[y - parent.NoStimSpikeList.Count];
            else list2 = parent.NoStimSpikeList[y];
            //compareForm = new FCompareForm(list1, list2, x + 1, y + 1, NoStimList[x][y].Item2);
            compareForm = new FCompareForm(list2, list1, y + 1, x + 1, NoStimList[y][x].Item2);
            if (compareForm != null) compareForm.Show();
            else MessageBox.Show("Ошибка построения формы сравнения", "Что-то случилось",
          MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
        }

    }

    private void StimSpikes_Click(object sender, EventArgs e)
    {
      MouseEventArgs me = (MouseEventArgs)e;
      Point coordinates = me.Location;
      int x = coordinates.X / rectwidth;
      int y = coordinates.Y / rectheight;
      if (x < StimList.Count && x >= 0 && сообщитьЗначениеКорелляцииToolStripMenuItem.Checked==true)
        if (y < StimList[x].Count && y >= 0)
      MessageBox.Show(StimList[x][y].Item2 + "\nX:" + (int)(x + 1) + " Y:" + (int)(y + 1), "Значение в клетке",
      MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

  }
}
