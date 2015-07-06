using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalizerCore.Interfaces;
namespace AnalizerCore.Models
{
  class CCamStreamLoader : IDataLoader
  {
    private string FileName;
    public event OnDataReadyDelegate OnDataReady;
    public void Start(string fileName)
    {
      throw new NotImplementedException();
    }
    public void Pause()
    {
      throw new NotImplementedException();
    }
    public void Stop() { }
    private void LoadData()
    {
    }
  }
}
