using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UserinterfaceTests
{
    public class BaseTest
    {
        protected IWebDriver _webDriver;

        [OneTimeSetUp]
        protected void DoBeforeAllTests()
        {
            _webDriver = new ChromeDriver();
        }

        [OneTimeTearDown]
        protected void DoAfterAllTests()
        {
            _webDriver.Quit();
        }

        [TearDown]
        protected void DoAfterEach()
        {
        }

        [SetUp]
        protected void DoBeforeEach()
        {
            _webDriver.Manage().Cookies.DeleteAllCookies();
            _webDriver.Manage().Window.Maximize();

            _webDriver.Navigate().GoToUrl(TestSettings.host);
            Assert.AreEqual(_webDriver.Url, TestSettings.host);
        }
    }
}
