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

    class TestClass
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
            baseURL = "http://uat.2010.setbuyatoyota.com/";
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
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/#");
            Thread.Sleep(10000);

            /*Link selection testing - xPath to non unique Link  

            //driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/cars-and-minivan/family");
            //driver.FindElement(By.LinkText("Learn More")).Click();
            
            //Thread.Sleep(5000);
            
            works-- but loads avalon inventory. Target was camry... driver.FindElement(By.CssSelector("html.js body.en div#Page div#Content div#MainContent div#MainTabs.tabs div.tab-content div#FamilyContainer.ui-tabs-panel div.family-series-list div.family-series div.explore-actions div.actions a")).Click();
            /xpath works but can be unstable. I have no other choice at the moment. Going with xpath below.  
            driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div/div[2]/div[3]/div/a")).Click();
            Thread.Sleep(30000);*/
            // End Link Selection TEsting xpath to Non Unique Link

            //Part and Service link selection -  Unable to Locate Element.  
            //Pause introduced.  Fail.  
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/cars-and-minivan/family");
            Thread.Sleep(5000);
            driver.FindElement(By.PartialLinkText("LEARN MORE ABOUT TOYOTA PARTS")).Click();
            Thread.Sleep(5000);  

            //Assert Test 
            //Regex Version  
            driver.Navigate().GoToUrl("http://southest.buyatoyota.com");
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Scion[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

        }



        



        
        

    }
}

