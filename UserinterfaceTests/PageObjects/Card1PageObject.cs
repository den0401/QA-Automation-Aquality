using OpenQA.Selenium;
using NUnit.Framework;

namespace UserinterfaceTests.PageObjects
{
    public class Card1PageObject
    {
        private IWebDriver _webDriver;

        private readonly By _xPathInputPassword = By.XPath("//input[@placeholder = 'Choose Password']");
        private readonly By _xPathInputEmailName = By.XPath("//input[@placeholder = 'Your email']");
        private readonly By _xPathInputDomain = By.XPath("//input[@placeholder = 'Domain']");
        private readonly By _xPathDropdownList = By.XPath("//div[@class = 'dropdown__opener']");
        private readonly By _xPathSelectDropdownCom = By.XPath("//div[text() = '.com']");
        private readonly By _xPathTermsAndConditionsCheckbox = By.XPath("//span[@class = 'checkbox']");
        private readonly By _xPathNextButton = By.XPath("//a[@class = 'button--secondary']");

        private readonly string _password = DataGenerator.GeneratePassword();

        public Card1PageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;

            Assert.AreEqual(TestSettings.expectedFirstCardIndicator,
                _webDriver.FindElement(By.XPath(TestSettings.xPathCardIndicator)).Text, "Form page is not \"1 / 4\"");
        }

        public Card2PageObject FillCard1(string domain = "gmail")
        {
            WaitUntil.WaitElement(_webDriver, _xPathInputPassword);            

            _webDriver.FindElement(_xPathInputPassword).Clear();
            _webDriver.FindElement(_xPathInputPassword).SendKeys(_password);

            _webDriver.FindElement(_xPathInputEmailName).Clear();
            _webDriver.FindElement(_xPathInputEmailName).SendKeys(DataGenerator.GenerateEmail(_password));

            _webDriver.FindElement(_xPathInputDomain).Clear();
            _webDriver.FindElement(_xPathInputDomain).SendKeys(domain);

            _webDriver.FindElement(_xPathDropdownList).Click();
            _webDriver.FindElement(_xPathSelectDropdownCom).Click();

            _webDriver.FindElement(_xPathTermsAndConditionsCheckbox).Click();

            _webDriver.FindElement(_xPathNextButton).Click();

            return new Card2PageObject(_webDriver);
        }
    }
}
