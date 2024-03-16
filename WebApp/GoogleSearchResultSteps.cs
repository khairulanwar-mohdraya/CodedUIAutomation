using WebApp.Base;
using TechTalk.SpecFlow;

namespace WebApp
{
    [Scope(Tag = "GoogleSearchResult")]
    [Binding]
    public class GoogleSearchResultSteps : BaseStepDefinition
    {
        [Given(@"I have entered a keyword in input field")]
        public void GivenIhaveEnteredAKeywordInInputField()
        {
            Page.FillByID("APjFqb", "Apple");
        }

        [When(@"I press search")]
        public void WhenIPressSearch()
        {
            Page.ClickByName("btnK");
        }

        [Then(@"the result should be display")]
        public void ThenTheResultShouldBeDisplay()
        {

        }
    }
}
