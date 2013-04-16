using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace sanity
{
    [TestFixture]
    
    public class GcConfirmChange
    {
        private IWebDriver driver;
        private IWebElement webby;  
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

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
        
        public void GcConfirmChangeMain()
        {
           
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/");
            // Begin.  Remove all recent cookies to start fresh.  
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().Refresh();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("CONFIRM ZIP")).Click();
            // Dealer Confirmed.
            Thread.Sleep(10000);
            driver.FindElement(By.LinkText("Change Dealer")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.PartialLinkText("Hoover")).Click();
            // Dealer Changed
            Thread.Sleep(10000);
            driver.Close();      
        }

        //Extension Methods... 

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alert.Text;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
