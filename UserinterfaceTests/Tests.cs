using NUnit.Framework;
using Aquality.Selenium.Template.Forms.Pages;
using Aquality.Selenium.Template.Configuration;
using System;

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

            Card1Page card1Page = new Card1Page(_browser);
            card1Page.FillCard1();

            Card2Page card2Page = new Card2Page(_browser);
            Assert.AreEqual(Configuration.SecondCardIndicator, card2Page.SecondCardIndicator);
                        
            card2Page.CheckThreeRandomCheckboxesAndClickUploadButton();
            Utilities.InteractionWithWindowsWindow.SelectImage(Configuration.WindowsWindowName, Configuration.PathToImage);
            card2Page.ClickNextButton();

            Card3Page card3Page = new Card3Page(_browser);
            Assert.AreEqual(Configuration.ThirdCardIndicator, card3Page.ThirdCardIndicator);
        }

        [Test]
        public void HelpFormIsHidden()
        {
            MainPage mainPage = new MainPage();
            mainPage.StartLink();
            Assert.AreEqual(_browser.CurrentUrl, Configuration.SignUpPageUrl);

            Card1Page card1Page = new Card1Page(_browser);
            card1Page.HideHelpForm();
            Assert.IsTrue(card1Page.HelpForm.State.WaitForNotDisplayed(TimeSpan.FromSeconds(2)));
        }

        [Test]
        public void CookieIsAccepted()
        {
            MainPage mainPage = new MainPage();
            mainPage.StartLink();
            Assert.AreEqual(_browser.CurrentUrl, Configuration.SignUpPageUrl);

            Card1Page card1Page = new Card1Page(_browser);
            card1Page.AcceptCookies();
            Assert.IsTrue(card1Page.AcceptCookieButton.State.WaitForNotDisplayed(TimeSpan.FromSeconds(2)));
        }

        [Test]
        public void TimerIsStartedFromZero()
        {
            MainPage mainPage = new MainPage();
            mainPage.StartLink();
            Assert.AreEqual(_browser.CurrentUrl, Configuration.SignUpPageUrl);

            Card1Page card1Page = new Card1Page(_browser);
            Assert.AreEqual("00:00:00", card1Page.CheckTimer());
        }
    }
}