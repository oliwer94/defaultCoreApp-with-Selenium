using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace AutomationTesting
{
    public abstract class DriverSetup : IDisposable
    {
        private const string DefaultBaseUrl = "http://localhost:1753";
        //private const string defaultBaseUrl = "http://the-internet.herokuapp.com/";

        protected IWebDriver Driver;
        private readonly string browser;

        protected DriverSetup(string browser)
        {
            this.browser = browser;
            SetupTest();
        }

        private void SetupTest()
        {
            var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
            switch (browser)
            {
                case "firefox":
                    var fservice = FirefoxDriverService.CreateDefaultService(path);
                    Driver = new FirefoxDriver(fservice){Url = DefaultBaseUrl};
                    break;

                case "chrome":
                    var cservice = ChromeDriverService.CreateDefaultService(path);
                    Driver = new ChromeDriver(cservice){Url = DefaultBaseUrl};
                    break;

                case "ie":
                    var ieservice = InternetExplorerDriverService.CreateDefaultService(path);
                    Driver = new InternetExplorerDriver(ieservice){Url = DefaultBaseUrl};
                    break;
                case "edge":
                    var edgeservice = EdgeDriverService.CreateDefaultService(path);
                    Driver = new EdgeDriver(edgeservice){Url = DefaultBaseUrl};
                    break;
            }
        }
        public void Dispose()
        {
            try
            {
                Driver.Close();
                Driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}