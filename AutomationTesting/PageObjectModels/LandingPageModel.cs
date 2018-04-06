using System;
using OpenQA.Selenium;

namespace AutomationTesting.PageObjectModels
{
    public class LandingPageModel : BaseModel
    {
        public IWebElement RegisterButton;

        public LandingPageModel(IWebDriver driver) : base(driver)
        {
            PagePath = "";

            // The amount of time the driver should wait when searching for an element if not immediately present
            ImplicitWait(5);
            // The amount of time the driver wait 
            PageLoadWait(10);

            MaximizeWindow();
        }

        public void InitElements()
        {
            RegisterButton = FindById(By.Id("RegisterButton"));
        }

        public void Click_RegisterPopupButton()
        {
            RegisterButton.Click();
        }
    }
}