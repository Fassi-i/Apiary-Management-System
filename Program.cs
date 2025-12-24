using ApiaryManagementSystem.Context;
using ApiaryManagementSystem.Models;
using ApiaryManagementSystem.Services.UserService;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ApiaryManagementSystem.Validators;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ApiaryManagementSystem.Services.ApiaryServices;
using ApiaryManagementSystem.Services.InspectionService;
using ApiaryManagementSystem.Services.QueenService;
using ApiaryManagementSystem.Extensions;
using ApiaryManagementSystem.Services.UserRoleService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));


builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddScoped<IValidator<User>, UserValidator>();
builder.Services.AddScoped<IValidator<Apiary>, ApiaryValidator>(); 
builder.Services.AddScoped<IValidator<BeeColony>, BeeColonyValidator>(); 

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IApiaryService, ApiaryService>();
builder.Services.AddScoped<IBeeColonyService, BeeColonyService>();
builder.Services.AddScoped<IInspectionService, InspectionService>();
builder.Services.AddScoped<IQueenService, QueenService>();
builder.Services.AddScoped<IClaimsTransformation, RoleClaimsTransformation>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Администратор"));
    options.AddPolicy("Beekeeper", policy => policy.RequireRole("Пчеловод"));
    options.AddPolicy("SeniorBeekeeper", policy =>
        policy.RequireAssertion(context =>
            context.User.IsInRole("Старший пчеловод") ||
            context.User.IsInRole("Администратор")));

    options.AddPolicy("AnyBeekeeper", policy =>
        policy.RequireAssertion(context =>
            context.User.IsInRole("Пчеловод") ||
            context.User.IsInRole("Старший пчеловод") ||
            context.User.IsInRole("Администратор")));
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromDays(7);
        options.SlidingExpiration = true;
    });

var app = builder.Build();
    
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Apiary}/{action=Index}/{id?}");

app.Run();
