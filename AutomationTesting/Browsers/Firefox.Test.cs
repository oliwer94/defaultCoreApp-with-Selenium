using Xunit;
using Xunit.Abstractions;

namespace AutomationTesting.Browsers
{
    public class FirefoxTest : TestHub
    {
        public FirefoxTest(ITestOutputHelper output) : base("firefox", output)
        {
        }

        [Fact, Trait("Category", "Automation")]
        public void Firefox_VerifyLandingPageTitle()
        {
            LandingPageTests.VerifyLandingPageTitle();
        }

        [Fact, Trait("Category", "Automation")]
        public void Firefox_RegisterSuccessful()
        {
            RegisterTests.RegisterSuccessful();
        }

        [Fact, Trait("Category", "Automation")]
        public void Firefox_RegisterFailed()
        {
            RegisterTests.RegisterFailed();
        }
    }
}