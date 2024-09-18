using DengueLearn.Data;
using DengueLearn.Repository;
using DengueLearn.Repository.Interfaces;
using DengueLearn.Services;
using DengueLearn.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DengueLearn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<DengueLearnDbContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"));
                });

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Services.AddScoped<IService, Service>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddSession(x =>
            {
                x.Cookie.HttpOnly = true;
                x.Cookie.IsEssential = true;
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

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}