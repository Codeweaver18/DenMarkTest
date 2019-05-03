using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DenMarkTest.common.Utilities;
using DenMarkTest.core.Abstract;
using DenMarkTest.core.Services;
using DenMarkTest.DataAccessLayer.Dbcontexts;
using DenMarkTest.DataAccessLayer.Interfaces;
using DenMarkTest.DataAccessLayer.Repositories;
using DenMarkTest.web.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DenMarkTest.web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var cxn = Configuration["DbconnectionString"].ToString();//configuration string

            services.AddDbContext<DanishContext>(options =>
             options.UseSqlServer(cxn)
             .UseLazyLoadingProxies());

            services.AddDbContext<IdentityContext>(options =>
                       options.UseSqlServer(cxn));
            //setting identity server dbcontext
            
            services.AddTransient<ITestsRepository, TestsRepository>();
            services.AddTransient<ITestService, TestService>();//inject services in DI container
            services.AddScoped<TestUtilityClass>();
            services.AddMvc();
            services.AddAutoMapper();

            //configuring identity starts here
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });
            //

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Login";
                options.AccessDeniedPath = "/Identity/AccessDenied";
                options.SlidingExpiration = true;
            });
            //configuring identity ends here

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
