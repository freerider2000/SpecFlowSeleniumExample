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
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;


namespace SpecFlowTemplate_dotnet_framework.Framework
{
	[Binding]
	public static class SeleniumWebDriverFactory
	{
		private static IWebDriver _webDriver;

		static SeleniumWebDriverFactory()
		{

		}

		public static IWebDriver CreateWebDriver()
		{
			switch (Environment.GetEnvironmentVariable("Test_Browser"))
			{
				case "Chrome":
					var chromeOptions = new ChromeOptions { };
					_webDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
						chromeOptions);
					return _webDriver;
				case "IE":
					_webDriver = new InternetExplorerDriver(new InternetExplorerOptions {IgnoreZoomLevel = true});
					return _webDriver;
				case "Firefox":
					_webDriver = new FirefoxDriver();
					return _webDriver;
				case "Edge":
					_webDriver = new EdgeDriver(AppConfig.EdgeDriverBinaryLocation);
					return _webDriver;
				case string browser: throw new NotSupportedException($"{browser} is not a supported browser");
				default: throw new NotSupportedException("not supported browser: <null>");
			}

		}

		[AfterScenario]
		public static void NukeTheWebDriver()
		{
			if (_webDriver == null) return;
			Thread.Sleep(500);
			_webDriver.Close();
			_webDriver.Quit();
			_webDriver.Dispose();
		}

		[AfterStep]
		public static void MakeScreenShotAfterStep()
		{
			var takeScreenshot = _webDriver as ITakesScreenshot;

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
