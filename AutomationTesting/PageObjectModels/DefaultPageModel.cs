using OpenQA.Selenium;

namespace AutomationTesting.PageObjectModels
{
    public class DefaultPageModel : BaseModel
    {
        public DefaultPageModel(IWebDriver driver) : base(driver)
        {
            PagePath = "";

            // The amount of time the driver should wait when searching for an element if not immediately present
            ImplicitWait(5);

            // The amount of time the driver wait 
            PageLoadWait(10);

            MaximizeWindow();
        }
    }
}