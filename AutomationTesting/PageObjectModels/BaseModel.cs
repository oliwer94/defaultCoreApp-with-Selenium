using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.Extensions;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace AutomationTesting.PageObjectModels
{
    public class BaseModel
    {
        protected IWebDriver Driver { get; }
        protected string PagePath;
        protected string WindowHandler;

        protected BaseModel(IWebDriver driver)
        {
            Driver = driver;
            WindowHandler = Driver.CurrentWindowHandle;
        }

        public string Title => Driver.Title;

        public string Url => Driver.Url;

        public IWebElement FindById(By locator)
        {
            return Driver.FindElement(locator);
        }

        public IReadOnlyCollection<IWebElement> FindMultiple(By locator)
        {
            return Driver.FindElements(locator);
        }

        public void Clear(By locator)
        {
            FindById(locator).Clear();
        }

        /// <summary>
        /// This was a Close to official solution for
        /// SendInput sometimes not entering values, skipping
        /// inputs. 
        /// !! Use SendInput instead of this. 
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="input"></param>
        public void SendKeys(By locator, string input)
        {
            while (true)
            {
                Clear(locator);
                FindById(locator).SendKeys(input);

                if (FindById(locator).GetAttribute("value") != input)
                {
                    continue;
                }

                break;
            }
        }

        public string GetValueOf(IWebElement element)
        {
            return element.GetAttribute("value");
        }

        protected void SendInput(IWebElement element, string text)
        {
            Driver.ExecuteJavaScript(string.Format("document.getElementById('{0}').value='{1}';", element.GetAttribute("id"), text));
        }

        protected void Click(By locator)
        {
            FindById(locator).Click();
        }

        public void NavigateTo()
        {
            var root = new Uri(Driver.Url).GetLeftPart(UriPartial.Authority);
            var url = $"{root}/{PagePath}";
            Driver.Navigate().GoToUrl(url);
        }

        public void SwitchBackToDefaultWindow()
        {
            Driver.SwitchTo().Window(WindowHandler);
        }

        public void SwitchToPopupWindow()
        {
            foreach (var winHandle in Driver.WindowHandles)
            {
                if (winHandle == WindowHandler) continue;

                Driver.SwitchTo().Window(winHandle);
                break;
            }
        }

        public bool? Displayed(By locator)
        {
            return FindById(locator).Displayed;
        }

        public string GetText(By locator)
        {
            return FindById(locator).Text;
        }

        protected void MaximizeWindow()
        {
            Driver.Manage().Window.Maximize();
        }

        #region waits

        /// <summary>
        /// The amount of time the driver should wait when searching for an element if not immediately present.
        /// </summary>
        protected void ImplicitWait(int seconds)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }
        protected void PageLoadWait(int seconds)
        {
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(seconds);
        }

        private IWebElement FluentWaitForWebElement(int seconds, Func<IWebDriver, IWebElement> conditionToMeet)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(conditionToMeet);
        }

        public void WaitForElementToBeVisibleByLocator(By locator, int seconds)
        {
            try
            {
                var item = FluentWaitForWebElement(seconds,
                    ExpectedConditions.ElementIsVisible(locator));
            }
            catch (Exception)
            {
                //ignore timeout
            }
        }

        public void WaitForElementToBeVisible(IWebElement element, int seconds)
        {
            try
            {
                var item = FluentWaitForWebElement(seconds,
                    ExpectedConditions.ElementIsVisible(By.Id(element.GetAttribute("id"))));
            }
            catch (Exception)
            {
                //ignore timeout
            }
        }

        public void WaitForElementToExistById(string id, int seconds)
        {
            try
            {
                var item = FluentWaitForWebElement(seconds,
                    ExpectedConditions.ElementExists(By.Id(id)));
            }
            catch (Exception)
            {
                //ignore timeout
            }
        }

        public void WaitForElementToExistByWebElement(IWebElement element, int seconds)
        {
            try
            {
                var item = FluentWaitForWebElement(seconds,
                    ExpectedConditions.ElementExists(By.Id(element.GetAttribute("id"))));
            }
            catch (Exception)
            {
                //ignore timeout
            }
        }
        #endregion
    }
}