using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UserManagement.Services.Implementations;
using UserManagement_Client;
using UserManagement_Client.Interfaces;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient("API", config =>
{
    var url = builder.Configuration.GetValue<string>("BaseAPIUrl");
    config.BaseAddress = new Uri(url);
});
builder.Services.AddBlazorBootstrap();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<UserManagement_Client.Interfaces.ILogger, Logger>();



builder.Services.AddBlazoredLocalStorage();

builder.Services.AddOidcAuthentication(options =>
{
    // Configure your authentication provider options here.
    // For more information, see https://aka.ms/blazor-standalone-auth
    builder.Configuration.Bind("Local", options.ProviderOptions);
});

await builder.Build().RunAsync();

