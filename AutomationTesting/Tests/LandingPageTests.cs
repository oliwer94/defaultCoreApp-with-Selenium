using AutomationTesting.PageObjectModels;
using OpenQA.Selenium;
using Xunit;
using Xunit.Abstractions;

namespace AutomationTesting.Tests
{
    public class LandingPageTests
    {
        private readonly IWebDriver driver;
        private readonly LandingPageModel landingPage;

        // use output.WriteLine() instead of Console.WriteLine()
        private readonly ITestOutputHelper output;

        public LandingPageTests(IWebDriver driver, ITestOutputHelper output)
        {
            this.output = output;
            this.driver = driver;
            landingPage = new LandingPageModel(this.driver);
        }

        public void VerifyLandingPageTitle()
        {
            // Navigate to test page
            landingPage.NavigateTo();

            // Do something

            // Assert something
            Assert.Equal("Home Page - defaultCoreApp", landingPage.Title);
        }
    }
}