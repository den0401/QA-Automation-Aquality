using NUnit.Framework;
using Aquality.Selenium.Template.Forms.Pages;
using Aquality.Selenium.Template.Configuration;

namespace UserinterfaceTests
{
    [TestFixture]
    public class Tests: BaseTest
    {
        [Test]
        public void CardsAreFilled()
        {
            MainPage mainPage = new MainPage();
            mainPage.StartLink();
            Assert.AreEqual(_browser.CurrentUrl, Configuration.SignUpPageUrl);

            Card1Page card1Page = new Card1Page();
            card1Page.FillCard1();

            Card2Page card2Page = new Card2Page();
            Assert.IsTrue(card2Page.SecondCardIndicatorIsDisplayed());
                        
            card2Page.CheckThreeRandomCheckboxesAndClickUploadButton();
            Utilities.InteractionWithWindowsWindow.SelectImage();
            card2Page.ClickNextButton();

            Card3Page card3Page = new Card3Page();
            Assert.IsTrue(card3Page.ThirdCardIndicatorIsDisplayed());
        }

        [Test]
        public void HelpFormIsHidden()
        {
            MainPage mainPage = new MainPage();
            mainPage.StartLink();
            Assert.AreEqual(_browser.CurrentUrl, Configuration.SignUpPageUrl);

            Card1Page card1Page = new Card1Page();
            card1Page.HideHelpForm();
            Assert.IsFalse(card1Page.HelpFormIsDisplayed());            
        }

        [Test]
        public void CookieIsAccepted()
        {
            MainPage mainPage = new MainPage();
            mainPage.StartLink();
            Assert.AreEqual(_browser.CurrentUrl, Configuration.SignUpPageUrl);

            Card1Page card1Page = new Card1Page();
            card1Page.AcceptCookies();
            Assert.IsFalse(card1Page.AcceptCookiesIsDisplayed());
        }

        [Test]
        public void TimerIsStartedFromZero()
        {
            MainPage mainPage = new MainPage();
            mainPage.StartLink();
            Assert.AreEqual(_browser.CurrentUrl, Configuration.SignUpPageUrl);

            Card1Page card1Page = new Card1Page();
            Assert.IsTrue(card1Page.TimerIsStartedFromZero());
        }
    }
}