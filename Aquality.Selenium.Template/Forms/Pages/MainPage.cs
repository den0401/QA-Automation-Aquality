using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;

namespace Aquality.Selenium.Template.Forms.Pages
{
    public class MainPage
    {
        private readonly ILink _link = AqualityServices.Get<IElementFactory>().GetLink(By.XPath("//a[@class = 'start__link']"), "startLink");

        private readonly Browser _browser;                

        public Card1Page StartLink()
        {
            _link.Click();

            return new Card1Page(_browser);
        }
    }
}
