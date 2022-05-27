using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private static List<WeatherForecast> WeatherForecasts { get; set; } = new List<WeatherForecast>();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        if (WeatherForecasts == null || !WeatherForecasts.Any())
        {
            WeatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [Route("[action]")]
    [Route("GetListWeather")]
    [Route("GetListWeatherV2")]
    public IEnumerable<WeatherForecast> Get()
    {
        return WeatherForecasts;
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast){
        WeatherForecasts.Add(weatherForecast);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        try
        {
            WeatherForecasts.RemoveAt(id);
            return Ok();
        }
        catch (System.Exception ex)
        {
            return NotFound($"No se encontro resgistro con el id: {id}");
        }
    }
}
