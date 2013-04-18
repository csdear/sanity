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
    
    public class Offers
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
        
        /*[TearDown]
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
        } */

        [Test]
        
        public void OffersMain()
        {
           
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/#");
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().Refresh();

            // Offers Area - Vehicle Specific - In this instance, CAMRY  
            Thread.Sleep(10000);
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/tacoma/offers");
            Thread.Sleep(5000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'2013 Offers')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'View Inventory')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);

            driver.FindElement(By.ClassName("view-inventory-holder")).Click();
            Thread.Sleep(5000);

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'View Inventory')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            driver.Navigate().Back();
            // END Specific Offers

            // Begin Offers >> Special Programs 

            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/college/offers");
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'$500  - College Graduate Rebate Program')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }


            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("img[alt=\"Camry\"]")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("img[alt=\"Yaris\"]")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // END Offers >> Special Programs 

            // OFFERS Global Page
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/offers");

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'4Runner')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Camry')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Highlander')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Matrix')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'RAV4')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'SCION SERVICE BOOST PROGRAM')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Yaris')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            //Need to test this method -- Assert.IsTrue IsElementPresent image  
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("img[alt=\"Yaris\"]")));
            }

            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Featured Offers')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Vehicle')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Lease')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'APR')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Programs')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Toyota Care - Complimentary Maintenance Program')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            //END OFFERS AREA

            Thread.Sleep(20000);
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
