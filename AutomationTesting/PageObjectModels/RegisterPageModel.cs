using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomationTesting.PageObjectModels
{
    public class RegisterPageModel : BaseModel
    {
        public IWebElement FirstNameField;
        public IWebElement LastNameField;
        public IWebElement RegisterEmailField;
        public IWebElement RegisterPasswordField;
        public IWebElement CreateButton;


        public RegisterPageModel(IWebDriver driver) : base(driver)
        {
            PagePath = "Home/Register";

            // The amount of time the driver should wait when searching for an element if not immediately present
            ImplicitWait(5);
            // The amount of time the driver wait 
            PageLoadWait(10);

            MaximizeWindow();
        }

        public void InitElements()
        {
            FirstNameField = FindById(By.Id("FirstName"));
            LastNameField = FindById(By.Id("LastName"));
            RegisterEmailField = FindById(By.Id("Email"));
            RegisterPasswordField = FindById(By.Id("Password"));
            CreateButton = FindById(By.Id("Create"));
        }

        public void EnterRegisterCredentials(string firstName, string lastName, string email, string password)
        {
            SendInput(FirstNameField, firstName);
            SendInput(LastNameField, lastName);
            SendInput(RegisterEmailField, email);
            SendInput(RegisterPasswordField, password);
        }

        public void Click_CreateAccountButton()
        {
            CreateButton.Click();
        }

        /// <summary>
        /// Returns true if there are any errors with the registration.
        /// Returns false when everything was successful.
        /// </summary>
        /// <returns></returns>
        public bool AnyRegistrationErrors()
        {
            var list = FindMultiple(By.ClassName("field-validation-error"));
            var otherList = FindMultiple(By.ClassName("validation-summary-errors"));
            return (list.Count > 0 || otherList.Count > 0);
        }

        /// <summary>
        /// Returns a list of validation errors
        /// </summary>
        /// <returns></returns>
        public List<string> GetValidationErrors()
        {
            var list = FindMultiple(By.ClassName("field-validation-error"));
            var otherList = FindMultiple(By.ClassName("validation-summary-errors"));

            var errorList = list.Select(row => row.Text).ToList();
            errorList.AddRange(otherList.Select(row => row.Text));

            return errorList;
        }
    }
}