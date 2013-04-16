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
            
            driver.FindElement(By.ClassName("btn")).Click();
            Thread.Sleep(10000);
            driver.FindElement(By.ClassName("tab-sms-link")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("span.ui-icon.ui-icon-closethick")).Click();
            // AAQ Form Window Loaded and Closed
            driver.FindElement(By.CssSelector("a.tab-offers-link > span")).Click();
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Featured Offers')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("a.tab-resources-link > span")).Click();

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Finance Tools')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            // Content Loaded Tabs View Offers and Helpful Resources Verified
            
            // Scion 1st Tier
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
            // Carousel Arrow Functions Verified.

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Scion')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            
            // [Scion] Carousel Tier 2 Load verified.  

            Thread.Sleep(10000);
                
            driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div/ul/li[7]/img")).Click();       
            //driver.FindElement(By.CssSelector("img[alt=\"2012 Scion xB\"]")).Click();
            // Warning: verifyTextPresent may require manual changes

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Scion')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            
            // 3rd Tier [2012 Scion XB] load verified.
            // ***Begin 3rd Tier Link Tests***  
            Thread.Sleep(10000);
            //Navigate directly to the 2nd tier.  
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/#family=Scion&series=2012+Scion+xB");
            Thread.Sleep(10000);
            //Select vehicle, which loads the 3rd tier.  
            driver.FindElement(By.XPath("//img[@alt='2013 Scion xB']")).Click();
            Thread.Sleep(10000);

            //Browse Models--->  
            Thread.Sleep(10000);

            driver.FindElement(By.XPath("//a[@href='/scion-xb#explore=models']")).Click();
            Thread.Sleep(10000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Models & Features')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }


            driver.Navigate().Back();  
            
            //Pick Your Color-->
            Thread.Sleep(10000);
            driver.FindElement(By.XPath("//a[@href='/scion-xb#explore=colors']")).Click();
            Thread.Sleep(5000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Colors')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Back();
            Thread.Sleep(10000);
            driver.FindElement(By.XPath("//a[@href='/scion-xb#explore=photos']")).Click();

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Gallery')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Back();
            Thread.Sleep(10000);

            //diasbled - unable to located. driver.FindElement(By.XPath("//a[@href='/scion-xb#explore=models&modal=feature-finder&selected-series=scion-xB']")).Click(); 
            //Using generic X path.  
            driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div[5]/div/div[3]/ul/li[4]/a")).Click();

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Accessories ')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Back();
            Thread.Sleep(10000);

            driver.FindElement(By.XPath("//a[@href='/scion-xb/offers']")).Click();
            //works --driver.FindElement(By.XPath("//a[contains(text(),'View Offers')]")).Click();
            Thread.Sleep(5000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'2012 Offers')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            driver.Navigate().Back();
            Thread.Sleep(5000);

            driver.FindElement(By.XPath("//a[@href='/scion-xb#explore=accessories&modal=accessory-catalog&series=scion-xb']")).Click();
            //works -- driver.FindElement(By.XPath("//a[contains(text(),'See Options')]")).Click();

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Accessories')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            // ***End 3rd Tier Link Tests***
            // ***Begin Navigation Back Carousel. 3rd tier to 2nd Tier***
            driver.Navigate().Back();
            Thread.Sleep(5000);
            

            driver.FindElement(By.CssSelector("a.families-back-link")).Click();
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'The Family Lineup')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            // ***End Carousel Testing  ***  
            
            // ***Begin View/Featured Offers Tab***
            driver.FindElement(By.CssSelector("a.tab-offers-link > span")).Click();

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Featured Offers')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.LinkText("Next")).Click();
            Thread.Sleep(10000);
            driver.FindElement(By.LinkText("Prev")).Click();
            Thread.Sleep(10000);
            driver.FindElement(By.LinkText("Details")).Click();
                
            Thread.Sleep(10000);
            driver.Navigate().Back();  
            Thread.Sleep(10000);  

            
            driver.FindElement(By.LinkText("Find One")).Click();
            Thread.Sleep(20000);

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'New Inventory')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Back();
            
            //End View/Featured Offers

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
            driver.Navigate().Back();
            //End Helpful Resources Section
            
            // Begin Footer Area
            driver.Navigate().Back();
            Thread.Sleep(10000);
            driver.FindElement(By.CssSelector("a.AboutSetLink.modal-link > span")).Click();
            
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("ui-dialog-title-AboutSetModal")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            
            driver.FindElement(By.LinkText("Privacy Policy")).Click();
            
            try
            {
                Assert.AreEqual("PrivacyPolicy-en.pdf (application/pdf Object)", driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            
            driver.FindElement(By.LinkText("Toyota")).Click();
            
            try
            {
                Assert.AreEqual("Toyota Cars, Trucks, SUVs & Hybrids | Toyota Official Site", driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            
            Thread.Sleep(2000);
             
            
            driver.FindElement(By.LinkText("SET Finance")).Click();
            
            try
            {
                Assert.AreEqual("Southeast Toyota Finance - Home", driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            
            Thread.Sleep(2000);
            
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
            driver.FindElement(By.LinkText("Mobile")).Click();
            Thread.Sleep(5000);
            
            try
            {
                Assert.AreEqual("SET BAT DWS Mobile", driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Back(); 
            //End Footer Section 

            // GetConnected : Map & DealerLink.    
            Thread.Sleep(5000);
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().Refresh();
            Thread.Sleep(10000);

            driver.FindElement(By.LinkText("CONFIRM ZIP")).Click();
            Thread.Sleep(20000); 
            driver.FindElement(By.LinkText("Map & Directions")).Click();
            Thread.Sleep(10000);
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Map')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }


            Thread.Sleep(10000);
            
            driver.Navigate().Back();
            
            Thread.Sleep(10000);
            //End Map 

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
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'LEARN MORE ABOUT TOYOTA PARTS AND SERVICE')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'THE TOOLS YOU NEED TO GET THE CAR YOU WANT')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'FIND YOUR NEW TOYOTA')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'TOYOTA CERTIFIED USED VEHICLES')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

           
            //Selecting hyperlinks asscociated with the Promo pods.  
            driver.FindElement(By.PartialLinkText("LEARN MORE ABOUT TOYOTA PARTS")).Click();

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Tires')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Back();  
            driver.FindElement(By.PartialLinkText("THE TOOLS YOU NEED")).Click();
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Helpful Resources')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Back();
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
   
            // Inventory Page. Tacoma. 
            
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/tacoma");

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
            Thread.Sleep(15000);
            driver.FindElement(By.ClassName("exit")).Click();
            Thread.Sleep(5000);

            // Narrow Inventory Tab - General Areas. Selections have to be made to enable Colors, Packages tabs etc..  Selection is SPECIFIC (TACOMA) 
            
            driver.FindElement(By.CssSelector("a.narrow-search-link > span")).Click();
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Year')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }


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

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Exterior')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

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
            Thread.Sleep(3000);

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
            
            try
            {

                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Click on accessory name for details')]"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("All Available Accessories")).Click();
            
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

            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("VehicleImageContainer")));

            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

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
            
            //End Details Page - Monroney 
   
            //Viewed Vehicles 
            driver.Navigate().Refresh();
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
            Thread.Sleep(10000);
            //2. Select two Vehicles to compare.  The checkbox or the Compare button in the row will suffice.  

            driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div/div[3]/div/div[3]/div/div/div[4]/div[2]/label/span")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/div/div/div/div/div[3]/div/div[4]/div/div/div[4]/div[2]/label/span")).Click();
            Thread.Sleep(10000);
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
            

            //End COMPARISON Funtionality 
            //End Inventory 

            //Begin Explore Area
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
           
            driver.FindElement(By.CssSelector("a.modal-link > span")).Click();
           
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Compare Models + Features')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            
            driver.FindElement(By.CssSelector("em")).Click();
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Feature Finder')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            
            driver.Navigate().Refresh();
            Thread.Sleep(5000);
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/tacoma#tab=compare&explore=colors");
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Colors')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Feature Finder')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(10000);
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Feature Finder')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/tacoma#tab=compare&explore=accessories");
            Thread.Sleep(5000);

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Accessories')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Accessories Catalog')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[@href='#']")).Click();
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Accessories Catalog')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/tacoma#explore=photos");
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Gallery')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Gallery - click thumbnail for larger image or to play movie.')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.CssSelector("div.media-gallery > ul.actions > li.accessories-catalog > a")).Click();
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Accessory Catalog')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            driver.Navigate().Back();

            //END EXPLORE AREA


            // Offers Area - Vehicle Specific - In this instance, CAMRY  

            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/tacoma/offers");
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'2013 Offers')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);

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
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'4Runner')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Camry')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Highlander')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Matrix')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'RAV4')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'SCION SERVICE BOOST PROGRAM')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

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
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Featured Offers')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Vehicle')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Lease')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'APR')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Programs')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Toyota Care - Complimentary Maintenance Program')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            //END OFFERS AREA

            // BEGIN BUILD - BYO  - CAMRY  
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/camry/build");
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'SELECT A GRADE')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Select A Model')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(5000);
            
            driver.FindElement(By.LinkText("Next")).Click();

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Exterior:')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Interior:')]"));

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
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Click on a package name for details')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            
            driver.FindElement(By.LinkText("Prev")).Click();
            driver.FindElement(By.LinkText("Next")).Click();
            driver.FindElement(By.LinkText("Next")).Click();
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Click on accessory name for details')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Wheels')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Technology')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Options')]"));

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
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Required Field')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Preferred Method Of Contact')]"));

            }

            catch (AssertionException e)
            {

                verificationErrors.Append(e.Message);
            }
            
            try
            {
                IWebElement el = driver.FindElement(By.XPath("//*[contains(.,'Submit')]"));

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
            //END BYO 

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
