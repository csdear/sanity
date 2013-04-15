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

    class InvPaginationLinks
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

        public void TestComponent()
        {
            /*driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/tacoma");
            Thread.Sleep(10000);
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[contains(text(),'Let us help!')]")).Click();
            Thread.Sleep(5000);  */
            
            //1.  Insert a URL. ex.,   
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/#tab=helpful-resources&tool=payment-calculator");
            Thread.Sleep(10000);


            //2.  Test your locator code ex.
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'<h1>Calculate<em>Your Payment</em></h1>')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(5000);

            //3.  Verify 
            Thread.Sleep(10000);

            /* Inventory Pagination Testing 
            driver.FindElement(By.PartialLinkText("2")).Click();
            Thread.Sleep(10000);
            driver.FindElement(By.PartialLinkText("3")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[contains(text(),'Next')]")).Click();
            //driver.FindElement(By.PartialLinkText("Next")).Click();
            Thread.Sleep(5000);
      		driver.FindElement(By.XPath("//a[contains(text(),'Prev')]")).Click();
            //driver.FindElement(By.PartialLinkText("Prev")).Click();
            Thread.Sleep(20000);
            driver.FindElement(By.XPath("//a[contains(text(),'Last')]")).Click();
            //driver.FindElement(By.PartialLinkText("Last")).Click();
            Thread.Sleep(10000);
            //driver.FindElement(By.PartialLinkText("First")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'First')]")).Click();
            Thread.Sleep(10000);
            //results per page
            driver.FindElement(By.PartialLinkText("10")).Click();
            Thread.Sleep(10000);
            driver.FindElement(By.PartialLinkText("25")).Click();
            Thread.Sleep(10000);
            driver.FindElement(By.PartialLinkText("50")).Click();
            Thread.Sleep(10000); */
            

        }




        



        
        

    }
}

