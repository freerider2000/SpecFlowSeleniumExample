using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SpecFlowTemplate_dotnet_framework.Framework;

namespace SpecFlowTemplate_dotnet_framework.Models
{
	internal class GoogleSearchPage : WebPage
	{
		public IWebElement SearchInputWebElement()
		{
			return WebDriver.FindElement(By.Name("q"),10);
		}

		public IWebElement SearchButtonWebElement()
		{
			return WebDriver.FindElement(By.Name("btnK"),10);
		}

		public IWebElement SearchResultsBlockWebElement()
		{
			return WebDriver.FindElement(By.XPath("//div[contains(@class,'mod')]/div/span/span"),10);
		}

		public IWebElement NoOfSearchResultsReturnedWebElement()
		{
			return WebDriver.FindElement(By.Id("resultStats"),10);
		}

	}
}
