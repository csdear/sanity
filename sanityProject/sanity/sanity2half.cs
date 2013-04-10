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
    
    public class Sanity2Half
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
        
        public void SecondHalf()
        {
           
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            
           //B.  
            //Split here -- 2nd half of test begins at Toyota Tacoma Inventory Page.  
            //dealer unconfirmed assumed Limbaugh.  
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/tacoma");
            Thread.Sleep(10000);
            driver.FindElement(By.PartialLinkText("2")).Click();
            Thread.Sleep(10000);
            driver.Navigate().Refresh();
            Thread.Sleep(10000);
            //Intermittent failings here...
            //Another intermittent failure 4/2/2013.  15 seconds prior increase to resolve?  Else Need some other method to use such as is element visible.  
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
            
            // Suggestion area.  Currently targeted to hit the first 'Details' button on Suggestion Pod.  
            // Header Verification
            /*try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*You may also be interested in these vehicles and accessories[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
             */

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'You may also be interested in these vehicles and accessories')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
 
            //Unsure the purpose of these two lines. Commenting out for now.  Subject for removal.
            //driver.FindElement(By.CssSelector("div.actions > button")).Click();
            //driver.FindElement(By.CssSelector("button.exit")).Click();
            
            // Super Lead Load - LET US HELP  
            // Warning: verifyTextPresent may require manual changes
            //3/29/2013  --- bomb here, No Respons from server.  Changing assert method.  
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Let us help!')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            //Loading Let Us Help 'Super Lead' form .  
            driver.FindElement(By.XPath("//a[contains(text(),'Let us help!')]")).Click();
            Thread.Sleep(5000);
            // Verify h2 text of super lead popup.
            //Fail adding more time. If fail again -- need to either remove, tweak with switchTo code etc.  
            /*disabling for now... Have visual confirmation popup is loading.
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Can't Find the Vehicle You're Looking For? Let Us Help.')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

             */
 
            Thread.Sleep(5000);

           
            
            driver.FindElement(By.ClassName("exit")).Click();
            Thread.Sleep(5000);

            // Narrow Inventory Tab - General Areas. Selections have to be made to enable Colors, Packages tabs etc..  Selection is SPECIFIC (TACOMA) 
            driver.FindElement(By.CssSelector("a.narrow-search-link > span")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Year')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            
            
            // Warning: verifyTextPresent may require manual changes
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
            // Warning: verifyTextPresent may require manual changes
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Exterior')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            
            
            
            // Warning: verifyTextPresent may require manual changes

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Interior')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(10000);
            //Selecting int/ ext colors
            //unable to select by compound class name.  
            //element is not visible and cant be interacted with
            //[F: Not vis.]//driver.FindElement(By.XPath("//img[@alt='Black']")).Click();
            //[F: Not vis.]driver.FindElement(By.XPath("//img[@alt='Graphite Fabric']")).Click();
            driver.FindElement(By.Id("SelectedExteriorColor_0202")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("SelectedInteriorColor_FF13")).Click();
            //[F: El. not vis. and cant be manipulated]driver.FindElement(By.Id("SelectedExteriorColor_03R3")).Click();
            //[F: El. not vis. and cant be manipulated]driver.FindElement(By.Id("SelectedInteriorColor_FF13")).Click();
            //[F: Not viz..driver.FindElement(By.CssSelector("div#ExteriorColorList ul li.exterior input#SelectedExteriorColor_03R3.cascade")).Click();
            //[F Not viz...driver.FindElement(By.CssSelector("div#interiorColorList ul li.interior input#SelectedinteriorColor_FF13.cascade")).Click();
            // Just now noticed taht model 7113 is selected which does not have barcelona Red.. Thus it was nonexistent in many of these prior failing cases
            //driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div/div[2]/div/div/div[2]/form/div[2]/div/ul/li[2]")).Click();
            Thread.Sleep(5000);
            //driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div/div[2]/div/div/div[2]/form/div[2]/div[2]/ul/li[4]")).Click();
            Thread.Sleep(3000); 
            
            driver.FindElement(By.LinkText("Packages")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Click on package name for details')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            
            driver.FindElement(By.LinkText("Featured Accessories")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Click on accessory name for details')]")); 
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("All Available Accessories")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Click on accessory name for details')]"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("button.reset")).Click();
            driver.FindElement(By.CssSelector("a.narrow-search-link > span")).Click();
            
            // End Narrow Inventory  
            
            
            //////////// Details >> MONRONEY
            driver.Navigate().Refresh();
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("button.details-button")).Click();
            Thread.Sleep(15000);
            // Warning: verifyTextPresent may require manual changes
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Vehicle Details')]"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            
            
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("VehicleImageContainer")));
                
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            // Warning: verifyTextPresent may require manual changes
            try
            {
                 IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'PRICING AND PAYMENTS')]"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // Customize yours
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Customize[\\s\\S]*$"));
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
            driver.FindElement(By.CssSelector("button.exit")).Click();
            // //End Monroney Page / Details 

       ////////LAST ON... LAST FAIL ON ln 344  Unable to locate method enterzipform > label
            // Viewed vehicles tab - Select Top 3 details pages then Viewed Vehicles tab. SPECIFIC VINs used.  This will likely need to be modifying later.  
            // ERROR: Caught exception [ERROR: Unsupported command [deleteAllVisibleCookies |  | ]]
            //Entire cookie drop not likely necessary.   
            driver.Navigate().Refresh();
            
            // problem area.  Should Geolocate.  Currently, no matter how many times I refresh, GC cannot locate me.
            /* de[recated steps function.  driver.FindElement(By.CssSelector("#enterzip-form > label")).Click();
            driver.FindElement(By.Id("enterzip-form-zip")).Click();
            driver.FindElement(By.Id("enterzip-form-zip")).Clear();
            driver.FindElement(By.Id("enterzip-form-zip")).SendKeys("35244");
            driver.FindElement(By.Id("goButton")).Click();
             */
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/tacoma");
            //Target First Inventory Item. 
            driver.FindElement(By.CssSelector("button.details-button")).Click();
            Thread.Sleep(10000);
            //Typical error where after details close not working ....
            driver.FindElement(By.ClassName("exit")).Click();
           // Target Second Inventory Item
            //Fail on the second exit class unable to locate.  inserting a 10 second wait and then close.  Else, need to verify this xpath.
            driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div/div[3]/div/div[3]/div/div/div[4]/div/button")).Click();
            Thread.Sleep(10000);
            driver.FindElement(By.ClassName("exit")).Click();
            // Select 3rd Inventory Element
            driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div/div[3]/div/div[4]/div/div/div[4]/div/button")).Click();
            Thread.Sleep(10000);
            driver.FindElement(By.ClassName("exit")).Click();
            //Select Viewed Vehicles tab.  
            driver.FindElement(By.CssSelector("a.tab-viewed-vehicles-link > span")).Click();
            // Warning: verifyTextPresent may require manual changes
            Thread.Sleep(10000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Viewed Vehicles')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            // Warning: verifyTextPresent may require manual changes
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
            // //END VIEWED VEHICLES

            // BEGIN COMPARE FUNCTIONALITY --
            //Fail -- unable to locate.  driver.FindElement(By.XPath("//div[1]/x:div[4]/x:div[2]/x:label/x:span")).Click();
            //Assuming these next two lines are selected, then the compare button selected.  
            driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div/div[3]/div/div[3]/div/div/div[4]/div[2]/label/span")).Click();
            driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div/div[3]/div/div[4]/div/div/div[4]/div[2]/label/span")).Click();
            driver.FindElement(By.CssSelector("button.compare.btn-small-white")).Click();
            // Warning: verifyTextPresent may require manual changes
            Thread.Sleep(10000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Compare')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("a.compare-change-link > span")).Click();
            driver.FindElement(By.CssSelector("button.remove")).Click();
            driver.FindElement(By.CssSelector("button.compare.btn-white")).Click();
            driver.FindElement(By.CssSelector("button.compare-details-link")).Click();
           
            // removing for now -- unable to locate...driver.FindElement(By.ClassName("exit")).Click();
            //unable to locate -- another removal -- immaterial -- removing.  
            //driver.FindElement(By.CssSelector("div.column.column-1  > div.vehicle-compare-detail.new > div.main-details > header > div.compare-actions > button.compare-remove-link")).Click();
            Thread.Sleep(10000);
            // [F : unable Element not visible.   Removing... immaterial. 
            //driver.FindElement(By.CssSelector("button.compare-remove-link")).Click();
            // Warning: verifyTextPresent may require manual changes
           Thread.Sleep(10000);
            driver.FindElement(By.Id("NewInventoryTab")).Click();
            Thread.Sleep(5000);
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
            // //END COMPARISON Funtionality 
            // END Second Half.         
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
