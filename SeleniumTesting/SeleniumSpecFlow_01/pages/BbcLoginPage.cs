using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace SeleniumSpecFlow.pages
{
    class BbcLoginPage
    {
        private readonly IWebDriver _driver;
        private const string PageUri = @"http://www.bbc.co.uk/signin";

        public BbcLoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public static BbcLoginPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUri);
            return new BbcLoginPage(driver);
        }


        public string Username
        {
            set
            {
                _driver.FindElement(By.Id("user-identifier-input")).SendKeys(value);
            }
        }

        public string Password
        {
            set
            {
                _driver.FindElement(By.Id("password-input")).SendKeys(value);
            }
        }

        public void ClickSignin()
        {
            _driver.FindElement(By.Id("submit-button")).Click();
        }

        public string ErrorText =>
            _driver.FindElement(By.Id("form-message-password")).Text;



    }
}
