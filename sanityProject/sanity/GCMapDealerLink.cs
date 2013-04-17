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
    
    public class GetConnectedMap
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
        
       /* [TearDown]
        public void GetConnectedMapMain()
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
        } */

        [Test]
        
        public void GCMapMain()
        {
           
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/#");
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().Refresh();
            Thread.Sleep(20000);

            // GetConnected : Map & DealerLink.    
     
            driver.FindElement(By.LinkText("CONFIRM ZIP")).Click();
            Thread.Sleep(20000);
            driver.FindElement(By.LinkText("Map & Directions")).Click();
            Thread.Sleep(10000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Map')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }


            Thread.Sleep(10000);

            driver.Navigate().Back();

            Thread.Sleep(10000);
            //End Map        
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
