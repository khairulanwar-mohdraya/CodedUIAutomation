using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumCommand.Configuration;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCommand.Command
{
    public class Command : ICommand
    {
        private IWebDriver _driver;
        private IConfig _config;
        private string _baseUrl;

        public IWebDriver Driver()
        {
            return _driver;
        }

        public Command()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("test-type");
            options.AddArgument("--disable-web-security");
            options.AddArgument("--ignore-certificate-errors");
            _config = new Config();
            _driver = new ChromeDriver(_config.ChromeDriverPath(), options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            _driver.Manage().Window.Maximize();

            _baseUrl = _config.TestUrl();
        }

        public void ClickByID(string elementID)
        {
            _driver.FindElement(By.Id(elementID)).Click();
        }

        public void ClickByXPath(string xPath)
        {
            _driver.FindElement(By.XPath(xPath)).Click();
        }

        public void ClickByName(string name)
        {
            _driver.FindElement(By.Name(name)).Click();
        }

        public void FillByID(string elementID, string value)
        {
            _driver.FindElement(By.Id(elementID)).SendKeys(value);
        }

        public void FillByName(string elementName, string value)
        {
            _driver.FindElement(By.Name(elementName)).SendKeys(value);
        }

        public void Navigate(string pageName)
        {
            _driver.Navigate().GoToUrl($"{_baseUrl}/{pageName}");
        }

        public string GetTextByID(string elementID)
        {
            return _driver.FindElement(By.Id(elementID)).Text;
        }

        public string GetTextByXPath(string xPath)
        {
            return _driver.FindElement(By.XPath(xPath)).Text;
        }

        public string GetTextInFrame(By frame, By element)
        {
            IWebElement iframe = _driver.FindElement(frame);
            _driver.SwitchTo().Frame(iframe);
            WaitElementAppear(element, 120);
            string text = _driver.FindElement(element).Text;
            _driver.SwitchTo().Window(_driver.CurrentWindowHandle);
            return text;
        }

        public void SelectDropDownListTextByID(string elementID, string text)
        {
            SelectElement selectElement = new SelectElement(_driver.FindElement(By.Id(elementID)));
            selectElement.SelectByText(text);
        }

        public void SelectDropDownListValueByName(string elementName, string value)
        {
            SelectElement selectElement = new SelectElement(_driver.FindElement(By.Name(elementName)));
            selectElement.SelectByValue(value);
        }

		public void SelectDropDownListValueByID(string elementID, string value)
		{
			SelectElement selectElement = new SelectElement(_driver.FindElement(By.Id(elementID)));
			selectElement.SelectByValue(value);
		}

		public void FrameClickElement(By frame, By element)
        {
            IWebElement iframe = _driver.FindElement(frame);
            _driver.SwitchTo().Frame(iframe);
            _driver.FindElement(element).Click();
            _driver.SwitchTo().Window(_driver.CurrentWindowHandle);
        }

        public void DoubleFrameClickByID(string frameID1, string frameID2, string elementID)
        {
            IWebElement frame = _driver.FindElement(By.Name(frameID1));
            _driver.SwitchTo().Frame(frame);
            IWebElement frame2 = _driver.FindElement(By.Id(frameID2));
            _driver.SwitchTo().Frame(frame2);
            _driver.FindElement(By.Id(elementID)).Click();
            _driver.SwitchTo().Window(_driver.CurrentWindowHandle);
        }

        public void WaitPageLoad(int seconds)
        {
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(seconds);
        }

        public void WaitElementDisappear(By by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        public void WaitElementAppear(By by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
        }

        public void SwitchWindow(int windowIndex)
        {
            var window = _driver.WindowHandles;
            _driver.SwitchTo().Window(window[windowIndex].ToString());
        }

        public void Close()
        {
            _driver.Close();
        }

        public void Quit()
        {
            _driver.Quit();
        }
    }
}
