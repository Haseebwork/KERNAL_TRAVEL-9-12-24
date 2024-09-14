using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Kernal_Travel_Guide.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Kernal_Travel_Guide
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<KernalTravelGuideContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Kernal_Travel_GuideContext") ?? throw new InvalidOperationException("Connection string 'Kernal_Travel_GuideContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
          op =>
          {
              op.LoginPath = "/Auth/Login";
              op.AccessDeniedPath = "/Auth/Login";
              op.ExpireTimeSpan = TimeSpan.FromMinutes(60);
          }
        );

            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}