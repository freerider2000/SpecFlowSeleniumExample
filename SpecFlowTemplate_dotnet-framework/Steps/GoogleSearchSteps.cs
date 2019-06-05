using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using SpecFlowTemplate_dotnet_framework.Models;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace SpecFlowTemplate_dotnet_framework.Steps
{
	[Binding]
	internal sealed class GoogleSearchSteps
	{
	
		private readonly ScenarioContext context;

		private readonly GoogleSearchPage _googleSearchPage;

		public GoogleSearchSteps(ScenarioContext injectedContext, GoogleSearchPage googleSearchPage)
		{
			context = injectedContext;
			_googleSearchPage = googleSearchPage;
		}

		[Given(@"I am on the Google home page")]
		public void GivenIAmOnTheGoogleHomePage()
		{
			_googleSearchPage.Open();
			
		}

		[When(@"I search for (.*)")]
		public void WhenISearchForTesting(string topic)
		{
			_googleSearchPage.SearchInputWebElement().SendKeys(topic+Keys.Enter);
		}

		[Then(@"Each of the results should contain the (.*)")]
		public void ThenEachOfTheResultsShouldContainTheTesting(string topic)
		{
			
			_googleSearchPage.SearchResultsBlockWebElement().GetAttribute("textContent").Should().Contain(topic);
		}



	}
}
