using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace SeleniumSpecFlow.pages
{
    class BbcLoginPage
    {
        private readonly IWebDriver _driver;
       // PageFactory Objects
        [FindsBy(How=How.Id,Using = "user-identifier-input")]
        private IWebElement _username;
        [FindsBy(How = How.Id, Using = "password-input")]
        private IWebElement _password;
        [FindsBy(How = How.Id, Using = "form-message-password")]
        private IWebElement _errortext;
        [FindsBy(How = How.Id, Using = "submit-button")]
        private IWebElement _submitbutton;

        private const string PageUri = @"http://www.bbc.co.uk/signin";

        public BbcLoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
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
                _username.SendKeys(value);
            }
        }

        public string Password
        {
            set
            {
                _password.SendKeys(value);
            }
        }

        public void ClickSignin()
        {
            _submitbutton.Click();
        }

        public string ErrorText =>
            _driver.FindElement(By.Id("form-message-password")).Text;



    }
}
