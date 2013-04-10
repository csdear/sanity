using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Selenium;


namespace Test
{
    [TestFixture]

    class AssertionTester
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
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/");
            Thread.Sleep(10000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Choose a vehicle type to Explore More')]"));
                
            }
            
            catch(AssertionException e)
            {
                
                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);

            

        }

            }
        }



        



        
        

    

