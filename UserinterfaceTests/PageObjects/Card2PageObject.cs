using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using AutoItX3Lib;
using NUnit.Framework;

namespace UserinterfaceTests.PageObjects
{
    public class Card2PageObject
    {
        private IWebDriver _webDriver;

        private readonly By _xPathUnselectAllCheckbox = By.XPath("//label[@for = 'interest_unselectall']/span[@class = 'checkbox__box']");
        private readonly By _xPathCheckboxesArray = By.XPath("//span[@class = 'checkbox__box']");
        private readonly By _xPathSelectAllCheckbox = By.XPath("//label[@for = 'interest_selectall']/span[@class = 'checkbox__box']");
        private readonly By _xPathUploadButton = By.XPath("//a[@class = 'avatar-and-interests__upload-button']");
        private readonly By _xPathSecondPageNextButton = By.CssSelector("button.button.button--stroked");
        private readonly By _xPathSecondPageIndicator = By.XPath("//div[@class = 'page-indicator']");

        private const string _windowName = "Open";
        private const string _pathToPicture = @"C:\Users\burii\Pictures\Screenpresso\1.png";

        public Card2PageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;

            Assert.AreEqual(TestSettings.expectedSecondCardIndicator,
                _webDriver.FindElement(By.XPath(TestSettings.xPathCardIndicator)).Text, "Form page is not \"2 / 4\"");
        }

        public Card3PageObject FillCard2()
        {
            _webDriver.FindElement(_xPathUnselectAllCheckbox).Click();

            Random rand = new Random();

            List<IWebElement> allCheckboxes = new List<IWebElement>();

            foreach (var item in _webDriver.FindElements(_xPathCheckboxesArray))
            {
                allCheckboxes.Add(item);
            }

            ClickRandomChecbox(rand, allCheckboxes);

            _webDriver.FindElement(_xPathUploadButton).Click();

            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate(_windowName);
            WaitUntil.WaitSomeInterval(1);
            autoIt.Send(_pathToPicture);
            autoIt.Send("{ENTER}");

            _webDriver.FindElement(_xPathSecondPageNextButton).Click();          

            return new Card3PageObject(_webDriver);
        }

        private void ClickRandomChecbox (Random rand, List<IWebElement> allCheckboxes)
        {
            int counter = 0;
            while (counter < 3)
            {
                int randomCheckbox = rand.Next(0, _webDriver.FindElements(_xPathCheckboxesArray).Count);

                if (allCheckboxes[randomCheckbox].GetHashCode() != _webDriver.FindElement(_xPathSelectAllCheckbox).GetHashCode() &&
                    allCheckboxes[randomCheckbox].GetHashCode() != _webDriver.FindElement(_xPathUnselectAllCheckbox).GetHashCode() &&
                    allCheckboxes[randomCheckbox].Selected == false)
                {
                    allCheckboxes[randomCheckbox].Click();
                    counter++;
                }
            }
        }
    }
}
