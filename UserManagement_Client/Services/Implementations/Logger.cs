using System.Text;
using Newtonsoft.Json;
using UserManagement_Client.Interfaces;
using UserManagement_Client.DtoModel;
using Blazored.LocalStorage;
using Microsoft.Extensions.Logging;

namespace UserManagement.Services.Implementations;


public class Logger : UserManagement_Client.Interfaces.ILogger
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ILocalStorageService _localStorage { get; set; }

    public Logger(ILocalStorageService localStorage, IHttpClientFactory clientFactory) 
    {
        _localStorage = localStorage;
        _httpClientFactory = clientFactory;
    }

    public async Task LogTrace(string message)
    {
        await  LogAsync("Trace", message);
        
    }

    public async Task LogError(string message)
    {
          await LogAsync("Error", message);
        
    }

    private async Task LogAsync(string level, string message)
    {
        var currentUser = await _localStorage.GetItemAsync<UserDTO>("currentUser");
        if (currentUser == null)
            currentUser = new UserDTO();

        UserLogDTO dto = new UserLogDTO
        {
            LogDateTime = DateTime.UtcNow,
            LogLevel = level,
            Message = message,
            UserId = currentUser.Id
        };

        using var apiHttpClient = _httpClientFactory.CreateClient("API");
        var content = JsonConvert.SerializeObject(dto);
        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

        var response = await apiHttpClient.PostAsync("api/UserLog", bodyContent);

    }
}
