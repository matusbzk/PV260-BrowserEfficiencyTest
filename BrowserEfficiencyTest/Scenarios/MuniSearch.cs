using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace BrowserEfficiencyTest.Scenarios
{
    internal class MuniSearch : Scenario
    {
        public MuniSearch()
        {
            Name = "MuniSearch";
            DefaultDuration = 45;
        }

        public override void Run(RemoteWebDriver driver, string browser, CredentialManager credentialManager, ResponsivenessTimer timer)
        {
            driver.NavigateToUrl("https://www.muni.cz/");
            driver.Wait(5);

            ScenarioEventSourceProvider.EventLog.ScenarioActionStart("Search for 'PV260'");
            // Type "Game of Thrones Season 1" in the search box and hit enter
            driver.TypeIntoField(driver.FindElementById("search"), "PV260" + Keys.Enter);
            driver.Wait(5);
            ScenarioEventSourceProvider.EventLog.ScenarioActionStop("Search for 'PV260'");

            ScenarioEventSourceProvider.EventLog.ScenarioActionStart("Click on first result");
			// Click on first result
			driver.FindElementsByClassName("gs-title").First().Click();
			driver.WaitForPageLoad();
            driver.Wait(2);
            ScenarioEventSourceProvider.EventLog.ScenarioActionStop("Click on first result");

        }
    }
}