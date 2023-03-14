global using BlazorFullStackCrud.Client.Services.SuperHeroService;
global using BlazorFullStackCrud.Shared;
using BlazorFullStackCrud.Client;
using BlazorFullStackCrud.Client.Services.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//Regiseter dependency
builder.Services.AddScoped<IOrderClientService, OrderClientService>();
builder.Services.AddScoped<ToastService>();


await builder.Build().RunAsync();
