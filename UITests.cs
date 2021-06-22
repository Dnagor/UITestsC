using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitTests
{
    public class Tests
    {
        private IWebDriver driver;
        private readonly By signInButton = By.XPath("//a[text()=' Sign in ']");
        private readonly By emailInput = By.Id("email");
        private readonly By passwordInput = By.Id("password");
        private readonly By submitButton = By.XPath("//button[@type='submit']");
        private const string _login = "viyim18256@vvaa1.com";
        private const string _password = "Qwe!qwe1";
        private readonly By nameBtn = By.CssSelector(".name");
        private const string expected = "zoryana";

        [SetUp]
        public void Setup()
        {
       
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://ita-social-projects.github.io/GreenCityClient/#/");
            driver.Manage().Window.Maximize();

        }

        [Test]
        public void Test1()
        {
            var signIn = driver.FindElement(signInButton);
            signIn.Click();
            var login = driver.FindElement(emailInput);
            login.SendKeys(_login);
            var password = driver.FindElement(passwordInput);
            password.SendKeys(_password);
            var submit = driver.FindElement(submitButton);
            submit.Click();
            Thread.Sleep(2000);
            var actual = driver.FindElement(nameBtn).Text;
            Assert.AreEqual(expected, actual, "expected name is not the same as actual");
           
        }
        [TearDown]
        public void TeatDown()
        {
            driver.Quit();
        }
    }
}