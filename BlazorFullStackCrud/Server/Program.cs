global using BlazorFullStackCrud.Shared;
global using Microsoft.EntityFrameworkCore;
using BlazorFullStackCrud.Client.Services.SuperHeroService;
using Core.Interfaces;
using Core.Interfaces.Service;
using Core.Services;
using Infrastructure.Data;
using Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using AutoMapper;
using System.Reflection;
using BlazorFullStackCrud.Server.Common;
using Core.Interfaces.Repository;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//Add dependency lifetime
#region Repository
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IWindowRepository, WindowRepository>();
builder.Services.AddScoped<ISubElementRepository, SubElementRepository>();

#endregion

#region Service
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IWindowService, WindowService>();
builder.Services.AddScoped<ISubElementService, SubElementService>();

#endregion

#region Common
builder.Services.AddScoped<ApplicationDbContext>(); 
#endregion

//Add auto mapper config
builder.Services.AddAutoMapper(typeof(OrderMappingProfile));
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseSwagger();

// This middleware serves the Swagger documentation UI
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order Management V1");
    c.RoutePrefix = "api-docs";
    c.DocumentTitle = "Order Management Service";
});

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
