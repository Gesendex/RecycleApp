using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Recycle.Data.Repositories;
using Recycle.Interfaces.Repositories;
using Recycle.Interfaces.Services;
using Recycle.Models;
using RecycleApi.Authorization;
using RecycleApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<ITypeOfGarbageRepository, TypeOfGarbageDbRepository>();
            services.AddTransient<ICommentRepository, CommentDbRepository>();
            services.AddTransient<ICompanyRepository, CompanyDbRepository>();
            services.AddTransient<IRoleRepository, RoleDbRepository>();

        }

        private void AddJWTAuthorization(IServiceCollection services)
        {
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
        }

        private void AddServices(IServiceCollection services)
        {
            services.AddTransient<ITimeProviderService, TimeProviderService>();
            services.AddTransient<ITypeOfGarbageService, TypeOfGarbageService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<ICompanyService, CompanyService>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddJWTAuthorization(services);

            services.AddControllers();
            services.AddDbContext<RecycleContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            AddRepositories(services);
            AddServices(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RecycleApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RecycleApi v1"));
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
