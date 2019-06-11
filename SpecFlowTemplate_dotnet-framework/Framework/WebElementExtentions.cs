using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowTemplate_dotnet_framework.Framework
{
	internal static class WebElementExtensions
	{

		public static IWebElement FindElement(this IWebDriver driver, By by, int timeoitInSeconds)
		{
			if (timeoitInSeconds > 0)
			{
				var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoitInSeconds));
				return wait.Until(drv => drv.FindElement(by));
			}

			return driver.FindElement(by);
		}

	}
}
