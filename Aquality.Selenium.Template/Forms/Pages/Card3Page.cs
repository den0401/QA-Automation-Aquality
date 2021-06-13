using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;

namespace Aquality.Selenium.Template.Forms.Pages
{
    public class Card3Page
    {
        private readonly Browser _browser;

        private readonly ILabel _thirdCardIndicator = AqualityServices.Get<IElementFactory>().GetLabel(By.XPath("//div[@class = 'page-indicator']"), "3/4");

        public Card3Page(Browser browser)
        {
            _browser = browser;
        }

        public string ThirdCardIndicator
        {
            get
            {
                return _thirdCardIndicator.GetText();
            }
        }
    }
}
