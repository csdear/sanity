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
    
    public class FamilyPages
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
        }
          */
        [Test]
        
        public void FamilyPagesMain()
        {
           
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/#");
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().Refresh();
            Thread.Sleep(20000);

            // Family Pages 
            driver.FindElement(By.XPath("//img[@alt='Cars and Minivan']")).Click();

            Thread.Sleep(5000);

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Toyota cars and minivan')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Back();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//img[@alt='Trucks']")).Click();

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Toyota trucks')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Back();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//img[@alt='Crossovers and SUVs']")).Click();

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Toyota crossovers and suvs')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Back();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//img[@alt='Hybrids']")).Click();

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Toyota hybrids')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Back();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//img[@alt='Scion']")).Click();

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Toyota scion')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Back();

            // End FamilyPage General Load

            // Family Page Elements - Avalon
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//img[@alt='Cars and Minivan']")).Click();
            Thread.Sleep(5000);

            driver.FindElement(By.XPath("//a[@href='#AprOffer_Camry']")).Click();

            driver.FindElement(By.XPath("//a[@href='#LeaseOffer_Camry']")).Click();

            try
            {
                driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div/div[2]/div[3]/div/a")).Click();
            }
            catch
            {
                driver.FindElement(By.XPath("//a[@href='/camry']")).Click();
            }


            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'New Inventory')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            driver.Navigate().Back();

            // Promotion Tools - Subject to change - TAM configurable.
            //Verify the text in all four
            Thread.Sleep(5000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'LEARN MORE ABOUT TOYOTA PARTS AND SERVICE')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'THE TOOLS YOU NEED TO GET THE CAR YOU WANT')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'FIND YOUR NEW TOYOTA')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(5000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'TOYOTA CERTIFIED USED VEHICLES')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            //Selecting hyperlinks asscociated with the Promo pods.  
            driver.FindElement(By.PartialLinkText("LEARN MORE ABOUT TOYOTA PARTS")).Click();
            Thread.Sleep(5000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Tires')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Back();
            Thread.Sleep(5000);
            driver.FindElement(By.PartialLinkText("THE TOOLS YOU NEED")).Click();
            Thread.Sleep(5000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Helpful Resources')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Back();
            Thread.Sleep(5000);
            driver.FindElement(By.PartialLinkText("FIND YOUR NEW TOYOTA")).Click();

            //914 --
            Thread.Sleep(10000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Find the Right Toyota')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            driver.Navigate().Back();
            Thread.Sleep(5000);
            driver.FindElement(By.PartialLinkText("TOYOTA CERTIFIED USED")).Click();
            Thread.Sleep(5000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Preowned')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Back();
            Thread.Sleep(5000);
            // End Promotion Tools
            // End Family Page
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
