using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);

// Add MySQL Database Connection
var connectionString = $"{builder.Configuration.GetConnectionString("SqlConnection")};password={builder.Configuration["Test"]}";
builder.Services.AddDbContext<ASPFutoVerseny.Models.FutoDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add services to the container.
builder.Services.AddControllersWithViews();

// localize
builder.Services.AddLocalization(o =>
{
    o.ResourcesPath = "Resources";
});

builder.Services.Configure<RequestLocalizationOptions>(o =>
{
    //o.SetDefaultCulture("hu");
    string[] langs = ["hu", "en"];
    o.AddSupportedCultures(langs);
    o.AddSupportedUICultures(langs);
});

var app = builder.Build();

app.UseRequestLocalization();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
