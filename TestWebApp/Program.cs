using Microsoft.EntityFrameworkCore;
using TestWebApp.DbConnect;
using TestWebApp.Middleware;
using TestWebApp.Repository.Classes;
using TestWebApp.Repository.Interfaces;

namespace TestWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            AddDbContext(builder);

            builder.Services.AddControllersWithViews();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment() && !app.Environment.IsStaging())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseLoggerMiddleware();
            
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        private static void AddDbContext(WebApplicationBuilder builder)
        {
            string connString = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<BlogContext>(options => options.UseSqlServer(connString), ServiceLifetime.Singleton);

            builder.Services.AddSingleton<IBlogRepository, BlogRepository>();
            builder.Services.AddSingleton<ILogRepository, LogRepository>();
        }
    }
}
