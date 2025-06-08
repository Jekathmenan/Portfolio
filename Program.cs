using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Data;
using PortfolioApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

/*// Add usersettings.json if it exists
var userSettingsPath = Path.Combine(builder.Environment.ContentRootPath, "usersettings.json");
if (File.Exists(userSettingsPath))
{
    builder.Configuration.AddJsonFile(userSettingsPath, optional: true, reloadOnChange: true);
}*/

builder.Services.AddDbContext<PortfolioContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PortfolioConnection"));
});

builder.Services.AddTransient<IEmailSender, EmailSender>();

// Fix for CS1061: Replace the problematic line with the correct method call
IdentityBuilder identityBuilder = builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<PortfolioContext>();

/*builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
}).AddEntityFrameworkStores<PortfolioContext>()
  .AddDefaultTokenProviders();*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
