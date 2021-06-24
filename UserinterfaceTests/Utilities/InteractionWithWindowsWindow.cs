using AutoItX3Lib;
using Aquality.Selenium.Template.Configuration;
using System;
using System.IO;

namespace UserinterfaceTests.Utilities
{
    public static class InteractionWithWindowsWindow
    {
        public static void SelectImage(string pathToImage)
        {
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate(Configuration.WindowsWindowName);

            autoIt.WinWaitActive(Configuration.WindowsWindowName, "Dialog window is not opened",
                Convert.ToInt32(Configuration.WaitingTime));

            autoIt.Send(pathToImage);
            autoIt.Send("{ENTER}");           
        }
    }
}
