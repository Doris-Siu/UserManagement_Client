using Microsoft.AspNetCore.Mvc;
using UserManagement_Data.Data;

namespace UserManagement_API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ApplicationDbContext dbContext;

    public WeatherForecastController(ILogger<WeatherForecastController> logger,
        ApplicationDbContext dbContext)
    {
        //_logger = logger;
        this.dbContext = dbContext;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task Get()
    {
        var a = dbContext.Database.CanConnect();
    }
}

