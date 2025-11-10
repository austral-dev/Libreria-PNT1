using Fluent.Infrastructure.FluentModel;
using Libreria_PNT1.Data;
using Librería_PNT1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Sqlite;
using Librería_PNT1.Repositories;

var builder = WebApplication.CreateBuilder(args);

// -------------------------
// Base de datos
// -------------------------

// Si querés seguir usando SQLite para las pruebas, mantené esta línea:
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Si vas a usar SQL Server (recomendado para integrar con EF Core):
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// -------------------------
// Repositorios (inyección de dependencias)
// -------------------------
builder.Services.AddScoped<ILibroRepository, LibroRepository>();

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
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
