using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SalesWebMvcContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("SalesWebMvcContext"), 
    MySqlServerVersion.LatestSupportedServerVersion, 
    builder => builder.MigrationsAssembly("SalesWebMvc")));

builder.Services.AddScoped<SeedingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
