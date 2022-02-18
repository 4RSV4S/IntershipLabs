using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace explicitWaitExample
{
    public class Test
    {
        private IWebDriver Driver;
        
        [OneTimeSetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
        }

        [Test]
        void Test1()
        {
            //some arrange

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(int.MaxValue));
            IWebElement someElement = Driver.FindElement(By.Id("someID"));
            string initialText = someElement.Text;

            wait.Until<bool>((d) =>
            {
                if (someElement.Text != initialText)
                {
                    return true;
                }
                return false;
            });

            //some assertions
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
