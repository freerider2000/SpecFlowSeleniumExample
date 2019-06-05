using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowTemplate_dotnet_framework.Framework;

namespace SpecFlowTemplate_dotnet_framework.Models
{
	internal abstract class WebPage
	{
		public IWebDriver WebDriver;

		protected  string RelativeURL { get; set; }

		public void Open()
		{
			var url = $"{AppConfig.GoogleSearchUrl}";

			WebDriver.Navigate().GoToUrl(url);

		}
	}
}
