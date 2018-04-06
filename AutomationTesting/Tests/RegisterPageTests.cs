using OpenQA.Selenium;
using System;
using AutomationTesting.PageObjectModels;
using Xunit;
using Xunit.Abstractions;

namespace AutomationTesting.Tests
{
    public class RegisterPageTests
    {
        private readonly IWebDriver driver;
        private readonly LandingPageModel landingPage;

        // use output.WriteLine() instead of Console.WriteLine()
        private readonly ITestOutputHelper output;

        public RegisterPageTests(IWebDriver driver, ITestOutputHelper output)
        {
            this.output = output;
            this.driver = driver;
            landingPage = new LandingPageModel(this.driver);
        }

        public void RegisterSuccessful()
        {
            // Navigate to test page
            landingPage.NavigateTo();
            landingPage.InitElements();
            landingPage.Click_RegisterPopupButton();

            var registerPage = new RegisterPageModel(driver);
            registerPage.NavigateTo();
            registerPage.InitElements();

            // Do something
            registerPage.EnterRegisterCredentials("Fname", "Lname", "email@email.com", "Password12345#");
            registerPage.Click_CreateAccountButton();

            // Assert something
            Assert.Empty(registerPage.GetValidationErrors());
        }

        public void RegisterFailed()
        {
            // Navigate to test page
            landingPage.NavigateTo();
            landingPage.InitElements();
            landingPage.Click_RegisterPopupButton();

            var registerPage = new RegisterPageModel(driver);
            registerPage.NavigateTo();
            registerPage.InitElements();

            // Do something
            registerPage.EnterRegisterCredentials("Fname", "", "email@email.com", "Password12345");
            registerPage.Click_CreateAccountButton();

            // Assert something
            Assert.True(registerPage.AnyRegistrationErrors());
        }
    }
}