using System.ComponentModel;
using ModelContextProtocol.Server;

public class WeatherTools
{
    [McpServerTool]
    [Description("Describes random weather in the provided city.")]
    public string GetCityWeather(
    [Description("Name of the city to return weather for")] string city)
    {
        var weather = Environment.GetEnvironmentVariable("WEATHER_CHOICES");
        if (string.IsNullOrWhiteSpace(weather))
            weather = "balmy,rainy,stormy";

        var weatherChoices = weather.Split(",");
        var selectedWeatherIndex = Random.Shared.Next(0, weatherChoices.Length);

        return $"The weather in {city} is {weatherChoices[selectedWeatherIndex]}.";
    }
}
