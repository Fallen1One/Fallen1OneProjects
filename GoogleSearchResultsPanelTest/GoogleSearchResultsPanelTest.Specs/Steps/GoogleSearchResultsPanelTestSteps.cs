using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace GoogleSearchResultsPanelTest.Specs.Steps
{
    [Binding]
    public class GoogleSearchResultsPanelTestSteps : IDisposable
    {
        IWebDriver driver = new ChromeDriver(@"C:\!Development\Visual Studio Staff\ChromeDriver\94.0.4606.61");

        [When(@"I open http://www\.google\.com")]

        public void WhenIOpenHttpWww_Google_Com()
        {
            driver.Navigate().GoToUrl("http://www.google.com");
        }
        
        [When(@"I type random year from the second millennium into SearchInputField")]

        public void WhenITypeRandomYearFromTheSecondMillenniumIntoSearchInputField()
        {
            IWebElement searchField = driver.FindElement(By.Name("q"));

            // Lets perform "2nd millennium year" search for example :)
            // Create random 3-digit value
            Random r = new Random();
            string randomstring = String.Format($"1{r.Next(1000)} year");

            // And put it to "Search" field
            searchField.SendKeys(randomstring);
        }

        [When(@"I click GoogleSearchButton")]

        public void IClickGoogleSearchButton()
        {
            IWebElement searchField = driver.FindElement(By.Name("q"));
            searchField.Submit();
        }
        
        [Then(@"I see ResultStatsPanel is displayed")]

        public void ThenISeeResultStatsPanelIsDisplayed()
        {
            Assert.IsTrue(driver.FindElement(By.Id("result-stats")).Displayed);
        }

        public void Dispose()
        {
            if (driver != null)
            {
                driver.Dispose();
                driver = null;
            }
        }
    }
}
