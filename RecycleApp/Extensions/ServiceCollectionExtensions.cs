using Microsoft.Extensions.DependencyInjection;
using RecycleApp.Pages;

namespace RecycleApp.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddPages(this IServiceCollection services)
		{
			services.AddTransient<AuthorizationPage>();
			services.AddTransient<CommentsPage>();
			services.AddTransient<EmptyPage>();
			services.AddTransient<GarbageCollectionPointEditPage>();
			services.AddTransient<GarbageCollectionPointsPage>();
			services.AddTransient<GarbageTypeInfoPage>();
			services.AddTransient<OwnPointsPage>();
			services.AddTransient<GarbageTypeInfoPage>();
			services.AddTransient<RegistrationPage>();

			return services;
		}
	}
}