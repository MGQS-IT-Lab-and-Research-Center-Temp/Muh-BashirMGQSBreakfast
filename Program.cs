using System;
using System.Buffers;
using System.Collections.Immutable;
using MGQSBreakfast.Contracts.Repositories;
using MGQSBreakfast.Contracts.Services;
using MGQSBreakfast.Implementations.Service;
using MGQSBreakfast.Implementation.Repository;
using Microsoft.EntityFrameworkCore;
using MGQSBreakfast.Context;

namespace MGQSBreakfast
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IBreakfastRepository, BreakfastRepository>();
            builder.Services.AddScoped<IBreakfastService, BreaskfastService>();

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("ApplicationDbContext")));

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

        }
    }
}
