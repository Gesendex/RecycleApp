using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Recycle.Data.Repositories;
using Recycle.Interfaces.Repositories;
using RecycleApi.Authorization;
using RecycleApi.Helpers;
using RecycleApi.Services;
using RecycleApi.Services.Interfaces;

namespace RecycleApi.Extentions
{
    internal static class ServiceCollectionExtention
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITimeProviderService, TimeProviderService>();
            services.AddTransient<ITypeOfGarbageService, TypeOfGarbageService>();
            services.AddTransient<IGarbageTypeSetService, GarbageTypeSetService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IGarbageCollectionPointService, GarbageCollectionPointService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ITypeOfGarbageRepository, TypeOfGarbageDbRepository>();
            services.AddTransient<ICommentRepository, CommentDbRepository>();
            services.AddTransient<ICompanyRepository, CompanyDbRepository>();
            services.AddTransient<IRoleRepository, RoleDbRepository>();
            services.AddTransient<IClientRepository, ClientDbRepository>();
            services.AddTransient<IGarbageTypeSetRepository, GarbageTypeSetDbRepository>();
            services.AddTransient<IGarbageCollectionPointRepository, GarbageCollectionPointDbRepository>();

            return services;
        }

        public static IServiceCollection AddJwtAuthorization(this IServiceCollection services)
        {
            services.AddTransient<AuthorizationHelper>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = AuthOptions.ISSUER,
                            ValidateAudience = true,
                            ValidAudience = AuthOptions.AUDIENCE,
                            ValidateLifetime = true,
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            ValidateIssuerSigningKey = true,
                        };
                    });
            

            return services;
        }
    }
}
