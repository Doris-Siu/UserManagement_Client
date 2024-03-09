using System.Text;
using Newtonsoft.Json;
using UserManagement_Client.Interfaces;
using UserManagement_Client.DtoModel;

namespace UserManagement.Services.Domain.Implementations;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpClientFactory _httpClientFactory;

    private IConfiguration _configuration;
    

    public UserService(IHttpClientFactory httpClientFactory, HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;


    }

    public async Task<UserDTO> Get(long userId)
    {
        try
        {
            using var apiHttpClient = _httpClientFactory.CreateClient("API");
            var response = await apiHttpClient.GetAsync($"/api/User/{userId}");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var user = JsonConvert.DeserializeObject<UserDTO>(content);

                return user;
            }
            else
            {
                return new UserDTO { Forename = response.ReasonPhrase };
            }
        }
        catch(Exception ex)
        {
            return new UserDTO { Forename = ex.Message };
        }
    }

    public async Task<IEnumerable<UserDTO>> Get()
    {
        using var apiHttpClient = _httpClientFactory.CreateClient("API");
        var response = await apiHttpClient.GetAsync("/api/User");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<UserDTO>>(content);
            return users;
        }

        return new List<UserDTO>();
    }


    public async Task<(bool success, UserDTO dto, string error)> Create(UserDTO dto)
    {
        using var apiHttpClient = _httpClientFactory.CreateClient("API");
        var content = JsonConvert.SerializeObject(dto);
        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

        var response = await apiHttpClient.PostAsync("api/User", bodyContent);

        if (response.IsSuccessStatusCode)
        {
            var contentResponse = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDTO>(contentResponse);
            return (true, user, null);
        }
        else
            return (false, null, response.ReasonPhrase);
    }


    public async Task<(bool success,UserDTO dto, string error)> Update(UserDTO dto)
    {
        using var apiHttpClient = _httpClientFactory.CreateClient("API");
        var content = JsonConvert.SerializeObject(dto);
        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

        var response = await apiHttpClient.PutAsync($"api/User/{dto.Id}", bodyContent);

        if (response.IsSuccessStatusCode)
        {
            var contentResponse = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDTO>(contentResponse);
            return (true, user, null);
        }
        else
            return (false, null, response.ReasonPhrase);
    }

    public async Task<(bool success, UserDTO dto, string error)> Delete(UserDTO dto)
    {
        using var apiHttpClient = _httpClientFactory.CreateClient("API");
        var response = await apiHttpClient.DeleteAsync($"api/User/{dto.Id}");

        if (response.IsSuccessStatusCode)
        {
            var contentResponse = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDTO>(contentResponse);
            return (true, user, null);
        }
        else
            return (false, null, response.ReasonPhrase);
    }



}

