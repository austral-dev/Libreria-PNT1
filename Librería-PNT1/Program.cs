using Libreria_PNT1.Data;
using Libreria_PNT1.Repositories;
using Libreria_PNT1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// -------------------------
// Repositorios (inyección de dependencias)
// -------------------------
//builder.Services.AddScoped<ILibroRepository, LibroRepository>();

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