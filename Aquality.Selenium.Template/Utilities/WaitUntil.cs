using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading.Tasks;

namespace Aquality.Selenium.Template.Utilities
{
    public static class WaitUntil
    {
        public static void WaitSomeInterval(double seconds = 1)
        {
            Task.Delay(TimeSpan.FromSeconds(seconds)).Wait();
        }
    }
}
