using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnalizerCore;
namespace AnalizeExecuter
{
  static class Program
  {
    /// <summary>
    /// Главная точка входа для приложения.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      CMainController mainController = new CMainController(UIType.WinForms);
      Application.Run(mainController.ui as Form);
    }
  }
}
