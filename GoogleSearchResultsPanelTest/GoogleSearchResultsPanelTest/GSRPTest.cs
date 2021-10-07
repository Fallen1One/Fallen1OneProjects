using TechTalk.SpecFlow;
using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace GoogleSearchResultsPanelTest
{
    public class GSRPTest
    {
        public void PerformGoogleSearch()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.google.com");
            IWebElement searchField = driver.FindElement(By.Name("q"));

            // Lets perform "2nd millennium year" search for example :)
            // Create random 3-digit value
            Random r = new Random();
            string randomstring = String.Format($"1{r.Next(1000)} year");

            // And put it to "Search" field
            searchField.SendKeys(randomstring);
            searchField.Submit();

            // Choosing the right method to check "result-stats" element:
            // Assert.IsTrue(driver.PageSource.Contains("result-stats"));
            // Assert.IsTrue(driver.FindElement(By.Id("result-stats")).Displayed);
            // Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='result-stats']")).Displayed);

            // This looks good & more relevant 
            Assert.IsTrue(driver.FindElement(By.Id("result-stats")).Displayed);
           
            driver.Quit();

        }

    }
}