namespace Luan1006.MM202.ExamUnit4
{
    public class WeatherReport
    {
        public static void DisplayUserInputWeatherData(WeatherData userInputWeatherData)
        {
            PrintWeatherData("Weather data from user input:", userInputWeatherData);
        }

        public static void DisplayApiWeatherData(WeatherData apiWeatherData)
        {
            PrintWeatherData("Weather data from API:", apiWeatherData);
        }

        public static void DisplayWeatherDataDifference(WeatherData userInputWeatherData, WeatherData apiWeatherData)
        {
            Console.WriteLine("Difference between user input and API data:");
            Console.WriteLine($"Date: {userInputWeatherData.Date}");
            Console.WriteLine($"Longitude: {userInputWeatherData.Longitude}");
            Console.WriteLine($"Latitude: {userInputWeatherData.Latitude}");
            Console.WriteLine($"Air temperature: {userInputWeatherData.AirTemperature - apiWeatherData.AirTemperature}°C");
            Console.WriteLine($"Relative humidity: {userInputWeatherData.RelativeHumidity - apiWeatherData.RelativeHumidity}%");
            Console.WriteLine($"Wind from direction: {userInputWeatherData.WindFromDirection - apiWeatherData.WindFromDirection}°");
            Console.WriteLine($"Wind speed: {userInputWeatherData.WindSpeed - apiWeatherData.WindSpeed} m/s");
        }

        private static void PrintWeatherData(string header, WeatherData weatherData)
        {
            Console.WriteLine(header);
            Console.WriteLine($"Date: {weatherData.Date}");
            Console.WriteLine($"Longitude: {weatherData.Longitude}");
            Console.WriteLine($"Latitude: {weatherData.Latitude}");
            Console.WriteLine($"Air temperature: {weatherData.AirTemperature}°C");
            Console.WriteLine($"Relative humidity: {weatherData.RelativeHumidity}%");
            Console.WriteLine($"Wind from direction: {weatherData.WindFromDirection}°");
            Console.WriteLine($"Wind speed: {weatherData.WindSpeed} m/s");
        }
    }
}