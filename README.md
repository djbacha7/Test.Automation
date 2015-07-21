# Test.Automation
Framework to automate tests using Selenium WebDriver

Test Framework was designed in Objectivity to propose common way how people should create Selenium WebDriver tests:

It provides following features:
- Possibility to Use MSTest or NUnit framework
- Specflow ready
- Written entirely in C#
- Contains example projects how to use it
- Allows to use Chrome, Firefox or Internet Explorer
- Extends Webdriver by additional methods like JavaScriptClick, WaitForAjax, WaitUntilElementIsNoLongerFound, etc.
- Automatically waits when locating element for specified time and conditions
- Page Object Pattern
- More common locators, e.g: "//*[@title='{0}' and @ms.title='{1}']"
- Several methods to interact with kendo controls
- Verify along with Assert
- Measures average and 90 Percentile action times
- DataDriven for NUnit and MSTest with examples 

To create new project using Test Framework simply copy and change  one of example  project:
- Objectivity.Test.Automation.Features for Specflow
- Objectivity.Test.Automation.MsTests for MSTest
- Objectivity.Test.Automation.NunitTests for NUnit

In case of problems with running tests in your internet browser remember to update version of Selenium WebDriver from Nuget packages.
To run NUnit tests from Visual Studio remember to install NUnit TestAdapter.


NUnit Example Test:

        [Test]
        public void SendKeysAndClickTest()
        {
                var loginPage = Pages.Create<HomePage>()
                        .OpenHomePage();

                var searchResultsPage = loginPage.Search("objectivity");
                searchResultsPage.MarkStackOverFlowFilter();

                Assert.IsTrue(searchResultsPage.IsAtPage("Search Results"), "Search results page is not displayed");
        }


NUnit Example Page Object:

        public class SearchResultsPage : ProjectPageBase
        {
                /// <summary>
                /// Locators for elements
                /// </summary>
                private readonly ElementLocator stackOverFlowCheckbox = new ElementLocator(Locator.Id, "500");

                /// <summary>
                /// Marks the stack over flow filter.
                /// </summary>
                public SearchResultsPage MarkStackOverFlowFilter()
                {
                        var checkbox = this.Browser.GetElement<Checkbox>(this.stackOverFlowCheckbox);
                        checkbox.TickCheckbox();
                        return this;
                }
        }

To select internet browser for tests to be carried out edit App.config file at previously selected sample project:
    <!--<add key="browser" value="Chrome" />-->
    <!--<add key="browser" value="InternetExplorer" />-->
	<add key="browser" value="Firefox" />
    <add key="waitingTime" value="20" />
    <add key="ajaxWaitingTime" value="10" />
 

