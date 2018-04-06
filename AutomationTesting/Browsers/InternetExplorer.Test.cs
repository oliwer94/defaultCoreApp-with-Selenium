using Xunit;
using Xunit.Abstractions;

namespace AutomationTesting.Browsers
{
    public class InternetExplorer : TestHub
    {
        public InternetExplorer(ITestOutputHelper output) : base("ie", output)
        {
        }

        [Fact, Trait("Category", "Automation")]
        public void IE_VerifyLandingPageTitle()
        {
            LandingPageTests.VerifyLandingPageTitle();
        }

        [Fact, Trait("Category", "Automation")]
        public void IE_RegisterSuccessful()
        {
            RegisterTests.RegisterSuccessful();
        }

        [Fact, Trait("Category", "Automation")]
        public void IE_RegisterFailed()
        {
            RegisterTests.RegisterFailed();
        }
    }
}