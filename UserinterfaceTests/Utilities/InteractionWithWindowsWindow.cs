using System;
using System.Collections.Generic;
using System.Text;
using Aquality.Selenium.Browsers;
using AutoItX3Lib;
using Aquality.Selenium.Template.Utilities;

namespace UserinterfaceTests.Utilities
{
    public static class InteractionWithWindowsWindow
    {
        public static void SelectImage(string windowName, string pathToPicture)
        {
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate(windowName);

            WaitUntil.WaitSomeInterval();

            autoIt.Send(pathToPicture);
            autoIt.Send("{ENTER}");
        }

    }
}
