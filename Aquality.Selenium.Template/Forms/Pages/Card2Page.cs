using Aquality.Selenium.Browsers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;

namespace Aquality.Selenium.Template.Forms.Pages
{
    public class Card2Page: Form
    {
        private ICheckBox UnselectAllChbx => ElementFactory.GetCheckBox(By.XPath("//label[@for = 'interest_unselectall']/span[@class = 'checkbox__box']"), "UnselectAll");
        private IButton UploadBtn => ElementFactory.GetButton(By.XPath("//a[@class = 'avatar-and-interests__upload-button']"), "Upload");
        private IButton NextBtn => ElementFactory.GetButton(By.CssSelector("button.button.button--stroked"), "Next");
        private ILabel SecondCardIndicator => ElementFactory.GetLabel(By.XPath("//div[@class = 'page-indicator']"), "Page indicator 2 / 4");

        private readonly By _xPathUnselectAllCheckbox = By.XPath("//label[@for = 'interest_unselectall']/span[@class = 'checkbox__box']");
        private readonly By _xPathCheckboxesArray = By.XPath("//span[@class = 'checkbox__box']");
        private readonly By _xPathSelectAllCheckbox = By.XPath("//label[@for = 'interest_selectall']/span[@class = 'checkbox__box']");
        private readonly string _secondCardIndicator = "2 / 4";

        public Card2Page() : base(By.Id("//div[@class = 'page-indicator']"), "2 / 4")
        {        
        }

        public bool SecondCardIndicatorIsDisplayed() => SecondCardIndicator.GetText().Equals(_secondCardIndicator);

        public void CheckThreeRandomCheckboxesAndClickUploadButton()
        {
            UnselectAllChbx.Check();

            Random rand = new Random();

            List<IWebElement> allCheckboxes = new List<IWebElement>();

            foreach (var item in AqualityServices.Browser.Driver.FindElements(_xPathCheckboxesArray))
                allCheckboxes.Add(item);

            SelectThreeCheckboxes(rand, allCheckboxes);

            UploadBtn.Click();
        }

        public void ClickNextButton() => NextBtn.Click();

        private void SelectThreeCheckboxes(Random rand, List<IWebElement> allCheckboxes)
        {
            int counter = 1;
            int requiredNumberOfCheckboxes = 3;

            while (counter <= requiredNumberOfCheckboxes)
            {
                int randomCheckbox = rand.Next(0, AqualityServices.Browser.Driver.FindElements(_xPathCheckboxesArray).Count);

                if (!allCheckboxes[randomCheckbox].Equals(AqualityServices.Browser.Driver.FindElement(_xPathUnselectAllCheckbox)) &&
                    !allCheckboxes[randomCheckbox].Equals(AqualityServices.Browser.Driver.FindElement(_xPathSelectAllCheckbox)) &&
                    !allCheckboxes[randomCheckbox].Selected)
                {
                    allCheckboxes[randomCheckbox].Click();
                    counter++;
                }
            }
        }
    }
}
