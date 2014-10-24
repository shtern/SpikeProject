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
  using Excel = Microsoft.Office.Interop.Excel;
  public partial class HeatForm : Form
  {
    String CellName="";
    double eps = 1e-20;
    public HeatForm(List<SpikeDataPacket> list, String cellname)
    {
      InitializeComponent();
      List<SpikeDataPacket> FillList = buildUniform(list);
      CellName = cellname;
      fillData(DGV, FillList);
      fillData(DGV_Norm, buildNormalized(FillList));
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

    void fillData(DataGridView gridview, List<SpikeDataPacket> list)
    {
      int maxRow = list.Count;
      int maxCol = list.Last().Count;

      for (int i = 0; i < list.Count; i++)
        if (list[i].Count < maxCol && list[i].Count > 1) maxCol = list[i].Count;

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
      gridview.AllowUserToResizeColumns = false;
      gridview.CellBorderStyle = DataGridViewCellBorderStyle.None;
      gridview.AutoGenerateColumns = false;
      int rowHeight = gridview.ClientSize.Height / maxRow - 1;
      int colWidth = gridview.ClientSize.Width / maxCol - 1;
      for (int c = 0; c < maxCol; c++)
      {
        DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
        column.FillWeight = 1;
        gridview.Columns.Add(column);
      }
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
        for (int c = 0; c < maxCol && c < list[r].Count; c++)
        {
          gridview[c, r].Style.BackColor =
                         colors[Convert.ToInt16((list[r][c].Item2 / maxVal) * factor)];
        }
      }
    }

    private void CreateExcel(string sPath, DataGridView  gridview)
    {
      //DataTable dt = (DataTable)gridview.DataSource;
      int n = gridview.Columns.Count;
      string[] strArr = new string[n];
      object objValue = System.Reflection.Missing.Value;
      Excel.Application sXLApp = new Excel.Application();
      sXLApp.DefaultSaveFormat = Excel.XlFileFormat.xlOpenXMLWorkbook;
      Excel.Workbooks sXLBooks = (Excel.Workbooks)sXLApp.Workbooks;
      Excel._Workbook sXLBook = (Excel._Workbook)(sXLBooks.Add(objValue));
      Excel.Sheets sXLSheets = (Excel.Sheets)sXLBook.Worksheets;
      Excel.Worksheet sXLWorksheet = (Excel.Worksheet)sXLSheets[1];
     
      for (int x = 0; x < n; x++)
      {
        strArr[x] = "";
      }

      object objHeaders = (object)strArr;
      Excel.Range sXLRange = sXLWorksheet.get_Range("A1", "IV1");
      sXLRange.set_Value(objValue, objHeaders);
      Excel.Font sXLFont = sXLRange.Font;
      // To Assign Empty Column Header is null
      for (int y = n + 1; y <= sXLRange.Count; y++)
      {
        sXLRange[1, y] = null;
      }
      sXLFont.Bold = true;    // To Assign Header in Bold
      object[,] objData = new object[gridview.Rows.Count, gridview.Columns.Count];
      for (int nRow = 0; nRow < gridview.Rows.Count; nRow++)
      {
        for (int nCol = 0; nCol < gridview.Rows.Count; nCol++)
        {
          objData[nRow, nCol] = "";
        }
      }
      sXLRange = sXLWorksheet.get_Range("A2", objValue);
      sXLRange = sXLRange.get_Resize(gridview.Rows.Count, gridview.Columns.Count);
      sXLRange.set_Value(objValue, objData);
      sXLRange.EntireColumn.ColumnWidth = 0.5;
      //If you need Apply the color into Excel Cell based on Grid Cell     
      for (int c = 0; c < gridview.Columns.Count; c++)
      {
        // To get the Excel Cell Name     
        string sCell = GetExcelCell(c + 1);
        for (int r = 0; r < gridview.Rows.Count; r++)
        {
          sXLRange = sXLWorksheet.get_Range(sCell + (r + 2), sCell + (r + 2));
          sXLRange.Interior.Color = ColorTranslator.ToOle(gridview[c, r].Style.BackColor);
        }
      }

      sXLApp.Columns.EntireColumn.AutoFit();
      sXLApp.Columns.EntireRow.AutoFit();
      sXLBook.SaveAs(sPath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
            false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
      sXLBook.Close();
      sXLApp.Quit();
      GC.WaitForPendingFinalizers();
      GC.Collect();
      GC.WaitForPendingFinalizers();
      GC.Collect();
    }

    private void CreateExcelVert(string sPath, DataGridView gridview)
    {
      //DataTable dt = (DataTable)gridview.DataSource;
      int n = gridview.Columns.Count;
      string[] strArr = new string[n];
      object objValue = System.Reflection.Missing.Value;
      Excel.Application sXLApp = new Excel.Application();
      sXLApp.DefaultSaveFormat = Excel.XlFileFormat.xlOpenXMLWorkbook;
      Excel.Workbooks sXLBooks = (Excel.Workbooks)sXLApp.Workbooks;
      Excel._Workbook sXLBook = (Excel._Workbook)(sXLBooks.Add(objValue));
      Excel.Sheets sXLSheets = (Excel.Sheets)sXLBook.Worksheets;
      Excel.Worksheet sXLWorksheet = (Excel.Worksheet)sXLSheets[1];
      Excel.Range sXLRange = sXLWorksheet.get_Range("A1", "IV1");

      //If you need Apply the color into Excel Cell based on Grid Cell     
      for (int c = 0; c < gridview.Rows.Count; c++)
      {
        // To get the Excel Cell Name     
        string sCell = GetExcelCell(c + 1);
        for (int r = 0; r < gridview.Columns.Count; r++)
        {
          sXLRange = sXLWorksheet.get_Range(sCell + (r + 2), sCell + (r + 2));
          sXLRange.Interior.Color = ColorTranslator.ToOle(gridview[r, c].Style.BackColor);
        }
      }

      sXLApp.Columns.EntireColumn.ColumnWidth=1;
      sXLApp.Columns.EntireRow.RowHeight=0.75;
      sXLBook.SaveAs(sPath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
            false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
      sXLBook.Close();
      sXLApp.Quit();
      GC.WaitForPendingFinalizers();
      GC.Collect();
      GC.WaitForPendingFinalizers();
      GC.Collect();
    }

    private string GetExcelCell(int nID)
    {
      string sCell = string.Empty;
      if (nID < 27)
      {
        switch (nID)
        {
          case 0:
            sCell = "z";
            break;
          case 1:
            sCell = "A";
            break;
          case 2:
            sCell = "B";
            break;
          case 3:
            sCell = "C";
            break;
          case 4:
            sCell = "D";
            break;
          case 5:
            sCell = "E";
            break;
          case 6:
            sCell = "F";
            break;
          case 7:
            sCell = "G";
            break;
          case 8:
            sCell = "H";
            break;
          case 9:
            sCell = "I";
            break;
          case 10:
            sCell = "J";
            break;
          case 11:
            sCell = "K";
            break;
          case 12:
            sCell = "L";
            break;
          case 13:
            sCell = "M";
            break;
          case 14:
            sCell = "N";
            break;
          case 15:
            sCell = "O";
            break;
          case 16:
            sCell = "P";
            break;
          case 17:
            sCell = "Q";
            break;
          case 18:
            sCell = "R";
            break;
          case 19:
            sCell = "S";
            break;
          case 20:
            sCell = "T";
            break;
          case 21:
            sCell = "U";
            break;
          case 22:
            sCell = "V";
            break;
          case 23:
            sCell = "W";
            break;
          case 24:
            sCell = "X";
            break;
          case 25:
            sCell = "Y";
            break;
          case 26:
            sCell = "Z";
            break;
          default:
            sCell = String.Empty;
            break;
        }
        return sCell;
      }
      else
      {
        int nDiv = nID / 26;
        int nMod = nID % 26;
        if (nMod.Equals(0))
        {
          nDiv = nDiv - 1;
        }
        sCell = GetExcelCell(nDiv);
        sCell = sCell + GetExcelCell(nMod);
        return sCell;
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

    private void DGV_SelectionChanged(object sender, EventArgs e)
    {
      DGV.ClearSelection();
    }

    private void DGV_Norm_SelectionChanged(object sender, EventArgs e)
    {
      DGV_Norm.ClearSelection();
    }

    private void NoNormExcel_Click(object sender, EventArgs e)
    {
      if (CellName != "MegaMap")
        CreateExcel("D:\\Dropbox\\НейроУИР\\Теплокарты Excel\\HeatMap" + CellName + "NotNorm", DGV);
      else
        CreateExcelVert("D:\\Dropbox\\НейроУИР\\Теплокарты Excel\\HeatMegaMapNotNorm", DGV);
    }

    private void NormExcel_Click(object sender, EventArgs e)
    {
      if (CellName != "MegaMap")
        CreateExcel("D:\\Dropbox\\НейроУИР\\Теплокарты Excel\\HeatMap" + CellName + "Norm", DGV_Norm);
      else
        CreateExcelVert("D:\\Dropbox\\НейроУИР\\Теплокарты Excel\\HeatMegaMapNorm", DGV_Norm);
    }


  }
}
