using System.Text.Json;

namespace Luan1006.MM202.ExamUnit4
{
    public class Program
    {
        public static void Main()
        {
            double latitude = 58.20; // grimstad latitude
            double longitude = 8.35; // grimstad longitude

            Console.WriteLine("Enter the air temperature: ");
            double userAirTemperature;
            while (!double.TryParse(Console.ReadLine(), out userAirTemperature))
            {
                Console.WriteLine("Invalid input, please try again.");
            }

            Console.WriteLine("Enter the relative humidity: ");
            double userRelativeHumidity;
            while (!double.TryParse(Console.ReadLine(), out userRelativeHumidity))
            {
                Console.WriteLine("Invalid input, please try again.");
            }

            Console.WriteLine("Enter the wind from direction: ");
            double userWindFromDirection;
            while (!double.TryParse(Console.ReadLine(), out userWindFromDirection))
            {
                Console.WriteLine("Invalid input, please try again.");
            }

            Console.WriteLine("Enter the wind speed: ");
            double userWindSpeed;
            while (!double.TryParse(Console.ReadLine(), out userWindSpeed))
            {
                Console.WriteLine("Invalid input, please try again.");
            }

            WeatherData userWeatherData = new WeatherData(DateTime.Now, longitude, latitude, userAirTemperature, userRelativeHumidity, userWindFromDirection, userWindSpeed);
            WeatherLog userWeatherLog = new WeatherLog(isUser: true);
            userWeatherLog.AddData(userWeatherData);
            userWeatherLog.SaveToJson("WeatherLogFromUser.json");

            MetApiHandler metApiHandler = new MetApiHandler();
            JsonDocument data = metApiHandler.HandleRequest(latitude, longitude).Result;
            double dataAirTemperature = data.RootElement.GetProperty("properties").GetProperty("timeseries")[0].GetProperty("data").GetProperty("instant").GetProperty("details").GetProperty("air_temperature").GetDouble();
            double dataRelativeHumidity = data.RootElement.GetProperty("properties").GetProperty("timeseries")[0].GetProperty("data").GetProperty("instant").GetProperty("details").GetProperty("relative_humidity").GetDouble();
            double dataWindFromDirection = data.RootElement.GetProperty("properties").GetProperty("timeseries")[0].GetProperty("data").GetProperty("instant").GetProperty("details").GetProperty("wind_from_direction").GetDouble();
            double dataWindSpeed = data.RootElement.GetProperty("properties").GetProperty("timeseries")[0].GetProperty("data").GetProperty("instant").GetProperty("details").GetProperty("wind_speed").GetDouble();
            DateTime dateTime = data.RootElement.GetProperty("properties").GetProperty("timeseries")[0].GetProperty("time").GetDateTime();

            WeatherData weatherData = new WeatherData(dateTime, longitude, latitude, dataAirTemperature, dataRelativeHumidity, dataWindFromDirection, dataWindSpeed);

            Console.WriteLine($"Date: {weatherData.Date.ToShortDateString()}");
            Console.WriteLine($"Longitude: {weatherData.Longitude}");
            Console.WriteLine($"Latitude: {weatherData.Latitude}");
            Console.WriteLine($"Air Temperature: {weatherData.AirTemperature}");
            Console.WriteLine($"Relative Humidity: {weatherData.RelativeHumidity}");
            Console.WriteLine($"Wind From Direction: {weatherData.WindFromDirection}");
            Console.WriteLine($"Wind Speed: {weatherData.WindSpeed}");

            WeatherLog weatherLog = new WeatherLog(isUser: false);
            weatherLog.AddData(weatherData);
            weatherLog.SaveToJson("WeatherLogFromAPI.json");
        }
    }
}