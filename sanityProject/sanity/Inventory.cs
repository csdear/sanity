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
    
    public class InventoryFunctions
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
        
        public void InventoryFunctionsMain()
        {
           
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/#");
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().Refresh();
            Thread.Sleep(20000);
            // Inventory Page. Tacoma. 

            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/tacoma");
            Thread.Sleep(10000);  
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'New Inventory')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.CssSelector("button.inventory-view.compact")).Click();
            driver.FindElement(By.CssSelector("button.inventory-view.full")).Click();

            Thread.Sleep(10000);

            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/tacoma");
            Thread.Sleep(10000);
            driver.FindElement(By.PartialLinkText("2")).Click();
            Thread.Sleep(10000);
            driver.Navigate().Refresh();
            Thread.Sleep(10000);

            driver.FindElement(By.PartialLinkText("3")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[contains(text(),'Next')]")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[contains(text(),'Prev')]")).Click();
            Thread.Sleep(20000);
            driver.FindElement(By.XPath("//a[contains(text(),'Last')]")).Click();
            Thread.Sleep(10000);
            driver.FindElement(By.XPath("//a[contains(text(),'First')]")).Click();
            Thread.Sleep(10000);

            //Results per page
            driver.Navigate().Refresh();
            Thread.Sleep(10000);
            driver.FindElement(By.PartialLinkText("10")).Click();
            Thread.Sleep(10000);
            driver.Navigate().Refresh();
            driver.FindElement(By.PartialLinkText("25")).Click();
            Thread.Sleep(10000);
            driver.Navigate().Refresh();
            driver.FindElement(By.PartialLinkText("50")).Click();
            Thread.Sleep(10000);

            //Suggestion Area

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'You may also be interested in these vehicles and accessories')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);


            // Super Lead Form - LET US HELP  

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Let us help!')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[contains(text(),'Let us help!')]")).Click();
            Thread.Sleep(30000);
            driver.FindElement(By.ClassName("exit")).Click();
            Thread.Sleep(5000);

            // Narrow Inventory Tab - General Areas. Selections have to be made to enable Colors, Packages tabs etc..  Selection is SPECIFIC (TACOMA) 

            driver.FindElement(By.CssSelector("a.narrow-search-link > span")).Click();
            Thread.Sleep(3000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Year')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(3000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Model')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.Id("SelectedYear_2013")).Click();
            driver.FindElement(By.Id("SelectedCab_Access")).Click();
            driver.FindElement(By.Id("SelectedModel_2")).Click();
            driver.FindElement(By.XPath("(//a[contains(text(),'Colors')])[2]")).Click();
            Thread.Sleep(3000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Exterior')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(3000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Interior')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(10000);
            driver.FindElement(By.Id("SelectedExteriorColor_0202")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("SelectedInteriorColor_FF13")).Click();
            Thread.Sleep(5000);
            
            driver.FindElement(By.LinkText("Packages")).Click();

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Click on package name for details')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.LinkText("Featured Accessories")).Click();
            Thread.Sleep(3000);
            try
            {

                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Click on accessory name for details')]"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("All Available Accessories")).Click();
            Thread.Sleep(3000);
            try
            {

                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Click on accessory name for details')]"));
            }

            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.CssSelector("button.reset")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("a.narrow-search-link > span")).Click();
            Thread.Sleep(3000);
            // End Narrow Inventory  


            // Details Page >> MONRONEY
            driver.Navigate().Refresh();
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("button.details-button")).Click();
            Thread.Sleep(15000);

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Vehicle Details')]"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(3000);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("VehicleImageContainer")));

            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(3000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'PRICING AND PAYMENTS')]"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            // Customize yours

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Customize')]"));
            }

            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("Wheels")).Click();
            driver.FindElement(By.LinkText("Audio")).Click();
            driver.FindElement(By.LinkText("Options")).Click();
            driver.FindElement(By.CssSelector("a.tab-packages-link")).Click();
            driver.FindElement(By.LinkText("Wheels")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("button.exit")).Click();
            Thread.Sleep(3000);
            //End Details Page - Monroney 

            //Viewed Vehicles 
            driver.Navigate().Refresh();
            Thread.Sleep(3000);
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/tacoma");
            //Target First Inventory Item. 
            driver.FindElement(By.CssSelector("button.details-button")).Click();
            Thread.Sleep(15000);
            driver.FindElement(By.ClassName("exit")).Click();
            // Target Second Inventory Item
            driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div/div[3]/div/div[3]/div/div/div[4]/div/button")).Click();
            Thread.Sleep(12000);
            driver.FindElement(By.ClassName("exit")).Click();
            // Select 3rd Inventory Element
            driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div/div[3]/div/div[4]/div/div/div[4]/div/button")).Click();
            Thread.Sleep(12000);
            driver.FindElement(By.ClassName("exit")).Click();
            //Select Viewed Vehicles tab.  
            driver.FindElement(By.CssSelector("a.tab-viewed-vehicles-link > span")).Click();

            Thread.Sleep(10000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Viewed Vehicles')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(10000);

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Tacoma')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("a.tab-new-inventory-link > span")).Click();
            Thread.Sleep(5000);
            //End Viewed Vehicles section

            //Compare Functionality
            //1.  Navigate to inventory page...     
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/tacoma");
            Thread.Sleep(15000);
            //2. Select two Vehicles to compare.  The checkbox or the Compare button in the row will suffice.  
            Thread.Sleep(10000);
            driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div/div[3]/div/div[3]/div/div/div[4]/div[2]/label/span")).Click();
            Thread.Sleep(10000);
            driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div/div[3]/div/div[4]/div/div/div[4]/div[2]/label/span")).Click();
            Thread.Sleep(10000);
            //3.  Now select the Compare Tab
            // Sub'd in line below -- difficulty finding the compare tab.   driver.FindElement(By.Id("CompareTab")).Click();
            driver.FindElement(By.CssSelector("button.compare.btn-small-white")).Click();
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

            
            Thread.Sleep(10000);
            driver.Close();      
        

            //End COMPARISON Funtionality 
            //End Inventory 
            
            
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
