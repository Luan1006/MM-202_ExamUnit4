using System.Text.Json;

namespace Luan1006.MM202.ExamUnit4
{
    public class Program
    {
        public static void Main()
        {
            double latitude = 58.20; // grimstad latitude
            double longitude = 8.35; // grimstad longitude

            MetApiHandler metApiHandler = new MetApiHandler();
            JsonDocument data = metApiHandler.HandleRequest(latitude, longitude).Result;
            double dataAirTemperature = data.RootElement.GetProperty("properties").GetProperty("timeseries")[0].GetProperty("data").GetProperty("instant").GetProperty("details").GetProperty("air_temperature").GetDouble();
            double dataRelativeHumidity = data.RootElement.GetProperty("properties").GetProperty("timeseries")[0].GetProperty("data").GetProperty("instant").GetProperty("details").GetProperty("relative_humidity").GetDouble();
            double dataWindFromDirection = data.RootElement.GetProperty("properties").GetProperty("timeseries")[0].GetProperty("data").GetProperty("instant").GetProperty("details").GetProperty("wind_from_direction").GetDouble();
            double dataWindSpeed = data.RootElement.GetProperty("properties").GetProperty("timeseries")[0].GetProperty("data").GetProperty("instant").GetProperty("details").GetProperty("wind_speed").GetDouble();
            DateTime dateTime = data.RootElement.GetProperty("properties").GetProperty("timeseries")[0].GetProperty("time").GetDateTime();

            WeatherData weatherData = new WeatherData(false, dateTime, longitude, latitude, dataAirTemperature, dataRelativeHumidity, dataWindFromDirection, dataWindSpeed);

            Console.WriteLine($"Data Date: {weatherData.Date}");
            Console.WriteLine($"Data Longitude: {weatherData.Longitude}");
            Console.WriteLine($"Data Latitude: {weatherData.Latitude}");
            Console.WriteLine($"Data Air Temperature: {weatherData.AirTemperature}");
            Console.WriteLine($"Data Relative Humidity: {weatherData.RelativeHumidity}");
            Console.WriteLine($"Data Wind From Direction: {weatherData.WindFromDirection}");
            Console.WriteLine($"Data Wind Speed: {weatherData.WindSpeed}");

            WeatherLog weatherLog = new WeatherLog();
            weatherLog.AddData(weatherData);
            weatherLog.SaveToJson("weatherlog.json");
        }
    }
}