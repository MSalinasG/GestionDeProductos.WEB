using GestionDeProductos.Data.Database;
using GestionDeProductos.Data.Helpers;
using GestionDeProductos.Data.Repositories;
using GestionDeProductos.Data.Repository;
using GestionDeProductos.Web.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Database Connection
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

// Add Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IBreadcrumbService, BreadcrumbService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Datos Semilla
if (GlobalHelper.General.UseSeeder)
{
    try
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        DatabaseInitializer.Initialize(services);
    }
    catch (Exception ex)
    {
        var errorMessage = ex.Message;
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
