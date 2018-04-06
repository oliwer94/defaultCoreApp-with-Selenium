using Xunit;
using Xunit.Abstractions;

namespace AutomationTesting.Browsers
{
    public class EdgeTest : TestHub
    {
        public EdgeTest(ITestOutputHelper output) : base("edge", output)
        {
        }

        [Fact, Trait("Category", "Automation")]
        public void Edge_VerifyLandingPageTitle()
        {
            LandingPageTests.VerifyLandingPageTitle();
        }

        [Fact, Trait("Category", "Automation")]
        public void Edge_RegisterSuccessful()
        {
            RegisterTests.RegisterSuccessful();
        }

        [Fact, Trait("Category", "Automation")]
        public void Edge_RegisterFailed()
        {
            RegisterTests.RegisterFailed();
        }
    }
}