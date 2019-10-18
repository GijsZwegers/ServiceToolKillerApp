using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using ServiceTool.DAL;
using ServiceTool.DAL.ApiContext;
using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Interface;
using ServiceTool.DAL.Repositorys;
using ServiceTool.DAL.SqlContext;
using System;

namespace ServiceTool.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        int CookieLifetimeInDays = 30;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAntiforgery(options => options.HeaderName = "XSRF-TOKEN")
            .AddMvc()
            .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            // INFO: MVC core needs this to implement cookie authentication. The session information will be now stored in a session Cookie
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.Cookie.SameSite = SameSiteMode.Lax;
                    options.Cookie.Name = "ServiceTool.AuthCookieAspNetCore";
                    options.LoginPath = "/User/Login";
                    options.LogoutPath = "/User/Logout";
                    //30 days timespan before cookie needs to be refreshed
                    options.Cookie.MaxAge = new TimeSpan(CookieLifetimeInDays, 0, 0, 0);
                });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddTransient(_ => new DatabaseConnection(Configuration.GetConnectionString("DefaultConnection")));
            //SqlContext
            services.AddScoped<ICaseContext, CaseSQLContext>();
            services.AddScoped<ICaseStatusContext, CaseStatusSQLContext>();
            services.AddScoped<IServiceUserContext, ServiceUserSQLContext>();
            services.AddScoped<IServiceUserContext, CustomerUserSQLContext>();
            //HttpClient
            //services.AddHttpClient<IServiceUserContext, UserApiContext>();
            services.AddHttpClient<IUserContext, UserApiContext>();
            services.AddHttpClient<IAdminUserContext, UserApiContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            // INFO: give me acces to the HttpContext.User property which holds current user identity information
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
