using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using DataAccess;
namespace MediaBazaarWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddTransient<IEmployeeDB, EmployeeDB>();
            builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddTransient<IShiftDB, ShiftDB>();
            builder.Services.AddTransient<IShiftRepository , ShiftRepository>();
            builder.Services.AddTransient<IAvailabilityDB, AvailabilityDB>();
            builder.Services.AddTransient<IAvailabilityRepository, AvailabilityRepository>();
            builder.Services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.SetMinimumLevel(LogLevel.Information);
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Index");
                    options.AccessDeniedPath = new PathString("/AccessDenied");
                    options.LogoutPath = new PathString("/Logout");
                });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.MapRazorPages();

            app.Run();
        }
    }
}