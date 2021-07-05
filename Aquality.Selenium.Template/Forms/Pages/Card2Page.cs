using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;

namespace Aquality.Selenium.Template.Forms.Pages
{
    public class Card2Page: Form
    {
        private ICheckBox UnselectAllChbx => ElementFactory.GetCheckBox(By.XPath("//label[@for = 'interest_unselectall']/span[@class = 'checkbox__box']"), "Unselect All");
        private IButton UploadBtn => ElementFactory.GetButton(By.XPath("//a[@class = 'avatar-and-interests__upload-button']"), "Upload");
        private IButton NextBtn => ElementFactory.GetButton(By.CssSelector("button.button.button--stroked"), "Next");
        private ILabel SecondCardIndicator => ElementFactory.GetLabel(By.XPath("//div[@class = 'page-indicator']"), "Page indicator 2 / 4");
        private ICheckBox SelectAllChbx => ElementFactory.GetCheckBox(By.XPath("//label[@for = 'interest_selectall']/span[@class = 'checkbox__box']"), "Select All");
        private ICheckBox CheckboxesArray => ElementFactory.GetCheckBox(By.XPath("//div[@class = 'avatar-and-interests__interests-list']"), "All checkboxes");

        private readonly By _xPathEachCheckbox = By.XPath("//span[@class = 'checkbox__box']");
        private readonly string _secondCardIndicator = "2 / 4";

        public Card2Page() : base(By.Id("//div[@class = 'page-indicator']"), "2 / 4")
        {        
        }

        public bool SecondCardIndicatorIsDisplayed() => SecondCardIndicator.GetText().Equals(_secondCardIndicator);

        public void CheckThreeRandomCheckboxesAndClickUploadButton()
        {
            UnselectAllChbx.Check();

            Random rand = new Random();

            List<ICheckBox> allCheckboxes = new List<ICheckBox>();

            foreach (var item in CheckboxesArray.FindChildElements<ICheckBox>(_xPathEachCheckbox))
                allCheckboxes.Add(item);

            int requiredNumberOfCheckboxes = 3;

            SelectRequiredNumberOfCheckboxes(rand, allCheckboxes, requiredNumberOfCheckboxes);

            UploadBtn.Click();
        }

        public void ClickNextButton() => NextBtn.Click();

        private void SelectRequiredNumberOfCheckboxes(Random rand, List<ICheckBox> allCheckboxes, int requiredNumberOfCheckboxes)
        {
            int counter = 1;

            while (counter <= requiredNumberOfCheckboxes)
            {
                int randomCheckbox = rand.Next(0, CheckboxesArray.FindChildElements<ICheckBox>(_xPathEachCheckbox).Count);

                if (!allCheckboxes[randomCheckbox].Equals(UnselectAllChbx.GetElement()) &&
                    !allCheckboxes[randomCheckbox].Equals(SelectAllChbx.GetElement()) &&
                    !allCheckboxes[randomCheckbox].IsChecked)
                {
                    allCheckboxes[randomCheckbox].Click();
                    counter++;
                }
            }
        }
    }
}
