using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecycleApp.Models;
using RecycleApp.Pages;
using RecycleApp.RecycleApiService;
using RecycleApp.Services;
using RecycleApp.Settings;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows;
using Microsoft.Extensions.Options;

namespace RecycleApp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public IServiceProvider ServiceProvider { get; private set; }
		public IConfiguration Configuration { get; private set; }

		public static ClientDtoIn CurrentUser { get; set; }

		private void AppStartup(object sender ,StartupEventArgs e)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(basePath: Directory.GetCurrentDirectory())
				.AddJsonFile(
					path: "appsettings.json",
					optional: false,
					reloadOnChange: true
				);

			Configuration = builder.Build();

			var serviceCollection = new ServiceCollection();

			ConfigureServices(serviceCollection);

			ServiceProvider = serviceCollection.BuildServiceProvider(); 

			var authorizationWindow = ServiceProvider.GetRequiredService<AuthorizationWindow>();
			authorizationWindow.Show();
		}

		private void ConfigureServices(IServiceCollection services)
		{
			services.AddOptions<AppSettings>().Bind(Configuration.GetSection("AppSettings"));
			services.AddTransient<IRecycleClient, RecycleClient>(provider =>
			{
				var settings = provider.GetService<IOptions<AppSettings>>()?.Value;

				return new RecycleClient(
					baseUrl: settings.BaseUri,
					httpClient: new HttpClient(
					)
				);
			});
			services.AddTransient<IRecycleService, RecycleService>();
			services.AddTransient<AuthorizationPage>();
			services.AddSingleton<AuthorizationWindow>();
			services.AddSingleton<MainWindow>();
		}
	}
}