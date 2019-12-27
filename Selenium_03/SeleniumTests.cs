using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit;
using NUnit.Framework;
using System.Threading;

namespace Selenium_03
{


    class SeleniumTests
    {

        IWebDriver driver;

    


        [Test]
        public void Selenium_Run_BBC_Test()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.bbc.co.uk";
        }

        [TearDown]
        public void CleanUp()
        {
            Thread.Sleep(2000);
            driver.Close();
        }


    }
}
