using NUnit.Framework;
using UserinterfaceTests.PageObjects;

namespace UserinterfaceTests
{
    [TestFixture]
    public class Tests: BaseTest
    {
        [Test]
        public void CardsAreFilled()
        {
            WelcomePagePageObject welcomePage = new WelcomePagePageObject(_webDriver);
            Assert.AreEqual(TestSettings.host, _webDriver.Url);

            welcomePage.StartLink();
            Assert.AreEqual(TestSettings.signUpPageUrl, _webDriver.Url);

            Card1PageObject card1 = new Card1PageObject(_webDriver);
            card1.FillCard1();

            Card2PageObject card2 = new Card2PageObject(_webDriver);
            card2.FillCard2();
        }

        [Test]
        public void HelpFormIsHidden()
        {
            WelcomePagePageObject welcomePage = new WelcomePagePageObject(_webDriver);
            welcomePage.StartLink();
            Assert.AreEqual(TestSettings.signUpPageUrl, _webDriver.Url);

            welcomePage.HideHelpForm();            
        }

        [Test]
        public void CookiesAreAccepted()
        {
            WelcomePagePageObject welcomePage = new WelcomePagePageObject(_webDriver);
            welcomePage.StartLink();
            Assert.AreEqual(TestSettings.signUpPageUrl, _webDriver.Url);
            
            welcomePage.AcceptCookies();
        }

        [Test]
        public void TimerIsStartedFromZero()
        {
            WelcomePagePageObject welcomePage = new WelcomePagePageObject(_webDriver);
            welcomePage.StartLink();
            Assert.AreEqual(TestSettings.signUpPageUrl, _webDriver.Url);

            welcomePage.CheckTimer();
        }
    }
}