namespace Luan1006.MM202.ExamUnit4
{
    public class WeatherReport
    {
        public static void PrintUserWeatherData(WeatherData weatherData)
        {
            Console.WriteLine("Weather data from user input:");
            Console.WriteLine($"Date: {weatherData.Date}");
            Console.WriteLine($"Longitude: {weatherData.Longitude}");
            Console.WriteLine($"Latitude: {weatherData.Latitude}");
            Console.WriteLine($"Air temperature: {weatherData.AirTemperature}°C");
            Console.WriteLine($"Relative humidity: {weatherData.RelativeHumidity}%");
            Console.WriteLine($"Wind from direction: {weatherData.WindFromDirection}°");
            Console.WriteLine($"Wind speed: {weatherData.WindSpeed} m/s");
        }

        public static void PrintApiWeatherData(WeatherData weatherData)
        {
            Console.WriteLine("Weather data from API:");
            Console.WriteLine($"Date: {weatherData.Date}");
            Console.WriteLine($"Longitude: {weatherData.Longitude}");
            Console.WriteLine($"Latitude: {weatherData.Latitude}");
            Console.WriteLine($"Air temperature: {weatherData.AirTemperature}°C");
            Console.WriteLine($"Relative humidity: {weatherData.RelativeHumidity}%");
            Console.WriteLine($"Wind from direction: {weatherData.WindFromDirection}°");
            Console.WriteLine($"Wind speed: {weatherData.WindSpeed} m/s");
        }

        public static void PrintDifference(WeatherData userWeatherData, WeatherData apiWeatherData)
        {
            Console.WriteLine("Difference between user input and API data:");
            Console.WriteLine($"Date: {userWeatherData.Date}");
            Console.WriteLine($"Longitude: {userWeatherData.Longitude}");
            Console.WriteLine($"Latitude: {userWeatherData.Latitude}");
            Console.WriteLine($"Air temperature: {userWeatherData.AirTemperature - apiWeatherData.AirTemperature}°C");
            Console.WriteLine($"Relative humidity: {userWeatherData.RelativeHumidity - apiWeatherData.RelativeHumidity}%");
            Console.WriteLine($"Wind from direction: {userWeatherData.WindFromDirection - apiWeatherData.WindFromDirection}°");
            Console.WriteLine($"Wind speed: {userWeatherData.WindSpeed - apiWeatherData.WindSpeed} m/s");
        }
    }
}