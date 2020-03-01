using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FlightManager.Data;
using FlightManager.Models;
using FlightManager.ViewModels;
using FlightManager.Data.Seeding;
using FlightManager.Common.Mappings;
using FlightManager.InputModels.Employee;
using FlightManager.Services.Interfaces;
using FlightManager.Services;
using FlightManager.Common;
using System.Collections.Generic;
using AutoMapper;
using FlightManager.Web.Infrastructure;

namespace FlightManager.Web
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services
               .AddIdentity<User, IdentityRole>(options =>
               {
                   options.Password.RequireDigit = false;
                   options.Password.RequireLowercase = false;
                   options.Password.RequireUppercase = false;
                   options.Password.RequireNonAlphanumeric = false;
                   options.Password.RequiredLength = 6;
                   options.SignIn.RequireConfirmedEmail = false;
               })
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            });

            services.PopulateGlobalConstnts(Configuration);

            services
                .AddTransient<IFlightService, FlightService>()
                .AddTransient<IReservationService, ReservationService>()
                .AddTransient<IEmailSender, EmailSender>(_ => EmailSenderFactory.Instance(Configuration));

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var profiles = new List<Profile>()
            {
                new MappingProfile()
            };

            AutoMapperConfig.RegisterMappings(
                profiles,
                typeof(ErrorViewModel).Assembly, 
                typeof(EmployeeCreateInputModel).Assembly);

            using (IServiceScope serviceScope = app.ApplicationServices.CreateScope())
            {
                ApplicationDbContext dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
