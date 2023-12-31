global using Infrastructure.Data;
global using Infrastructure.Identity;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Web.Areas.Admin.Models;
using Web.Areas.Admin.Interfaces;
using Web.Areas.Admin.Services;
using ApplicationCore.Interfaces;
using Web.Interfaces;
using Web.Models;
using Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CoffeeMateContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CoffeeMateContext")));

builder.Services.AddDbContext<AppIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppIdentityContext")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

builder.Services.AddScoped<IHomeViewModelService, HomeViewModelService>();

builder.Services.AddScoped<IProductsViewModelService, ProductsViewModelService>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CoffeeMateContext>();

    await CoffeeMateContextSeed.SeedAsync(dbContext); 

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    await AppIdentityContextSeed.SeedAsync(roleManager, userManager);
}

    app.Run();
