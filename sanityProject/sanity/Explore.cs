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
    
    public class Explore
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
        
        public void ExploreMain()
        {
           
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/#");
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().Refresh();
            //Begin Explore Area
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/tacoma#tab=compare&explore=models");
            Thread.Sleep(5000);

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Models & Features')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("li.compare-features > a")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("a.modal-link > span")).Click();
            Thread.Sleep(3000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Compare Models + Features')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            
            driver.FindElement(By.CssSelector("em")).Click();
            Thread.Sleep(3000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Feature Finder')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Refresh();
            Thread.Sleep(5000);
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/tacoma#tab=compare&explore=colors");

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Colors')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Feature Finder')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(10000);

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Feature Finder')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);

            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/tacoma#tab=compare&explore=accessories");
            Thread.Sleep(5000);

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Accessories')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Accessories Catalog')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[@href='#']")).Click();

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Accessories Catalog')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/tacoma#explore=photos");

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Gallery')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Gallery - click thumbnail for larger image or to play movie.')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.CssSelector("div.media-gallery > ul.actions > li.accessories-catalog > a")).Click();

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Accessory Catalog')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Back();

            //END EXPLORE AREA

            
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
