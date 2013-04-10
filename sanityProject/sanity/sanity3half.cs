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
    
    public class Sanity3Half
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
        
        public void ThirdHalf()
        {
           //C.  
            //3rd half -- begins at Toyo Tacoma 'Explore' Options.  
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //Split here -- 2nd half of test begins at Toyota Tacoma Inventory Page.  
            //dealer unconfirmed assumed Limbaugh.  
            //BREAK HERE  --- BEGIN Sanity 3rd HALF.   
            // Explore>>
            
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
            // Warning: verifyTextPresent may require manual changes
            
            driver.FindElement(By.CssSelector("a.modal-link > span")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [runScript | $(".ui-dialog-titlebar-close").click() | ]]
            // Warning: verifyTextPresent may require manual changes
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Compare Models + Features')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            //? em select?  
            driver.FindElement(By.CssSelector("em")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Feature Finder')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [runScript | $(".ui-dialog-titlebar-close").click() | ]]
            
            //untested -- trying to remove the DETAILS popup window from the prior section.
            // didnt workdriver.FindElement(By.LinkText("exit")).Click();
            //driver.FindElement(By.XPath("/html/body/div[22]/div/a/span")).Click();
            //attempting base refresh, wait, nav away
            driver.Navigate().Refresh();
            Thread.Sleep(5000);
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/tacoma#tab=compare&explore=colors");
            // Warning: verifyTextPresent may require manual changes
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Colors')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            // Warning: verifyTextPresent may require manual changes


            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Feature Finder')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(10000);
            //This might be a generic link for all the lower right hand buttons... test...
            /////// not visdriver.FindElement(By.CssSelector("li.compare-features > a")).Click();
            
            Thread.Sleep(5000);
            // Warning: verifyTextPresent may require manual changes
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Feature Finder')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            // ERROR: Caught exception [ERROR: Unsupported command [runScript | $(".ui-dialog-titlebar-close").click() | ]]
            
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/tacoma#tab=compare&explore=accessories");
            Thread.Sleep(5000);

            // Warning: verifyTextPresent may require manual changes
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Accessories')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            
            // Warning: verifyTextPresent may require manual changes
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Accessories Catalog')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            //Unable to Locate driver.FindElement(By.LinkText("Accessories Catalog")).Click();
            //unble to locatedriver.FindElement(By.PartialLinkText("Catalog")).Click();
            //nope..driver.FindElement(By.CssSelector("em")).Click();  
            //Fail driver.FindElement(By.XPath("//a[contains(text(),'Catalog')]")).Click();
            driver.FindElement(By.XPath("//a[@href='#']")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Accessories Catalog')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [runScript | $(".ui-dialog-titlebar-close").click() | ]]
            //driver.FindElement(By.LinkText("Media Gallery")).Click();
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/tacoma#explore=photos");
            // Warning: verifyTextPresent may require manual changes
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Gallery')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            // Warning: verifyTextPresent may require manual changes

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Gallery - click thumbnail for larger image or to play movie.')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            
            
            
            driver.FindElement(By.CssSelector("div.media-gallery > ul.actions > li.accessories-catalog > a")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Accessory Catalog')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            //driver.FindElement(By.LinkText("close")).Click();
            driver.Navigate().Back();

            // //END EXPLORE AREA
            
            // Offers - Vehicle Specific - In this instance, CAMRY  
            
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/tacoma/offers");
            // Warning: verifyTextPresent may require manual changes

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'2013 Offers')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            // Warning: verifyTextPresent may require manual changes
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

            // Warning: verifyTextPresent may require manual changes
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
            // Warning: verifyTextPresent may require manual changes
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
            // Warning: verifyTextPresent may require manual changes

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'4Runner')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            
            // Warning: verifyTextPresent may require manual changes
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Camry')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            
            // Warning: verifyTextPresent may require manual changes
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Highlander')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            // Warning: verifyTextPresent may require manual changes
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Matrix')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            // Warning: verifyTextPresent may require manual changes
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'RAV4')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            // Warning: verifyTextPresent may require manual changes
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'SCION SERVICE BOOST PROGRAM')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            
            // Warning: verifyTextPresent may require manual changes
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
            // Warning: verifyTextPresent may require manual changes
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Featured Offers')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            // Warning: verifyTextPresent may require manual changes

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Vehicle')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            // Warning: verifyTextPresent may require manual changes
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Lease')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            // Warning: verifyTextPresent may require manual changes
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'APR')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            // Warning: verifyTextPresent may require manual changes
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Programs')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            // Warning: verifyTextPresent may require manual changes
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Toyota Care - Complimentary Maintenance Program')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            
            // //END OFFERS
            
            // BEGIN BUILD - BYO  - CAMRY  
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/camry/build");
            // Warning: verifyTextPresent may require manual changes
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'SELECT A GRADE')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            // Warning: verifyTextPresent may require manual changes
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Select A Model')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
   //[Ln 510 :  Unable to locate element Selector Next -- 4/4/2013  
            driver.FindElement(By.LinkText("Next")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Exterior:[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Interior:[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("div.color-description")).Click();
            driver.FindElement(By.CssSelector("img[alt=\"Barcelona Red Metallic\"]")).Click();
            driver.FindElement(By.XPath("(//img[@alt='Ivory Fabric'])[7]")).Click();
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("div.vehicle-image > img")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("Next")).Click();
            driver.FindElement(By.CssSelector("li.packages-tab.selected")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Click on package name for details[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("Prev")).Click();
            driver.FindElement(By.LinkText("Next")).Click();
            driver.FindElement(By.LinkText("Next")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Click on accessory name for details[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Wheels[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Technology[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Options[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("div.vehicle-image > img")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("Next")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*[\\s\\S]* Required Field[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Preferred Method Of Contact[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Submit[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("li.options-tab")).Click();
            driver.FindElement(By.CssSelector("li.packages-tab")).Click();
            driver.FindElement(By.CssSelector("li.color-tab")).Click();
            driver.FindElement(By.CssSelector("li.model-tab")).Click();
            driver.FindElement(By.CssSelector("img.tam-image")).Click();
            // End Sanity Testing
            
        }
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
