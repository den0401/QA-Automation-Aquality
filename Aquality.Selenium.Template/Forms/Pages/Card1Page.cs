using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;
using System;
using Aquality.Selenium.Template.Utilities;

namespace Aquality.Selenium.Template.Forms.Pages
{
    public class Card1Page
    {
        private readonly Browser _browser;

        private readonly IElement _helpForm = AqualityServices.Get<IElementFactory>().GetLink(By.XPath("//div[@class='help-form']"), "helpForm");
        private readonly IElement _timer = AqualityServices.Get<IElementFactory>().GetLink(By.XPath("//div[@class='timer timer--white timer--center']"), "timer");
        private readonly ITextBox _passwordTextBox = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath("//input[@placeholder = 'Choose Password']"), "Password");
        private readonly ITextBox _emailTextBox = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath("//input[@placeholder = 'Your email']"), "Email");
        private readonly ITextBox _domainTextBox = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath("//input[@placeholder = 'Domain']"), "Domain");
        private readonly IElement _dropdownList = AqualityServices.Get<IElementFactory>().GetLink(By.XPath("//div[@class = 'dropdown__opener']"), "Dropdown");
        private readonly IElement _selectDropdownCom = AqualityServices.Get<IElementFactory>().GetLink(By.XPath("//div[text() = '.com']"), "DropdownCom");
        private readonly ICheckBox _termsAndConditionsCheckbox = AqualityServices.Get<IElementFactory>().GetCheckBox(By.XPath("//span[@class = 'checkbox']"), "TermsAndConditions");
        private readonly IButton _acceptCookieButton = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//button[@class='button button--solid button--transparent']"), "AcceptCookie");
        private readonly IButton _nextButton = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//a[@class = 'button--secondary']"), "Next");

        private readonly By _xPathHelpForm = By.XPath("//div[@class='help-form']");

        private readonly string _password = DataGenerator.GeneratePassword();

        public IButton AcceptCookieButton
        {
            get
            {
                return _acceptCookieButton;
            }
        }

        public IElement HelpForm
        {
            get
            {
                return _helpForm;
            }
        }

        public Card1Page(Browser browser)
        {
            _browser = browser;
        }       

        public Card2Page FillCard1(string domain = "gmail")
        {
            _passwordTextBox.ClearAndType(_password);

            _emailTextBox.ClearAndType(DataGenerator.GenerateEmail(_password));
            _domainTextBox.ClearAndType(domain);

            _dropdownList.Click();
            _selectDropdownCom.Click();

            _termsAndConditionsCheckbox.Check();

            _nextButton.Click();

            return new Card2Page(_browser);
        }

        public void AcceptCookies()
        {
            _acceptCookieButton.State.WaitForDisplayed(TimeSpan.FromSeconds(2));
            _acceptCookieButton.Click();
        }

        public string CheckTimer() => _timer.GetText();

        public void HideHelpForm()
        {
            IJavaScriptExecutor js = _browser.Driver;
            js.ExecuteScript("arguments[0].style=\"display: none;\"", _browser.Driver.FindElement(_xPathHelpForm));
        }
    }
}
