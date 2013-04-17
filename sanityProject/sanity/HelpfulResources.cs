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
    
    public class HelpfulResources
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
       /* public void TeardownTest()
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
        
        public void HelpfulResourcesMain()
        {
           
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/#");
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().Refresh();

            // Begin Helpful Resources 
            Thread.Sleep(20000);
            driver.FindElement(By.CssSelector("a.tab-resources-link > span")).Click();
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Helpful Resources')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);

            driver.FindElement(By.LinkText("Payment Calculator")).Click();
            Thread.Sleep(10000);
            //error -- unable to locate 
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Calculate')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(10000);
            driver.FindElement(By.CssSelector("button.exit")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Lease vs. Purchase")).Click();
            Thread.Sleep(5000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Lease vs. Purchase')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("button.exit")).Click();
            Thread.Sleep(10000);
            driver.FindElement(By.LinkText("Right Vehicle For Your Budget")).Click();
            Thread.Sleep(5000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Find the Right Toyota')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("button.exit")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Credit Application")).Click();
            Thread.Sleep(5000);

            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("CreditApplication")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("button.exit")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Glossary Of Terms")).Click();
            Thread.Sleep(5000);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("GlossaryOfTerms")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("button.exit")).Click();
            Thread.Sleep(10000);
            driver.FindElement(By.LinkText("Schedule An Appointment")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("button.exit")).Click();
            Thread.Sleep(10000);
            driver.FindElement(By.LinkText("View Service Specials")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("button.exit")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("View Accessory Catalog")).Click();
            Thread.Sleep(5000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Accessory Catalog')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(5000);
            // Comparison Tools / Advantastar Hyperlink.  

            driver.FindElement(By.LinkText("close")).Click();
            Thread.Sleep(5000);

            driver.Navigate().Refresh();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Competitive Comparisons")).Click();
            Thread.Sleep(5000);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("CompetitiveComparisons")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);

            driver.Navigate().Back();

            //Helpful Resource popup sanityWindows injection
            Thread.Sleep(10000);
            string parentWindow = driver.CurrentWindowHandle;
            PopupWindowFinder finder = new PopupWindowFinder(driver);
            Thread.Sleep(5000);
            string newHandle = finder.Click(driver.FindElement(By.LinkText("Owners Only")));
            driver.SwitchTo().Window(newHandle);

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Toyota Owners')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(10000);
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
            Thread.Sleep(10000);
            //driver.FindElement(By.ClassName("exit")).Click();
            driver.Navigate().Back();
            Thread.Sleep(5000);

            //End Helpful Resources popupwindow sanityWindow .   



            // Begin PreOwned General Link Verification

            driver.FindElement(By.LinkText("Search Inventory")).Click();

            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("CertifiedTab")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Back();
            // End PreOwned General Link Verification
            Thread.Sleep(10000);
            driver.FindElement(By.LinkText("What is a Certified Pre-owned Vehicle?")).Click();
            Thread.Sleep(10000);

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Toyota Certified Program')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(10000); 
            driver.Navigate().Back();
            //End Helpful Resources Section
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
