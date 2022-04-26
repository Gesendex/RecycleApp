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
using RecycleApp.Extensions;
using RecycleApp.Handlers;

namespace RecycleApp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private const string SettingsFileName = "appsettings.json";

		public static IServiceProvider ServiceProvider { get; private set; }
		public static IConfiguration Configuration { get; private set; }

		public static ClientDtoIn CurrentUser { get; set; }
		public static MainWindow AppMainWindow { get; set; }
		public static AuthorizationWindow AppAuthorizationWindow { get; set; }

		public static MainWindow GetNewWindow()
		{
			return ServiceProvider.GetRequiredService<MainWindow>();
		}

		private void AppStartup(object sender, StartupEventArgs e)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(basePath: Directory.GetCurrentDirectory())
				.AddJsonFile(
					path: SettingsFileName,
					optional: false,
					reloadOnChange: true
				);

			Configuration = builder.Build();

			var serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection);
			ServiceProvider = serviceCollection.BuildServiceProvider();

			AppMainWindow = ServiceProvider.GetRequiredService<MainWindow>();

			var authorizationWindow = ServiceProvider.GetRequiredService<AuthorizationWindow>();
			authorizationWindow.Show();
		}

		private void ConfigureServices(IServiceCollection services)
		{
			services.AddOptions<AppSettings>().Bind(Configuration.GetSection("AppSettings"));

			services.AddTransient<IRecycleClient, RecycleClient>(
				provider =>
				{
					var settings = provider.GetService<IOptions<AppSettings>>().Value;
					var recycleClientHandler = provider.GetRequiredService<IOptions<RecycleClientHandler>>().Value;
					var httpClient = new HttpClient(recycleClientHandler);

					return new RecycleClient(
						baseUrl: settings.BaseUri,
						httpClient: httpClient
					);
				}
			);

			services.AddTransient<IRecycleService, RecycleService>();

			services.AddPages();

			services.AddTransient<AuthorizationWindow>();
			services.AddTransient<MainWindow>();
		}
	}
}