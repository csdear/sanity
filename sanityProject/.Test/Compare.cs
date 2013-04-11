using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;



namespace Test
{
    [TestFixture]

    class Compare
    {
        private IWebDriver driver;
        private IWebElement webby;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

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

        public void CompareMain()
        {
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/tacoma");
            
            //1.  Navigate to inventory page...     
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/tacoma");
            Thread.Sleep(10000);
            //2. Select two Vehicles to compare.  The checkbox or the Compare button in the row will suffice.  
            
            driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div/div[3]/div/div[3]/div/div/div[4]/div[2]/label/span")).Click();
            driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div/div[3]/div/div[4]/div/div/div[4]/div[2]/label/span")).Click();
            
            //3.  Now select the Compare Tab
            driver.FindElement(By.Id("CompareTab")).Click(); 
            //untested --driver.FindElement(By.CssSelector("button.compare.btn-small-white")).Click();
            Thread.Sleep(10000);
            //Verify Compare Loads.  
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Compare')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            //Select Change Selections section loads
            driver.FindElement(By.CssSelector("a.compare-change-link > span")).Click();
            Thread.Sleep(5000);
            //verify the h2 text element unique.  

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Please select up to four vehicles to start your comparison. ')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            //Click the Compare Selected Vehicles button to got back.  
            driver.FindElement(By.CssSelector("button.compare btn-white")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("button.remove")).Click();
            //Details button brings up the monroney page.
            driver.FindElement(By.CssSelector("button.compare-details-link")).Click();
            Thread.Sleep(15000);
            //Navigating back, to close the details page.
            driver.Navigate().Back();  
            Thread.Sleep(10000);
            //Finally, navigating back to the New Inventory tab.  
            driver.FindElement(By.Id("NewInventoryTab")).Click();
            Thread.Sleep(5000);
            //Verify back at New Inventory
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'New Inventory')]"));

            }

            catch (AssertionException e)
            {
             
                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            driver.Close(); 
            Thread.Sleep(10000);
            
        }




        



        
        

    }
}

