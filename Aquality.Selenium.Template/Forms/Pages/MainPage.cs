using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Aquality.Selenium.Template.Forms.Pages
{
    public class MainPage: Form
    {
        private ILink Link => ElementFactory.GetLink(By.XPath("//a[@class = 'start__link']"), "Start link");

        public MainPage() : base(By.XPath("//a[@href='/game.html']"), "Main page")
        {
        }

        public void StartLink() => Link.Click();
    }
}
