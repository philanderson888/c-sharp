//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_03_Core_MAC
{
    [TestFixture()]
    public class UnitTest1
    {
        
        [Test()]
        public void TestMethod5()
        {

          //  using (IWebDriver)

            Assert.AreEqual(2, 2);


        }

        [Test()]
        public void TestMethod4()
        {
            Assert.AreEqual(2, 2);


        }


        [Test()]
        public void ChromeTest(){
            using (IWebDriver driver = new ChromeDriver()){
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://www.bbc.co.uk");
                IWebElement loginButton = driver.FindElement(By.Id("data-link"));
                loginButton.Click();
                Assert.AreEqual(1, 1);
            }
        }


    }
}
