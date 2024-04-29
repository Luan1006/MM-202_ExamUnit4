using static Luan1006.MM202.ExamUnit4.Constants;
using System.Text.Json;

namespace Luan1006.MM202.ExamUnit4
{
    public class WeatherReport
    {

        private static List<WeatherData> UserWeatherData { get; set; }
        private static List<WeatherData> YRWeatherData { get; set; }

        public static void PrintWeatherData(WeatherData weatherData, string type)
        {
            PrintTopBorder();
            PrintDataRow(header);
            PrintMiddleBorder();
            PrintDataRow([
                weatherData.Date.ToShortDateString(),
                weatherData.Longitude.ToString(),
                weatherData.Latitude.ToString(),
                weatherData.AirTemperature.ToString(),
                weatherData.RelativeHumidity.ToString(),
                weatherData.WindFromDirection.ToString(),
                weatherData.WindSpeed.ToString(),
                type]);
            PrintBottomBorder();
        }

        private static string[] WeatherDataToStringArray(WeatherData weatherData)
        {
            return
            [
            weatherData.Date.ToShortDateString(),
            weatherData.Longitude.ToString(),
            weatherData.Latitude.ToString(),
            weatherData.AirTemperature.ToString(),
            weatherData.RelativeHumidity.ToString(),
            weatherData.WindFromDirection.ToString(),
            weatherData.WindSpeed.ToString()
            ];
        }

        private static void PrintAllData(WeatherData userWeatherData, WeatherData apiWeatherData)
        {
            PrintDataRow(WeatherDataToStringArray(userWeatherData).Concat([user]).ToArray());
            PrintMiddleBorder();
            PrintDataRow(WeatherDataToStringArray(apiWeatherData).Concat([api]).ToArray());
            PrintMiddleBorder();
            PrintDataRow(WeatherDataToStringArray(userWeatherData).Concat([diff]).ToArray());
        }

        private static void PrintDataRow(string[] data)
        {
            Console.WriteLine($"|{{0,-{dateWidth}}}|{{1,-{longitudeWidth}}}|{{2,-{latitudeWidth}}}|{{3,-{temperatureWidth}}}|{{4,-{humidityWidth}}}|{{5,-{windDirWidth}}}|{{6,-{windSpeedWidth}}}|{{7,-{typeWidth}}}|",
                data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7]);
        }

        private static string GenerateBorderLine(char startChar, char midChar, char endChar, params int[] widths)
        {
            var parts = widths.Select(width => new string('─', width));
            return $"{startChar}{string.Join(midChar, parts)}{endChar}";
        }

        private static void PrintTopBorder()
        {
            Console.WriteLine(GenerateBorderLine(NWChar, NChar, NEChar, dateWidth, longitudeWidth, latitudeWidth, temperatureWidth, humidityWidth, windDirWidth, windSpeedWidth, typeWidth));
        }
        private static void PrintMiddleBorder()
        {
            Console.WriteLine(GenerateBorderLine(WChar, MChar, EChar, dateWidth, longitudeWidth, latitudeWidth, temperatureWidth, humidityWidth, windDirWidth, windSpeedWidth, typeWidth));
        }

        private static void PrintBottomBorder()
        {
            Console.WriteLine(GenerateBorderLine(SWChar, SChar, SEChar, dateWidth, longitudeWidth, latitudeWidth, temperatureWidth, humidityWidth, windDirWidth, windSpeedWidth, typeWidth));
        }

        private static void GenerateReport(DateTime date)
        {
            Console.Clear();

            PrintTopBorder();
            PrintDataRow(header);
            PrintMiddleBorder();

            UserWeatherData = JsonSerializer.Deserialize<List<WeatherData>>(File.ReadAllText(WeatherLogFromUserPath));
            YRWeatherData = JsonSerializer.Deserialize<List<WeatherData>>(File.ReadAllText(WeatherLogFromAPIPath));

            List<WeatherData> dailyData = UserWeatherData.Where(d => d.Date.Date >= date.Date).ToList();

            foreach (WeatherData daily in dailyData)
            {
                WeatherData apiData = YRWeatherData.FirstOrDefault(d => d.Date.Date == daily.Date.Date);
                PrintAllData(daily, apiData);

                if (daily != dailyData.Last())
                {
                    PrintMiddleBorder();
                }
            }

            PrintBottomBorder();
            Console.WriteLine();

            Console.WriteLine(PressAnyKey);
            Console.ReadKey();
        }

        public static void GenerateDailyReport(DateTime date)
        {
            GenerateReport(date);
        }

        public static void GenerateWeeklyReport()
        {
            GenerateReport(DateTime.Now.AddDays(-7));
        }

        public static void GenerateMonthlyReport()        {
            GenerateReport(DateTime.Now.AddMonths(-1));
        }
    }
}