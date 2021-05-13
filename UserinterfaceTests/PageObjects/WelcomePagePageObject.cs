using OpenQA.Selenium;
using NUnit.Framework;

namespace UserinterfaceTests.PageObjects
{
    class WelcomePagePageObject
    {
        private IWebDriver _webDriver;
        
        private readonly By _xPathLink = By.XPath("//a[@class = 'start__link']");
        private readonly By _xPathHelpForm = By.XPath("//div[@class='help-form']");
        private readonly By _xPathAcceptCookieButton = By.XPath("//button[@class='button button--solid button--transparent']");
        private readonly By _xPathTimer = By.XPath("//div[@class='timer timer--white timer--center']");

        public WelcomePagePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public Card1PageObject StartLink()
        {
            _webDriver.FindElement(_xPathLink).Click();

            return new Card1PageObject(_webDriver);
        }

        public void HideHelpForm()
        {
            IJavaScriptExecutor js = _webDriver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].style=\"display: none;\"", _webDriver.FindElement(_xPathHelpForm));
            Assert.AreEqual("display: none;", _webDriver.FindElement(_xPathHelpForm).GetAttribute("style"));
        }

        public void AcceptCookies()
        {
            WaitUntil.WaitElement(_webDriver, _xPathAcceptCookieButton);

            _webDriver.FindElement(_xPathAcceptCookieButton).Click();
            Assert.Throws<NoSuchElementException>(() => _webDriver.FindElement(_xPathAcceptCookieButton));
        }

        public void CheckTimer()
        {
            string timerValue = _webDriver.FindElement(_xPathTimer).Text;
            Assert.AreEqual("00:00:00", timerValue);
        }
    }
}
