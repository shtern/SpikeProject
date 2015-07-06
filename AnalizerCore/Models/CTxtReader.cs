using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AnalizerCore.Interfaces;
namespace AnalizerCore.Models
{
  class CTxtReader : IDataLoader
  {
    private string FileName;
    private Task LoaderTask;
    public event OnDataReadyDelegate OnDataReady;

    public void Start(string fileName) {
      FileName = fileName;
      LoaderTask = new Task(LoadData);
      LoaderTask.Start();
    }
    public void Pause() {
      throw new NotImplementedException();
    }
    public void Stop() 
    {
      if (LoaderTask.Status == TaskStatus.Running)
        LoaderTask.Wait(1);
    }
    private void LoadData() 
    {

      int zerocount = 0;
      SpikeDataContainer GlobalData = new SpikeDataContainer();

      using (StreamReader sr = new StreamReader(FileName))
      {
        while (sr.Peek() >= 0)
        {
          string result = sr.ReadLine();
          double x, y;
          string[] resultxy = result.Split('\t');

          if (resultxy.Length != 2)
          {
            //MessageBox.Show("Bad file exception!!!!!");
            break;
          }
          string[] resultxy2 = result.Split('\t');
          resultxy2[0] = resultxy[0].Replace(",", ".");
          resultxy2[1] = resultxy[1].Replace(",", ".");
          double parsevar = 0;
          double.TryParse("3,5", out parsevar);
          if (parsevar == 3.5)
          {
            double.TryParse(resultxy[0].Replace(".", ","), out x);
            double.TryParse(resultxy[1].Replace(".", ","), out y);
          }
          else
          {
            double.TryParse(resultxy2[0], out x);
            double.TryParse(resultxy2[1], out y);
          }
          Tuple<double, double> XYData = new Tuple<double, double>(x, y);
          if (XYData.Item2 <= 0) zerocount++;
          GlobalData.Add(XYData);
        }

      }

      if (zerocount < 0.3 * GlobalData.Count) GlobalData.RemoveAll(s => s.Item2 <= 0);

      if (OnDataReady != null) OnDataReady(GlobalData);
    }

  }
}
