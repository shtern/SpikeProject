using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizerCore
{
  public enum UIType
  {
    Console,
    WinForms,
    WPF,
    NoUI
  }
  public struct DataLoadParams
  {
    public string FileName;
    public ulong MaxDuration;
    public string MemoryPipeName;
    // etc
  }
}
