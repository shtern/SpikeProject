using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnalizerCore.Interfaces;
using AnalizerCore.Views;
namespace AnalizerCore
{
  public class CMainController
  {
    public IMainControllerUI ui;
 
    /// <summary>
    /// Init with winFormUI
    /// </summary>
    public CMainController()
    {
      ui = (new FMainForm()) as IMainControllerUI;
    }
    /// <summary>
    /// Init with selected UI Type
    /// </summary>
    /// <param name="type">Contains UI Type</param>
    public CMainController(UIType type)
    {
      switch (type)
      {
        case  UIType.Console:
          throw new NotImplementedException();
        case UIType.NoUI:
          throw new NotImplementedException();
        case UIType.WinForms:
          
          ui = (new FMainForm()) as IMainControllerUI;
          break;
        case UIType.WPF:
          throw new NotImplementedException("Let fire down the hell");
      }
    }

    void StartMeasurmant();

  }
}
