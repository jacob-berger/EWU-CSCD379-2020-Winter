using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics.CodeAnalysis;

namespace SecretSanta.Web.Tests
{
    [TestClass]
    public class GiftTests
    {
        [NotNull]
        public TestContext? TestContext { get; set; }

        [NotNull]
        private IWebDriver? Driver { get; set; }

        string AppURL { get; } = "https://localhost:44394/";

        [TestInitialize]
        public void TestInitialize()
        {

            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    Driver = new ChromeDriver();
                    break;
                default:
                    Driver = new ChromeDriver();
                    break;
            }
            Driver.Manage().Timeouts().ImplicitWait = new System.TimeSpan(0, 0, 10);

        }

        [TestMethod]
        public void VerifySecretSantaPage_Success()
        {
            Driver.Navigate().GoToUrl(new Uri(AppURL));
            IWebElement element = Driver.FindElement(By.CssSelector("body > section > div > p"));
            Assert.IsNotNull(element);
        }

        [TestMethod]
        public void VerifyUserExistsFromApi_Success()
        {
            Driver.Navigate().GoToUrl(new Uri(AppURL + "Users"));
            IWebElement element = Driver.FindElement(By.CssSelector("body > section > div > div > button"));
            Assert.IsNotNull(element);
        }

        [TestMethod]
        public void AddGiftViaSelenium_Success()
        {
            string title = "Nintendo Switch";
            string description = "Handheld gaming console";
            string url = "https://nintendo.com";
            Driver.Navigate().GoToUrl(new Uri(AppURL + "Gifts"));
            Driver.FindElement(By.CssSelector("body > section > div > div > button")).Click();
            Driver.FindElement(By.CssSelector("body > section > div > div > div > div.modal-content > div:nth-child(1) > div > input")).SendKeys(title);
            Driver.FindElement(By.CssSelector("body > section > div > div > div > div.modal-content > div:nth-child(2) > div > input")).SendKeys(description);
            Driver.FindElement(By.CssSelector("body > section > div > div > div > div.modal-content > div:nth-child(3) > div > input")).SendKeys(url);
            Driver.FindElement(By.Id("submit")).Click();

            Assert.AreEqual(title, Driver.FindElement(By.Id("gift-title")).Text);
            Assert.AreEqual(description, Driver.FindElement(By.Id("gift-description")).Text);
            Assert.AreEqual(url, Driver.FindElement(By.Id("gift-url")).Text);
        }

        //public void EnterBingSearchText(string text)
        //{
        //    Driver.Navigate().GoToUrl(new Uri(AppURL + "/"));
        //    IWebElement element = Driver.FindElement(By.Id("sb_form_q"));
        //    element.SendKeys(text);
        //    Assert.AreEqual<string>(text, element.GetProperty("value"));
        //}

        //[TestMethod]
        //public void BingSearch_UsingXPath_Success()
        //{
        //    string searchString = "Inigo Montoya";
        //    EnterBingSearchText(searchString);
        //    Driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/form/label")).Click();
        //    Assert.IsTrue(Driver.Title.Contains(searchString), "Verified title of the page");
        //}

        //[TestMethod]
        //public void BingSearch_UsingCSSSelector_Success()
        //{
        //    string searchString = "Inigo Montoya";
        //    EnterBingSearchText(searchString);
        //    Driver.FindElement(By.CssSelector("label[for='sb_form_go']")).Click();
        //    Assert.IsTrue(Driver.Title.Contains(searchString), "Verified title of the page");
        //}

        [TestCleanup()]
        public void TestCleanup()
        {
            Driver.Quit();
        }
    }
}
