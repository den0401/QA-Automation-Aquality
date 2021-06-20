using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Aquality.Selenium.Template.Forms.Pages
{
    public class Card3Page : Form
    {
        private ILabel ThirdCardIndicator => ElementFactory.GetLabel(By.XPath("//div[@class = 'page-indicator']"), "Page indicator 3 / 4");
        
        private readonly string _thirdCardIndicator = "3 / 4";

        public Card3Page() : base(By.Id("//div[@class = 'page-indicator']"), "3 / 4")
        {
        }

        public bool ThirdCardIndicatorIsDisplayed() => ThirdCardIndicator.GetText().Equals(_thirdCardIndicator);
    }
}
