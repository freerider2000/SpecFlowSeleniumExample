using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using System.IO;
using System.Reflection;
using System.Threading;


namespace SpecFlowTemplate_dotnet_framework.Framework
{
	[Binding]
	public static class SeleniumWebDriverFactory
	{
		private static readonly IWebDriver WebDriver;

		static SeleniumWebDriverFactory()
		{
			var chromeOptions = new ChromeOptions { };
			WebDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
		}

		public static IWebDriver CreateWebDriver() => WebDriver;

		[AfterTestRun]
		public static void NukeTheWebDriver()
		{
			if (WebDriver == null) return;
			Thread.Sleep(500);
			WebDriver.Close();
			WebDriver.Quit();
			WebDriver.Dispose();
		}

		[AfterStep]
		public static void MakeScreenShotAfterStep()
		{
			var takeScreenshot = WebDriver as ITakesScreenshot;

			if (takeScreenshot != null && ScenarioContext.Current.TestError != null)
			{
				var screenshot = takeScreenshot.GetScreenshot();
				var tempFileName = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
					                   Path.GetFileNameWithoutExtension(Path.GetTempFileName())) + ".jpg";
				screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Jpeg);
				Console.Write($"SCREENSHOT[ file:///{tempFileName} ]SCREENSHOT");
			}
		}
	}
}
