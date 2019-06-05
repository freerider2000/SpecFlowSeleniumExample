using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using OpenQA.Selenium;
using SpecFlow.Autofac;
using TechTalk.SpecFlow;
using SpecFlowTemplate_dotnet_framework.Models;

namespace SpecFlowTemplate_dotnet_framework.Framework
{
	public static class TestDependencies
	{
		[ScenarioDependencies]
		public static ContainerBuilder CreateAutoFacContainerBuilder()
		{
			var builder = CreateContainerBuilder();

			builder.RegisterTypes(typeof(TestDependencies).Assembly.GetTypes().Where(TypesAreBindings).ToArray())
				.SingleInstance();

			return builder;
		}

		private static bool TypesAreBindings(Type type)
		{
			return Attribute.IsDefined(type, typeof(BindingAttribute));
		}

		private static ContainerBuilder CreateContainerBuilder()
		{
			var builder = new ContainerBuilder();

			var webPages = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsAssignableTo<WebPage>()).ToArray();

			builder.RegisterTypes(webPages).SingleInstance().OnActivated(SetWebDriverInstance);

			builder.Register(x => SeleniumWebDriverFactory.CreateWebDriver()).As<IWebDriver>().SingleInstance();

			return builder;
		}

		private static void SetWebDriverInstance(IActivatedEventArgs<object> args)
		{
			if (!(args.Instance is WebPage webPage)) return;

			webPage.WebDriver = args.Context.Resolve<IWebDriver>();
		}
	}
}
