using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalizerCore.Models;
namespace AnalizerCore.Interfaces
{
  public delegate void OnDataReadyDelegate(SpikeDataContainer data);
  public interface IDataLoader
  {
     event OnDataReadyDelegate OnDataReady;
     void Start(string FileNAme);
     void Pause();
     void Stop();
  }
}
