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
    
    public class Carousel
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
        
        public void CarouselMain()
        {
           
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/");
            // Begin.  Remove all recent cookies to start fresh.  
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().Refresh();
            Thread.Sleep(10000);
            driver.FindElement(By.LinkText("CONFIRM ZIP")).Click();
            // Dealer Confirmed.
            // Scion 1st Tier
            driver.FindElement(By.CssSelector("a.tab-lineup-link > span")).Click();
            driver.FindElement(By.CssSelector("li.forward-button > a")).Click();
            driver.FindElement(By.CssSelector("li.forward-button > a")).Click();
            driver.FindElement(By.CssSelector("li.forward-button > a")).Click();
            driver.FindElement(By.CssSelector("li.back-button > a")).Click();
            driver.FindElement(By.CssSelector("li.back-button > a")).Click();
            driver.FindElement(By.CssSelector("li.back-button > a")).Click();
            driver.FindElement(By.CssSelector("li.back-button > a")).Click();
            driver.FindElement(By.CssSelector("li.forward-button > a")).Click();
            driver.FindElement(By.CssSelector("li.forward-button > a")).Click();
            driver.FindElement(By.CssSelector("li.forward-button > a")).Click();
            // Carousel Arrow Functions Verified.

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Scion')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            // [Scion] Carousel Tier 2 Load verified.  

            Thread.Sleep(10000);

            driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div/ul/li[7]/img")).Click();
            //driver.FindElement(By.CssSelector("img[alt=\"2012 Scion xB\"]")).Click();
            // Warning: verifyTextPresent may require manual changes

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Scion')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            // 3rd Tier [2012 Scion XB] load verified.
            // ***Begin 3rd Tier Link Tests***  
            Thread.Sleep(10000);
            //Navigate directly to the 2nd tier.  
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/#family=Scion&series=2012+Scion+xB");
            Thread.Sleep(10000);
            //Select vehicle, which loads the 3rd tier.  
            driver.FindElement(By.XPath("//img[@alt='2013 Scion xB']")).Click();
            Thread.Sleep(10000);

            //Browse Models--->  
            Thread.Sleep(10000);

            driver.FindElement(By.XPath("//a[@href='/scion-xb#explore=models']")).Click();
            Thread.Sleep(10000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Models & Features')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }


            driver.Navigate().Back();

            //Pick Your Color-->
            Thread.Sleep(10000);
            driver.FindElement(By.XPath("//a[@href='/scion-xb#explore=colors']")).Click();
            Thread.Sleep(5000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Colors')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Back();
            Thread.Sleep(10000);
            driver.FindElement(By.XPath("//a[@href='/scion-xb#explore=photos']")).Click();

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Gallery')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Back();
            Thread.Sleep(10000);

            //disabled - unable to located. driver.FindElement(By.XPath("//a[@href='/scion-xb#explore=models&modal=feature-finder&selected-series=scion-xB']")).Click(); 
            //Using generic X path.  
            driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div[5]/div/div[3]/ul/li[4]/a")).Click();

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Accessories ')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Back();
            Thread.Sleep(10000);

            driver.FindElement(By.XPath("//a[@href='/scion-xb/offers']")).Click();
            //works --driver.FindElement(By.XPath("//a[contains(text(),'View Offers')]")).Click();
            Thread.Sleep(5000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'2012 Offers')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            driver.Navigate().Back();
            Thread.Sleep(5000);

            driver.FindElement(By.XPath("//a[@href='/scion-xb#explore=accessories&modal=accessory-catalog&series=scion-xb']")).Click();
            //works -- driver.FindElement(By.XPath("//a[contains(text(),'See Options')]")).Click();

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Accessories')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            // ***End 3rd Tier Link Tests***
            // ***Begin Navigation Back Carousel. 3rd tier to 2nd Tier***
            driver.Navigate().Back();
            Thread.Sleep(5000);


            driver.FindElement(By.CssSelector("a.families-back-link")).Click();
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'The Family Lineup')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            // ***End Carousel Testing  ***  
            
            Thread.Sleep(5000);
           
            
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
