using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using ThoughtWorks;
using ThoughtWorks.Selenium;
using sanitySetup;
using NUnit;
//needed for WebDriverWait.  
using OpenQA.Selenium.Support.UI;

namespace sanitySetup
{
    [TestFixture]

    public class SanityWindowsTest
    {
        private IWebDriver driver;
        private IWebElement element;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        //Ensure m() WaitFor AjaxElement is included in main project.  
        public static void WaitForAjaxElement(IWebDriver driver, By byElement, double timeoutSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(x => x.FindElement(byElement));
        }

    [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://southeast.buyatoyota.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]

        
        
        public void SanityWindows()
        {
            
            
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/#tab=helpful-resources");
            string parentWindow = driver.CurrentWindowHandle;
            PopupWindowFinder finder = new PopupWindowFinder(driver);
            string newHandle = finder.Click(driver.FindElement(By.LinkText("Owners Only")));
            driver.SwitchTo().Window(newHandle);

            
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Toyota Owners[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            
            Thread.Sleep(5000);
            driver.Close();
            driver.SwitchTo().Window(parentWindow);
            Thread.Sleep(15000);
            
            newHandle = finder.Click(driver.FindElement(By.LinkText("Toyota Connections")));
            driver.SwitchTo().Window(newHandle);
            Thread.Sleep(15000);
            driver.Close();
            driver.SwitchTo().Window(parentWindow);
            Thread.Sleep(15000);

            newHandle = finder.Click(driver.FindElement(By.LinkText("Edmunds.com")));
            driver.SwitchTo().Window(newHandle);
            
            try
            {
                Assert.AreEqual("New Cars, Used Cars, Car Reviews and Pricing - Edmunds.com", driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            
            driver.Close();
            driver.SwitchTo().Window(parentWindow);
            Thread.Sleep(15000);

            newHandle = finder.Click(driver.FindElement(By.LinkText("Autotrader.com")));
            driver.SwitchTo().Window(newHandle);
            
            try
            {
                Assert.AreEqual("New Cars, Used Cars - Find Cars at AutoTrader.com", driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            
            driver.Close();
            driver.SwitchTo().Window(parentWindow);
            Thread.Sleep(15000);

            newHandle = finder.Click(driver.FindElement(By.LinkText("Safercar.gov")));
            driver.SwitchTo().Window(newHandle);
            
            try
            {
                Assert.AreEqual("Home | Safercar -- National Highway Traffic Safety Administration (NHTSA)", driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            
            driver.Close();
            driver.SwitchTo().Window(parentWindow);
            Thread.Sleep(15000);

            newHandle = finder.Click(driver.FindElement(By.LinkText("Fueleconomy.gov")));
            driver.SwitchTo().Window(newHandle);
           
            try
            {
                Assert.AreEqual("Fuel Economy", driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            
            driver.Close();
            driver.SwitchTo().Window(parentWindow);
            driver.FindElement(By.LinkText("Glossary Of Terms")).Click();
            WaitForAjaxElement(driver, By.LinkText("Glossary of Terms"), 30);
            
            driver.Quit(); 
            
            
        }
    }
}
//End Window Switching Code.



            