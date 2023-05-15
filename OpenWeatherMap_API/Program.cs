using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using OpenWeatherMap_API;
using System.Reflection;

var client = new HttpClient();

IConfiguration config = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json")
       .Build();

string apiKey = config.GetSection("AppSettings")["ApiKey"];


#region WEATHER




Console.WriteLine("Enter in a city: ");
var cityName = Console.ReadLine();


var weatherMapURL = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=imperial";

//OR

//var weatherMapURL = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={APIKey.Key}&units=imperial";

string weatherResponse = client.GetStringAsync(weatherMapURL).Result;
JObject weatherObject = JObject.Parse(weatherResponse);

Console.WriteLine("Weather Object");

//Console.WriteLine(weatherResponse);
//Console.WriteLine();
//Console.WriteLine("Weather: ");
Console.WriteLine($"It is {weatherObject["main"]["temp"]} degrees Fahrenheit in {cityName}");

#endregion