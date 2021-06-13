using Aquality.Selenium.Browsers;
using NUnit.Framework;
using Aquality.Selenium.Template.Configuration;

namespace UserinterfaceTests
{
    public class BaseTest
    {
        protected Browser _browser;

        [OneTimeSetUp]
        protected void DoBeforeAllTests()
        {
            _browser = AqualityServices.Browser;
        }

        [OneTimeTearDown]
        protected void DoAfterAllTests()
        {
            _browser.Quit();
        }

        [SetUp]
        protected void DoBeforeEach()
        {
            _browser.Driver.Manage().Cookies.DeleteAllCookies();
            _browser.Maximize();

            _browser.GoTo(Configuration.StartUrl);
            _browser.WaitForPageToLoad();

            Assert.AreEqual(_browser.CurrentUrl, Configuration.StartUrl);
        }
    }
}
