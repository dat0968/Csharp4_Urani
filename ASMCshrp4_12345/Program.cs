﻿using ASMCshrp4_12345.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ASMCshrp4_12345.Services;
using ASMCshrp4_12345.MiddleWare;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddAuthentication(options =>
{

    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    //options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})

    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
        options.LoginPath = "/Account/Index";  // Đường dẫn để đăng nhập
        options.LogoutPath = "/Account/Logout"; // Đường dẫn để đăng xuất
        options.AccessDeniedPath = "/Home/Error404";
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
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

builder.Services.AddDbContext<Csharp4Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Csharp4_connectstring"));
});
builder.Services.AddSingleton<IVnPayService, VnPayService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //Display Developer Exception Page in the brower
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<CustomAuthenticationMiddleware>();
app.UseSession();







app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
