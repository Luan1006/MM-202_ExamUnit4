using System.Text.Json;

namespace Luan1006.MM202.ExamUnit4
{
    public class WeatherReport
    {
        private static List<WeatherData> UserWeatherData { get; set; }
        private static List<WeatherData> YRWeatherData { get; set; }

        public static void DisplayUserInputWeatherData(WeatherData userInputWeatherData)
        {
            PrintWeatherData("Weather data from user input:", userInputWeatherData);
        }

        public static void DisplayApiWeatherData(WeatherData apiWeatherData)
        {
            PrintWeatherData("Weather data from API:", apiWeatherData);
        }

        public static void PrintWeatherDataDifference(WeatherData userInputWeatherData, WeatherData apiWeatherData)
        {
            Console.WriteLine("Difference between user input and API data:");
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20} {6,-20}",
                "Date", "Longitude", "Latitude", "Air Temp (°C)", "Rel. Humidity (%)", "Wind Dir (°)", "Wind Speed (m/s)");
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20} {6,-20}",
                userInputWeatherData.Date, userInputWeatherData.Longitude, userInputWeatherData.Latitude,
                userInputWeatherData.AirTemperature - apiWeatherData.AirTemperature,
                userInputWeatherData.RelativeHumidity - apiWeatherData.RelativeHumidity,
                userInputWeatherData.WindFromDirection - apiWeatherData.WindFromDirection,
                userInputWeatherData.WindSpeed - apiWeatherData.WindSpeed);

            Console.WriteLine();
        }

        private static void PrintWeatherData(string header, WeatherData weatherData)
        {
            Console.WriteLine(header);
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20} {6,-20}",
                "Date", "Longitude", "Latitude", "Air Temp (°C)", "Rel. Humidity (%)", "Wind Dir (°)", "Wind Speed (m/s)");
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20} {6,-20}",
                weatherData.Date, weatherData.Longitude, weatherData.Latitude, weatherData.AirTemperature, weatherData.RelativeHumidity, weatherData.WindFromDirection, weatherData.WindSpeed);
            Console.WriteLine();
        }

        public static void GenerateDailyReport(DateTime date)
        {
            UserWeatherData = JsonSerializer.Deserialize<List<WeatherData>>(File.ReadAllText("JsonFiles/WeatherLogFromUser.json"));
            YRWeatherData = JsonSerializer.Deserialize<List<WeatherData>>(File.ReadAllText("JsonFiles/WeatherLogFromAPI.json"));

            WeatherData dailyData = UserWeatherData.FirstOrDefault(d => d.Date.Date == date.Date);
            if (dailyData == null)
            {
                Console.WriteLine($"No data exists for the date {date:yyyy-MM-dd}.");
                return;
            }

            DisplayUserInputWeatherData(dailyData);

            WeatherData apiData = YRWeatherData.FirstOrDefault(d => d.Date.Date == date.Date);

            DisplayApiWeatherData(apiData);

            PrintWeatherDataDifference(dailyData, apiData);

            Console.WriteLine("\nPress any key to go back");
            Console.ReadKey();
        }
    }
}