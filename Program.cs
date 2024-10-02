using Microsoft.EntityFrameworkCore;
using prototipo2.Models;
using Microsoft.Extensions.DependencyInjection;
using prototipo2.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<prototipo2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("prototipo2Context") ?? throw new InvalidOperationException("Connection string 'prototipo2Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CantinaContext>(options =>
  options.UseMySql(builder.Configuration.GetConnectionString("conexion"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql")));
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
