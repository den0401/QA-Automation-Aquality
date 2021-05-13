using NUnit.Framework;
using OpenQA.Selenium;

namespace UserinterfaceTests.PageObjects
{
    public class Card3PageObject
    {
        private IWebDriver _webDriver;

        public Card3PageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            Assert.AreEqual(TestSettings.expectedThirdCardIndicator,
                _webDriver.FindElement(By.XPath(TestSettings.xPathCardIndicator)).Text, "Form page is not \"3 / 4\"");
        }
    }
}
