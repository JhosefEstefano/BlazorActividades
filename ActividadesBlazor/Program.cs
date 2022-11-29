using ActividadesBlazor;
using ActividadesBlazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://ylxje4zgq5.execute-api.us-west-2.amazonaws.com/Prod/api/") });
builder.Services.AddScoped<IClasificacionService, ClasificacionService>();
builder.Services.AddScoped<IActividadService, ActividadService>();


await builder.Build().RunAsync();  