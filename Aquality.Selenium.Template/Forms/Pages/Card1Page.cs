using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;
using Aquality.Selenium.Template.Utilities;
using Aquality.Selenium.Forms;
using System;

namespace Aquality.Selenium.Template.Forms.Pages
{
    public class Card1Page: Form
    {
        private ILabel Timer => ElementFactory.GetLabel(By.XPath("//div[@class='timer timer--white timer--center']"), "timer");
        private ITextBox PasswordTxb => ElementFactory.GetTextBox(By.XPath("//input[@placeholder = 'Choose Password']"), "Password");
        private ITextBox EmailTxb => ElementFactory.GetTextBox(By.XPath("//input[@placeholder = 'Your email']"), "Email");
        private ITextBox DomainTxb => ElementFactory.GetTextBox(By.XPath("//input[@placeholder = 'Domain']"), "Domain");
        private IButton DropdownList => ElementFactory.GetButton(By.XPath("//div[@class = 'dropdown__opener']"), "Dropdown");
        private IButton SelectDropdownCom => ElementFactory.GetButton(By.XPath("//div[text() = '.com']"), "DropdownCom");
        private ICheckBox TermsAndConditionsChbx => ElementFactory.GetCheckBox(By.XPath("//span[@class = 'checkbox']"), "TermsAndConditions");
        private IButton AcceptCookieBtn => ElementFactory.GetButton(By.XPath("//button[@class='button button--solid button--transparent']"), "AcceptCookie");
        private IButton NextBtn => ElementFactory.GetButton(By.XPath("//a[@class = 'button--secondary']"), "Next");
        private ILabel HelpForm => ElementFactory.GetLabel(By.XPath("//div[@class='help-form']"), "Help form");

        private readonly string _hideHelpFormCssProperty = "arguments[0].style=\"display: none;\"";

        public Card1Page() : base(By.Id("//div[@class = 'page-indicator']"), "1 / 4")
        {
        }
        
        public void FillCard1()
        {
            DataGenerator dataGenerator = new DataGenerator();

            string password = dataGenerator.GeneratePassword();

            PasswordTxb.ClearAndType(password);
            EmailTxb.ClearAndType(dataGenerator.GenerateEmail(password));
            DomainTxb.ClearAndType(dataGenerator.GenerateEmail(dataGenerator.GeneratePassword()));

            DropdownList.Click();
            SelectDropdownCom.Click();

            TermsAndConditionsChbx.Check();

            NextBtn.Click();
        }

        public void AcceptCookies()
        {            
            AcceptCookieBtn.State.WaitForDisplayed(TimeSpan.FromSeconds(Convert.ToInt32(Configuration.Configuration.WaitingTime)));
            AcceptCookieBtn.Click();
        }

        public bool AcceptCookiesIsDisplayed() => AcceptCookieBtn.State.IsDisplayed;

        public bool HelpFormIsDisplayed() => HelpForm.State.IsDisplayed;

        public bool TimerIsStartedFromZero() => Timer.GetText().Equals(Configuration.Configuration.TimerValue);

        public void HideHelpForm() => AqualityServices.Browser.ExecuteScript(_hideHelpFormCssProperty, HelpForm.GetElement());
    }
}
