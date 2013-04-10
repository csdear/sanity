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
    public class ProdSanity20130213
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
        
        public void TheProdSanity20130213Test()
        {
           
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/#");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            
            // Begin.  Remove all recent cookies to start fresh.  
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().Refresh();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("CONFIRM ZIP")).Click();
            // Dealer Confirmed.
            Thread.Sleep(10000);
            driver.FindElement(By.LinkText("Change Dealer")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.PartialLinkText("Hoover")).Click();
            // Dealer Changed
            Thread.Sleep(10000);
            //Select Ask A Question button.  
            //[F: Not Visibledriver.FindElement(By.Id("askaquestion")).Click();
            driver.FindElement(By.ClassName("btn")).Click();
            Thread.Sleep(10000);
            //***Common intermittent fail area when attempting to hit "tab-sms-link" -- driver.FindElement(By.CssSelector("li.questionemail")).Click();
            driver.FindElement(By.ClassName("tab-sms-link")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("span.ui-icon.ui-icon-closethick")).Click();
            // AAQ Form Window Loaded and Closed
            driver.FindElement(By.CssSelector("a.tab-offers-link > span")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Featured Offers[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("a.tab-resources-link > span")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Finance Tools[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // Content Loaded Tabs View Offers and Helpful Resources Verified
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
            //driver.FindElement(By.CssSelector("li.forward-button > a")).Click();
            //driver.FindElement(By.CssSelector("html.js body.en div#Page div#Content div#MainContent div.tabs div.tab-content div#ToyotaLineup.ui-tabs-panel div#FamilyCarousel.carousel ul.items li.item img")).Click();
            // Carousel Arrow Functions Verified.
         
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Scion[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            
            // [Scion] Carousel Tier 2 Load verified.  
            
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
            //Fail : 20130221:9:00.  Doubled wait time to 60 seconds.  
            //Fail2 : 20130221:9:00.  Doubled wait time to 60 seconds. Exception -- No response from server? Trouble selecting
            //Attempting to use new extension code -- two methods provided to be tested. Unable to get it to work
            //Attempting explicit Thread.Sleep() methods for 10 second wait.   After and before selection of element.Thread.Sleep(10000);  
            //Attempitng Sleeper Code again...
            // FINAL ATTEMPT FORCE URL driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/#family=Scion&series=2012+Scion+xB");
            /*for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div/ul/li[7]/img"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }*/
            //driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div/ul/li[7]/img")).Click();         
            
            
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div/ul/li[7]/img"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            //Fail : 20130221:9:03.  inserting 10 seconds implicitwait.    
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div/ul/li[7]/img")).Click();       
            //driver.FindElement(By.CssSelector("img[alt=\"2012 Scion xB\"]")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Scion[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            
            // 3rd Tier [2012 Scion XB] load verified.
            // ***Begin 3rd Tier Link Tests***  
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/#family=Scion&series=2012+Scion+xB");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Thread.Sleep(10000);
            //Fail 2/282013 -  Unable to Locate element - Xpath.. attempting findelemnt by css selector.  
            //driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div[5]/div/div[3]/ul/li/a")).Click();
            //Located appropriate class designation to select -- 2nd tier image lin is 'img.sg_selected'.
            //first attempt P/F by CssSelector. if F, 2nd attempt by className.  
            //Fail 2/28/2013 11:10AM --- NoSuchElementException : css selector img_sg selected'
            //Failed -->>driver.FindElement(By.CssSelector("img.sg_selected")).Click();
            //Failed -- driver.FindElement(By.ClassName("img.sg_selected")).Click();
            //Success!
            driver.FindElement(By.XPath("//img[@alt='2013 Scion xB']")).Click();
            
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Models & Features[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.Navigate().Back();
            driver.FindElement(By.XPath("//img[@alt='2013 Scion xB']")).Click();
            //Browse Models  
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            driver.FindElement(By.XPath("//a[@href='/scion-xb#explore=models']"));  
            //failing intermittently :  driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div[5]/div/div[3]/ul/li[2]/a")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Colors[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.Navigate().Back();
            //Fail 2/28/2013 -- 11:43 AM  LAST ON.  Inserting implicit wait.
            // 2nd fail despite wait... changeing xpath.  This appears to be the 3rd Tier 'View Gllery' link.   
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            //driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div[5]/div/div[3]/ul/li[3]/a")).Click();
            //it appears on the navigate back action, user was taken back to 2nd tier for some reason?  Going to select the Scion xB explicitly again
            driver.FindElement(By.XPath("//img[@alt='2013 Scion xB']")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            driver.FindElement(By.XPath("//a[@href='/scion-xb#explore=photos']"));


            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Gallery[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.Navigate().Back();
            Thread.Sleep(10000);
            driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div[5]/div/div[3]/ul/li[4]/a")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Accessories [\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            //fail-- for some reason back is taking user to 2nd tier now. Adjusting.  
            driver.Navigate().Back();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//img[@alt='2013 Scion xB']")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            driver.FindElement(By.XPath("//a[contains(text(),'View Offers')]")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*2012 Offers[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.Navigate().Back();
            //Assumption user will be sent back to 2nd tier...  
            driver.FindElement(By.XPath("//img[@alt='2013 Scion xB']")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            driver.FindElement(By.XPath("//a[contains(text(),'See Options')]")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Accessories9 [\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // ***End 3rd Tier Link Tests***
            // ***Begin Navigation Back Carousel. 3rd tier to 2nd Tier***
            driver.Navigate().Back();
            driver.FindElement(By.CssSelector("a.families-back-link")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*The Family Lineup[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // ***End Back Navigation Carousel.  ***  
            // ***Begin View Offers Tab***
            driver.FindElement(By.CssSelector("a.tab-offers-link > span")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Featured Offers[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("Next")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Prev")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Details")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Ask a Question[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [runScript | $(".ui-dialog-titlebar-close").click() | ]]
            driver.FindElement(By.LinkText("Find One")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*New Inventory[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.Navigate().Back();
            // Begin Helpful Resources 
            driver.FindElement(By.CssSelector("a.tab-resources-link > span")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Helpful Resources[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("Payment Calculator")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Calculate Your Payment[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("button.exit")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.FindElement(By.LinkText("Lease vs. Purchase")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Lease vs Purchase[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("button.exit")).Click();
            //FailStopTest 2/20/2013 -- introducing imp wait 20 seconds.  
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            driver.FindElement(By.LinkText("Right Vehicle For Your Budget")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Find the Right Toyota[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("button.exit")).Click();
            //StopTestError -  2202013 3:51 PM
            // 3rd instance of this happening..  Placing 10 second implicit wait behind each link.
            driver.FindElement(By.LinkText("Credit Application")).Click();
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("CreditApplication")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("button.exit")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(40));
            driver.FindElement(By.LinkText("Glossary Of Terms")).Click();
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("GlossaryOfTerms")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("button.exit")).Click();
            //Fail 2/20/2013 3:20 PM -- NoSuchElementException -- Schedule An Appointmnet.
            //implicit wait implemented.
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            driver.FindElement(By.LinkText("Schedule An Appointment")).Click(); 
            // ERROR: Caught exception [Error: unknown strategy [alt] for locator [alt=Schedule Your Service]]
            driver.FindElement(By.CssSelector("button.exit")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.FindElement(By.LinkText("View Service Specials")).Click();
            // ERROR: Caught exception [Error: unknown strategy [alt] for locator [alt=Schedule Your Service]]
            driver.FindElement(By.CssSelector("button.exit")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.FindElement(By.LinkText("View Accessory Catalog")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Accessory Catalog[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [runScript | $(".ui-dialog-titlebar-close").click() | ]]
            // Comparison Tools / Advanstar Hyperlink.  
            //Close window issue found here... Two options.. going to see if either work.    
            
            driver.FindElement(By.LinkText("close")).Click();
            Thread.Sleep(5000);
            
            driver.Navigate().Refresh();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Competitive Comparisons")).Click();
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("CompetitiveComparisons")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(5000);
            //[F: Unable to Locate : driver.FindElement(By.ClassName("exit")).Click();

                  	
            
            //test
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            // ERROR: Caught exception [ERROR: Unsupported command [deleteAllVisibleCookies |  | ]]
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
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Toyota Owners[\\s\\S]*$"));
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
            //WaitForAjaxElement(driver, By.LinkText("Glossary of Terms"), 30);
            driver.FindElement(By.ClassName("exit")).Click();
            Thread.Sleep(5000);

//END HR popupwindow sanityWindow .   
            
            
            
////////////////// Begin PreOwned General Link Verification
            
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
            driver.FindElement(By.LinkText("What is a Certified Pre-owned Vehicle?")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Toyota Certified Program[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.Navigate().Back();
            // Footer Area
            driver.Navigate().Back();
            driver.FindElement(By.CssSelector("a.AboutSetLink.modal-link > span")).Click();
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("ui-dialog-title-AboutSetModal")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [runScript | $(".ui-dialog-titlebar-close").click() | ]]
            driver.FindElement(By.LinkText("Privacy Policy")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectPopUp |  | ]]
            try
            {
                Assert.AreEqual("PrivacyPolicy-en.pdf (application/pdf Object)", driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            
            // ERROR: Caught exception [ERROR: Unsupported command [runScript | $(".ui-dialog-titlebar-close").click() | ]]
            driver.FindElement(By.LinkText("Toyota")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectPopUp |  | ]]
            try
            {
                Assert.AreEqual("Toyota Cars, Trucks, SUVs & Hybrids | Toyota Official Site", driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [selectPopUp |  | ]]
            Thread.Sleep(2000);
            // Footer link to Toyota National verified.  
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow |  | ]]
            driver.FindElement(By.LinkText("SET Finance")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectPopUp |  | ]]
            try
            {
                Assert.AreEqual("Southeast Toyota Finance - Home", driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow |  | ]]
            driver.FindElement(By.LinkText("Espanol")).Click();
            try
            {
                Assert.AreEqual("Southeast Toyota :: Pagina Inicial", driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(2000);
            driver.Navigate().Back();
            Thread.Sleep(2000);
            //driver.FindElement(By.LinkText("English")).Click();
            //might have to implement window switching  code right here...   
            
            //actually I do not thinkg the window switching code is necessary here.  Naviage back will suffice, as a new target
            //window is NOT opened. Commenting out all window handling code for mobile.   
            driver.FindElement(By.LinkText("Mobile")).Click();
            Thread.Sleep(5000);
            //calling the finder object to do its magic once again.  
            //parentWindow = driver.CurrentWindowHandle;  
            //newHandle = finder.Click(driver.FindElement(By.LinkText("Mobile")));
            //driver.SwitchTo().Window(newHandle);
            
            try
            {
                Assert.AreEqual("SET BAT DWS Mobile", driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Back(); 
            //driver.SwitchTo().Window(parentWindow);  
            //end mobile Area
            // End Testing of the General Functionality of Footer Links
            
            // GetConnected : Map & DealerLink.  Click to this dealerlink needs to be generic. xpath is id('getconnected')/x:div[3]/x:div/x:ul[1]/x:li[1]/x:a
            // Re-confirming Dealer Hoover Toyota  -- wait update I pickup LIMBAUGH now.  
            Thread.Sleep(5000);
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().Refresh();
            Thread.Sleep(10000);

            driver.FindElement(By.LinkText("CONFIRM ZIP")).Click();
            driver.FindElement(By.LinkText("Map & Directions")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Map[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Satellite[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [runScript | $(".ui-dialog-titlebar-close").click() | ]]

            Thread.Sleep(10000);
            //fail3/25/2013 --  Unable to locate element for 'close'.  This has worked before , therefore introducing 
            // thread sleep give time to locate the close button.  
            //fail 3/27 -- adding even more time before and after 15 secs 
            //fail 3/29 -- damn. fail again.. unable to locate. regardless of 15 second waits, this is a fragile close box.
            //intermittent failing..driver.FindElement(By.LinkText("close")).Click();
            //untested.  driver.FindElement(By.XPath("//a[contains(text(),'close')]")).Click();
            //Thread.Sleep(15000);
            //4/9 : Issues with locating Map close button. Intermittent failures witha try catch locator method which contained By.LinkText("close") and xpath (By.XPath("//a[contains(text(),'close')]").  Substituting simple Navigate.Back statement.
            
            driver.Navigate().Back();
            
            Thread.Sleep(10000);

            // Family Pages General Load 
            driver.FindElement(By.XPath("//img[@alt='Cars and Minivan']")).Click();
            // Warning: verifyTextPresent may require manual changes
            Thread.Sleep(5000);
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Toyota cars and minivan[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.Navigate().Back();

            driver.FindElement(By.XPath("//img[@alt='Trucks']")).Click();
            
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Toyota trucks[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.Navigate().Back();
            driver.FindElement(By.XPath("//img[@alt='Crossovers and SUVs']")).Click();
            
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Toyota crossovers and suvs[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            
            driver.Navigate().Back();
            driver.FindElement(By.XPath("//img[@alt='Hybrids']")).Click();
            
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Toyota hybrids[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Back();
            // Warning: verifyTextPresent may require manual changes
            driver.FindElement(By.XPath("//img[@alt='Scion']")).Click();
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Toyota scion[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            
            driver.Navigate().Back();
            // End FamilyPage General Load
            
            // Family Page Elements - Avalon
            driver.FindElement(By.XPath("//img[@alt='Cars and Minivan']")).Click();
            Thread.Sleep(5000);
            //Last on here.  May need to create a use case.  
            driver.FindElement(By.XPath("//a[@href='#AprOffer_Camry']")).Click();  
            //driver.FindElement(By.XPath("//a[contains(text(),'AprOffer_Camry')]")).Click();
            driver.FindElement(By.XPath("//a[@href='#LeaseOffer_Camry']")).Click();
            //driver.FindElement(By.XPath("//a[contains(text(),'LeaseOffer_Camry')]")).Click();

            try
            {
                driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div/div[2]/div[3]/div/a")).Click();
            }
            catch 
            {
                driver.FindElement(By.XPath("//a[@href='/camry']")).Click();
            }

            //failed 3/25/20136driver.FindElement(By.XPath("//a[@href='/camry']")).Click();
            
            
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*New Inventory[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(5000);
            driver.Navigate().Back();

            // Promotion Tools - Subject to change - TAM configurable.
            //Verify the text in all four
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*LEARN MORE ABOUT TOYOTA PARTS AND SERVICE[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*THE TOOLS YOU NEED TO GET THE CAR YOU WANT\\.[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*FIND YOUR NEW TOYOTA\\.[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*TOYOTA CERTIFIED USED VEHICLES\\.[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            //Selecting hyperlinks asscociated with the Promo pods.  
            //attemping to select A anchor wherein the href contains 'parts-and-service'
            // fail -- unable to locate.  driver.FindElement(By.XPath("//a[contains(text(),'parts-and-service')]")).Click();
            driver.FindElement(By.PartialLinkText("LEARN MORE ABOUT TOYOTA PARTS")).Click();
            // Warning: verifyTextPresent may require manual changes
            
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Tires[\\s\\S]*$"));
            }
            catch (AssertionException e) 
            {
                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Back();  
            //attemping to select A anchor wherein the href contains 'parts-and-service'
            //fail---driver.FindElement(By.XPath("//a[contains(text(),'helpful-resources')]")).Click();
            driver.FindElement(By.PartialLinkText("THE TOOLS YOU NEED")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Helpful Resources[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.Navigate().Back();
            //attemping to select A anchor wherein the href contains 'parts-and-service'
            //fail -- driver.FindElement(By.XPath("//a[contains(text(),'find-vehicle-for-budget')]")).Click();
            driver.FindElement(By.PartialLinkText("FIND YOUR NEW TOYOTA")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Find the Right Toyota[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.Navigate().Back();
            //attemping to select A anchor wherein the href contains 'parts-and-service'
            //fail --- driver.FindElement(By.XPath("//a[contains(text(),'used-and-preowned')]")).Click();
            driver.FindElement(By.PartialLinkText("TOYOTA CERTIFIED USED")).Click();
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Preowned[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
           
            driver.Navigate().Back();
            Thread.Sleep(5000);
            // End Promotion Tools
            
        
            
            
            
            
            
            
            // Inventory Page. Tacoma. 
            
            //driver.FindElement(By.LinkText("tacoma")).Click();
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/tacoma");
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*New Inventory[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // Compare Functionality
            // Change View Link
            driver.FindElement(By.CssSelector("button.inventory-view.compact")).Click();
            driver.FindElement(By.CssSelector("button.inventory-view.full")).Click();
            // inventory Pagination controls. Using Tacoma, Hoover Toyota.  
            Thread.Sleep(10000);

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
    //LAST ON -- Same WebDriverException
            // timeout
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
                //Unexpected error- unable to connect to the remote server.  See OneNote on this error 
                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            driver.Close();
            // //END COMPARISON Funtionality 
            // END B.   

            //C. -- begins at Toyo Tacoma 'Explore' Options.  
            
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
