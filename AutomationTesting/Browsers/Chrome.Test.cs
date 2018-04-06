using Xunit;
using Xunit.Abstractions;

namespace AutomationTesting.Browsers
{
    public class ChromeTest : TestHub
    {
        public ChromeTest(ITestOutputHelper output) : base("chrome", output)
        {
        }

        [Fact, Trait("Category", "Automation")]
        public void Chrome_VerifyLandingPageTitle()
        {
            LandingPageTests.VerifyLandingPageTitle();
        }

        [Fact, Trait("Category", "Automation")]
        public void Chrome_RegisterSuccessful()
        {
            RegisterTests.RegisterSuccessful();
        }

        [Fact, Trait("Category", "Automation")]
        public void Chrome_RegisterFailed()
        {
            RegisterTests.RegisterFailed();
        }
    }
}