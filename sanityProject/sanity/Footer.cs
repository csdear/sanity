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
    
    public class Footer
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
        
       /* [TearDown]
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
        
        public void FooterMain()
        {
           
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.Navigate().GoToUrl("http://southeast.buyatoyota.com/#");
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().Refresh();  
            // Begin Footer Area
            //driver.Navigate().Back();
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
            driver.Navigate().Refresh();
            Thread.Sleep(20000);
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
