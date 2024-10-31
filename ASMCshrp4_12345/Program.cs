using ASMCshrp4_12345.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddAuthentication(options =>
{

    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})

    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
        options.LoginPath = "/Account/Index";  // Đường dẫn để đăng nhập
        options.LogoutPath = "/Account/Logout"; // Đường dẫn để đăng xuất
        options.AccessDeniedPath = "/Account/AccessDenied";
    }
    )

    .AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
    {
        options.ClientId = builder.Configuration.GetSection("GoogleKeys:ClientId").Value;
        options.ClientSecret = builder.Configuration.GetSection("GoogleKeys:ClientSecret").Value;

        options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

        options.Events.OnRedirectToAuthorizationEndpoint = context =>
        {
            // Thêm prompt=consent vào chuỗi truy vấn (query string)
            var redirectUri = context.RedirectUri;
            context.Response.Redirect(redirectUri + "&prompt=consent");
            return Task.CompletedTask;
        };
    });

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddDbContext<Csharp4Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Csharp4_connectstring"));
});
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

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
