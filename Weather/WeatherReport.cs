using System.Runtime.InteropServices;
using System.Text.Json;

namespace Luan1006.MM202.ExamUnit4
{
    public class WeatherReport
    {
        const int dateWidth = 10;
        const int longitudeWidth = 9;
        const int latitudeWidth = 9;
        const int tempWidth = 13;
        const int humidityWidth = 17;
        const int windDirWidth = 12;
        const int windSpeedWidth = 16;

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
            PrintTopBorder();
            Console.WriteLine($"|{{0,-{dateWidth}}}|{{1,-{longitudeWidth}}}|{{2,-{latitudeWidth}}}|{{3,-{tempWidth}}}|{{4,-{humidityWidth}}}|{{5,-{windDirWidth}}}|{{6,-{windSpeedWidth}}}|",
                "Date", "Longitude", "Latitude", "Air Temp (°C)", "Rel. Humidity (%)", "Wind Dir (°)", "Wind Speed (m/s)");
            PrintMiddleBorder();
            Console.WriteLine($"|{{0,-{dateWidth}}}|{{1,-{longitudeWidth}}}|{{2,-{latitudeWidth}}}|{{3,-{tempWidth}}}|{{4,-{humidityWidth}}}|{{5,-{windDirWidth}}}|{{6,-{windSpeedWidth}}}|",
                userInputWeatherData.Date.ToShortDateString(), userInputWeatherData.Longitude, userInputWeatherData.Latitude,
                Math.Round(userInputWeatherData.AirTemperature - apiWeatherData.AirTemperature, 2),
                Math.Round(userInputWeatherData.RelativeHumidity - apiWeatherData.RelativeHumidity, 2),
                Math.Round(userInputWeatherData.WindFromDirection - apiWeatherData.WindFromDirection, 2),
                Math.Round(userInputWeatherData.WindSpeed - apiWeatherData.WindSpeed, 2));
            PrintBottomBorder();
            Console.WriteLine();
        }

        private static void PrintWeatherData(string header, WeatherData weatherData)
        {
            Console.WriteLine(header);
            PrintTopBorder();
            Console.WriteLine($"|{{0,-{dateWidth}}}|{{1,-{longitudeWidth}}}|{{2,-{latitudeWidth}}}|{{3,-{tempWidth}}}|{{4,-{humidityWidth}}}|{{5,-{windDirWidth}}}|{{6,-{windSpeedWidth}}}|",
                "Date", "Longitude", "Latitude", "Air Temp (°C)", "Rel. Humidity (%)", "Wind Dir (°)", "Wind Speed (m/s)");
            PrintMiddleBorder();
            Console.WriteLine($"|{{0,-{dateWidth}}}|{{1,-{longitudeWidth}}}|{{2,-{latitudeWidth}}}|{{3,-{tempWidth}}}|{{4,-{humidityWidth}}}|{{5,-{windDirWidth}}}|{{6,-{windSpeedWidth}}}|",
                weatherData.Date.ToShortDateString(), weatherData.Longitude, weatherData.Latitude, weatherData.AirTemperature, weatherData.RelativeHumidity, weatherData.WindFromDirection, weatherData.WindSpeed);
            PrintBottomBorder();
            Console.WriteLine();
        }

        private static string GenerateBorderLine(char startChar, char midChar, char endChar, params int[] widths)
        {
            var parts = widths.Select(width => new string('─', width));
            return $"{startChar}{string.Join(midChar, parts)}{endChar}";
        }

        private static void PrintTopBorder()
        {
            Console.WriteLine(GenerateBorderLine('┌', '┬', '┐', dateWidth, longitudeWidth, latitudeWidth, tempWidth, humidityWidth, windDirWidth, windSpeedWidth));
        }
        private static void PrintMiddleBorder()
        {
            Console.WriteLine(GenerateBorderLine('├', '┼', '┤', dateWidth, longitudeWidth, latitudeWidth, tempWidth, humidityWidth, windDirWidth, windSpeedWidth));
        }

        private static void PrintBottomBorder()
        {
            Console.WriteLine(GenerateBorderLine('└', '┴', '┘', dateWidth, longitudeWidth, latitudeWidth, tempWidth, humidityWidth, windDirWidth, windSpeedWidth));
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