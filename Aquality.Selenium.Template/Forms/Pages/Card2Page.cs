using Aquality.Selenium.Browsers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using Aquality.Selenium.Elements.Interfaces;

namespace Aquality.Selenium.Template.Forms.Pages
{
    public class Card2Page
    {
        private readonly Browser _browser;

        private readonly ICheckBox _unselectAllCheckbox = AqualityServices.Get<IElementFactory>().GetCheckBox(By.XPath("//label[@for = 'interest_unselectall']/span[@class = 'checkbox__box']"), "UnselectAll");
        private readonly IButton _uploadButton = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//a[@class = 'avatar-and-interests__upload-button']"), "Upload");
        private readonly IButton _nextButton = AqualityServices.Get<IElementFactory>().GetButton(By.CssSelector("button.button.button--stroked"), "Next");
        private readonly ILabel _secondCardIndicator = AqualityServices.Get<IElementFactory>().GetLabel(By.XPath("//div[@class = 'page-indicator']"), "2/4");

        private readonly By _xPathUnselectAllCheckbox = By.XPath("//label[@for = 'interest_unselectall']/span[@class = 'checkbox__box']");
        private readonly By _xPathCheckboxesArray = By.XPath("//span[@class = 'checkbox__box']");
        private readonly By _xPathSelectAllCheckbox = By.XPath("//label[@for = 'interest_selectall']/span[@class = 'checkbox__box']");

        public string SecondCardIndicator
        {
            get
            {
                return _secondCardIndicator.GetText();
            }
        }

        public Card2Page(Browser browser)
        {
            _browser = browser;            
        }

        public void CheckThreeRandomCheckboxesAndClickUploadButton()
        {
            _unselectAllCheckbox.Check();

            Random rand = new Random();

            List<IWebElement> allCheckboxes = new List<IWebElement>();

            foreach (var item in _browser.Driver.FindElements(_xPathCheckboxesArray))
                allCheckboxes.Add(item);

            ClickRandomChecbox(rand, allCheckboxes);

            _uploadButton.Click();
        }

        public Card3Page ClickNextButton()
        {
            _nextButton.Click();

            return new Card3Page(_browser);
        }

        private void ClickRandomChecbox(Random rand, List<IWebElement> allCheckboxes)
        {
            int counter = 0;
            while (counter < 3)
            {
                int randomCheckbox = rand.Next(0, _browser.Driver.FindElements(_xPathCheckboxesArray).Count);

                if (!allCheckboxes[randomCheckbox].Equals(_browser.Driver.FindElement(_xPathUnselectAllCheckbox)) &&
                    !allCheckboxes[randomCheckbox].Equals(_browser.Driver.FindElement(_xPathSelectAllCheckbox)) &&
                    !allCheckboxes[randomCheckbox].Selected)
                {
                    allCheckboxes[randomCheckbox].Click();
                    counter++;
                }
            }
        }
    }
}
