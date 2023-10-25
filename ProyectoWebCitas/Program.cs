using Microsoft.EntityFrameworkCore;
using ProyectoWebCitas.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext with the connection string from configuration.
builder.Services.AddDbContext<ProyectoCitasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));

var app = builder.Build();

// Configure the HTTP request pipeline.

// Use error handling for non-development environments.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();  // Only use HSTS in production scenarios.
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Authorization should be after UseRouting and before UseEndpoints.
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=iniciosesion}/{id?}");


app.Run();
