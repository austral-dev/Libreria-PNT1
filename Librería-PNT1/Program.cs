using Libreria_PNT1.Data;
using Libreria_PNT1.Repositories;
using Libreria_PNT1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // -------------------------
        // Repositorios (inyección de dependencias)
        // -------------------------
        builder.Services.AddScoped<ILibroRepository, LibroRepository>();


        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
        });

        builder.Services.AddHttpContextAccessor();

        // -------------------------
        // MVC
        // -------------------------
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // -------------------------
        // Middleware HTTP
        // -------------------------
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseSession();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}