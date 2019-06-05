using System;
using System.Configuration;

namespace SpecFlowTemplate_dotnet_framework.Framework
{
	internal static class AppConfig
	{
		public static string ChromiumBinaryLocation =>
			ConfigurationManager.AppSettings.Get(name: nameof(ChromiumBinaryLocation));

	}
}
