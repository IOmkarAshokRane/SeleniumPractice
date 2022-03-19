using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace SeleniumPractice
{
    public class GettingStarted
    {
        public static void Main(string[] args) {
            //Setup
            new DriverManager().SetUpDriver(new ChromeConfig());
            var options = new ChromeOptions();
            var driver = new ChromeDriver(options);

            //Launch
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
            var title = driver.Title; // => "Google"

            //Locators
            var searchBox = driver.FindElement(By.Name("q"));
            var searchButton = driver.FindElement(By.XPath("(//input[@value='Google Search'])[2]"));
            var agreeTerms = driver.FindElement(By.Id("L2AGLb"));

            //Actions
            agreeTerms.Click();
            searchBox.SendKeys("Selenium");
            searchButton.Click();
            var attribute = driver.FindElement(By.Name("q")).GetAttribute("value"); // => "Selenium"
            
            //quit the driver to kill all processess related to the webdriver
            driver.Quit();

        }

    }
}
