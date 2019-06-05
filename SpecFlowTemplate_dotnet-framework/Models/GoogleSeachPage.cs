using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SpecFlowTemplate_dotnet_framework.Models
{
	internal class GoogleSearchPage : WebPage
	{
		public IWebElement SearchInputWebElement()
		{
			return WebDriver.FindElement(By.Name("q"));
		}

		public IWebElement SearchButtonWebElement()
		{
			return WebDriver.FindElement(By.Name("btnK"));
		}

		public IWebElement SearchResultsBlockWebElement()
		{
			return WebDriver.FindElement(By.XPath("//div[contains(@class,'mod')]/div/span/span"));
		}

	}
}
