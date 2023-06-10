using Edigama.BL.Implementation;
using Edigama.BL.Interfaces;
using Edigama.DAL.Implementation;
using Edigama.DAL.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies; // future admin page
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Serilog; // future Logger 

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserBL,UserBL>();
builder.Services.AddScoped<IUserDAL,UserDAL>();
var app = builder.Build();



app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
