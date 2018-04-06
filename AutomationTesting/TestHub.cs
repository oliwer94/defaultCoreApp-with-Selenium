using AutomationTesting.Tests;
using Xunit.Abstractions;

namespace AutomationTesting
{
    public class TestHub : DriverSetup
    {
        protected readonly LandingPageTests LandingPageTests;
        protected readonly RegisterPageTests RegisterTests;

        protected TestHub(string browser,ITestOutputHelper output) : base(browser)
        {
            LandingPageTests = new LandingPageTests(Driver, output);
            RegisterTests = new RegisterPageTests(Driver, output);
        }
    }
}