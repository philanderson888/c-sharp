using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using SeleniumSpecFlow.pages;


namespace SeleniumSpecFlow
{
    [Binding]
    public class BBCLoginSteps
    {
        private IWebDriver _driver;
        private BbcLoginPage _bbcLoginPage;

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _driver = new ChromeDriver();
            // full screen
            _driver.Manage().Window.Maximize();
            // download driver at 
            // http://chromedriver.storage.googleapis.com/index.html?path=72.0.3626.7/

            _bbcLoginPage = BbcLoginPage.NavigateTo(_driver);







        }
        
        [Given(@"I have entered a valid (.*)")]
        public void GivenIHaveEnteredAValidUsername(string username)
        {
            _bbcLoginPage.Username = username;
        }
        
        [Given(@"I have entered an invalid (.*)")]
        public void GivenIHaveEnteredAnInvalidPassword(string password)
        {
            _bbcLoginPage.Password = password;
        }
        
        [When(@"I press login")]
        public void WhenIPressLogin()
        {
            _bbcLoginPage.ClickSignin();
        }
        
        [Then(@"I should see the appropriate (.*)")]
        public void ThenIShouldSeeTheAppropriateError(string error)
        {
           

            System.Threading.Thread.Sleep(5000);

            Assert.AreEqual(error, _bbcLoginPage.ErrorText);

        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _driver.Dispose();
        }
    }
}
