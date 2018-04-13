using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDA.YourStoreApp.WebPortal;
using JH.BuyShiny.Contracts;
using JH.BuyShiny.DataAccess;
using JH.BuyShiny.Database;
using JH.BuyShiny.WebApp.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JH.BuyShiny.WebApp
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
            services.AddMvc();

            // Setup MySQL connection
            services.AddDbContext<BuyShinyContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("BuyShinyContext")));

            // Put my password validation rules here
            // And unique+confirmed email address
            services.AddIdentity<BuyShinyUser, BuyShinyRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireDigit = true;

                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<BuyShinyContext>()
                .AddUserStore<BuyShinyUserStore>()
                .AddUserManager<BuyShinyUserManager>()
                .AddSignInManager<BuyShinySignInManager>()
                .AddUserValidator<BuyShinyUserValidator>()
                .AddDefaultTokenProviders();
                
            services.AddScoped<IPasswordHasher<BuyShinyUser>, BuyShinyPasswordHasher>();

            // Database repositories for getting access to EF Model
            services.AddScoped<IPostRepository, PostRepository>();

            //// This was added by me based on https://docs.microsoft.com/en-us/aspnet/identity/overview/extensibility/change-primary-key-for-users-in-aspnet-identity
            //var dataProtectionProvider = options.DataProtectionProvider;
            //if (dataProtectionProvider != null)
            //{
            //    manager.UserTokenProvider =
            //        new DataProtectorTokenProvider<YourStoreUser, int>(
            //                dataProtectionProvider.Create("ASP.NET Identity"));
            //}

            //services.AddScoped<IUserValidator<BuyShinyUser>, BuyShinyUserValidator>();
            //services.AddScoped<UserManager<BuyShinyUser>, BuyShinyUserManager>();
            //services.AddScoped<SignInManager<BuyShinyUser>, BuyShinySignInManager>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                    ReactHotModuleReplacement = true
                });
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

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
