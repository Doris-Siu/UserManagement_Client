using Newtonsoft.Json;
using UserManagement_Client.Interfaces;
using UserManagement_Client.VM;

namespace UserManagement.Services.Domain.Implementations;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    private IConfiguration _configuration;
    private string _baseUrl;

    public UserService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _baseUrl = _configuration.GetSection("BaseUrl").Value;
    }

    public async Task<UserDTO> Get(long userId)
    {
        var response = await _httpClient.GetAsync($"/api/user/{userId}");
        var content = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            var user = JsonConvert.DeserializeObject<UserDTO>(content);
            return user;
        }
        return new UserDTO();
    }

        public async Task<IEnumerable<UserDTO>> Get()
    {
        var response = await _httpClient.GetAsync("/api/user");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<UserDTO>>(content);
            return users;
        }

        return new List<UserDTO>();
    }
}

