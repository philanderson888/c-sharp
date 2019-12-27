using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium
{
    [TestFixture()]
    public class SeleniumBBCLoginTest
    {
        [Test()]
        public void SeleniumWalkthrough()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                // full screen
                driver.Manage().Window.Maximize();
                // download driver at 
                // http://chromedriver.storage.googleapis.com/index.html?path=72.0.3626.7/

                driver.Navigate().GoToUrl("http://bbc.co.uk");

                IWebElement loginButton = driver.FindElement(By.Id("idcta-link"));
                loginButton.Click();

                IWebElement usernameField = driver.FindElement(By.Id("user-identifier-input"));
                usernameField.SendKeys("testing@gurney.com");
                IWebElement passwordField = driver.FindElement(By.Id("password-input"));
                passwordField.SendKeys("12345678");

                System.Threading.Thread.Sleep(5000);

                IWebElement submitButton = driver.FindElement(By.Id("submit-button"));
                submitButton.Click();
                IWebElement passwordError = driver.FindElement(By.Id("form-message-password"));

                System.Threading.Thread.Sleep(5000);

                Assert.AreEqual("Sorry, that password isn't valid. Please include a letter.",passwordError.Text);


            }
        }
    }
}
