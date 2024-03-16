using TechTalk.SpecFlow;
using SeleniumCommand.Command;

namespace WebApp.Base
{
    public class BaseStepDefinition
    {
        public ICommand Page;

        public BaseStepDefinition()
        {
            Page = new Command();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Page.Navigate(@"");
            Page.WaitPageLoad(60);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Page.Close();
        }
    }
}
