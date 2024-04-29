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
            Console.WriteLine();
        }

        private static void PrintAllData(WeatherData userWeatherData, WeatherData apiWeatherData)
        {
            PrintDataRow([
                userWeatherData.Date.ToShortDateString(),
                userWeatherData.Longitude.ToString(),
                userWeatherData.Latitude.ToString(),
                userWeatherData.AirTemperature.ToString(),
                userWeatherData.RelativeHumidity.ToString(),
                userWeatherData.WindFromDirection.ToString(),
                userWeatherData.WindSpeed.ToString(),
                user]);
            PrintMiddleBorder();
            PrintDataRow([
                apiWeatherData.Date.ToShortDateString(),
                apiWeatherData.Longitude.ToString(),
                apiWeatherData.Latitude.ToString(),
                apiWeatherData.AirTemperature.ToString(),
                apiWeatherData.RelativeHumidity.ToString(),
                apiWeatherData.WindFromDirection.ToString(),
                apiWeatherData.WindSpeed.ToString(),
                api]);
            PrintMiddleBorder();
            PrintDataRow([
                userWeatherData.Date.ToShortDateString(),
                userWeatherData.Longitude.ToString(),
                userWeatherData.Latitude.ToString(),
                Math.Round(userWeatherData.AirTemperature - apiWeatherData.AirTemperature, 2).ToString(),
                Math.Round(userWeatherData.RelativeHumidity - apiWeatherData.RelativeHumidity, 2).ToString(),
                Math.Round(userWeatherData.WindFromDirection - apiWeatherData.WindFromDirection, 2).ToString(),
                Math.Round(userWeatherData.WindSpeed - apiWeatherData.WindSpeed, 2).ToString(),
                diff]);
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

        public static void GenerateDailyReport(DateTime date)
        {
            Console.Clear();

            PrintTopBorder();
            PrintDataRow(header);
            PrintMiddleBorder();

            UserWeatherData = JsonSerializer.Deserialize<List<WeatherData>>(File.ReadAllText(WeatherLogFromUserPath));
            YRWeatherData = JsonSerializer.Deserialize<List<WeatherData>>(File.ReadAllText(WeatherLogFromAPIPath));

            WeatherData dailyData = UserWeatherData.FirstOrDefault(d => d.Date.Date == date.Date);

            if (dailyData == null)
            {
                Console.WriteLine(string.Format(NoDataDate, date.ToShortDateString()));
                Console.WriteLine(PressAnyKey);
                Console.ReadKey();
                return;
            }

            WeatherData apiData = YRWeatherData.FirstOrDefault(d => d.Date.Date == date.Date);

            PrintAllData(dailyData, apiData);

            PrintBottomBorder();
            Console.WriteLine();

            Console.WriteLine(PressAnyKey);
            Console.ReadKey();
        }

        public static void GenerateWeeklyReport()
        {
            Console.Clear();

            UserWeatherData = JsonSerializer.Deserialize<List<WeatherData>>(File.ReadAllText(WeatherLogFromUserPath));
            YRWeatherData = JsonSerializer.Deserialize<List<WeatherData>>(File.ReadAllText(WeatherLogFromAPIPath));

            DateTime oneWeekAgo = DateTime.Now.AddDays(-7);

            List<WeatherData> dailyData = new List<WeatherData>();
            foreach (WeatherData data in UserWeatherData)
            {
                if (data.Date.Date >= oneWeekAgo.Date)
                {
                    if (!dailyData.Any(d => d.Date.Date == data.Date.Date))
                    {
                        dailyData.Add(data);
                    }
                }
            }

            Console.WriteLine(WeeklyReport);
            Console.WriteLine();

            PrintTopBorder();
            PrintDataRow(header);
            PrintMiddleBorder();

            foreach (WeatherData daily in dailyData)
            {
                WeatherData apiData = null;
                foreach (WeatherData data in YRWeatherData)
                {
                    if (data.Date.Date == daily.Date.Date)
                    {
                        apiData = data;
                        break;
                    }
                }

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

        public static void GenerateMonthlyReport()
        {
            Console.Clear();

            UserWeatherData = JsonSerializer.Deserialize<List<WeatherData>>(File.ReadAllText(WeatherLogFromUserPath));
            YRWeatherData = JsonSerializer.Deserialize<List<WeatherData>>(File.ReadAllText(WeatherLogFromAPIPath));

            DateTime oneMonthAgo = DateTime.Now.AddMonths(-1);

            List<WeatherData> dailyData = new List<WeatherData>();
            foreach (WeatherData data in UserWeatherData)
            {
                if (data.Date.Date >= oneMonthAgo.Date)
                {
                    if (!dailyData.Any(d => d.Date.Date == data.Date.Date))
                    {
                        dailyData.Add(data);
                    }
                }
            }

            Console.WriteLine(MonthlyReport);
            Console.WriteLine();

            PrintTopBorder();
            PrintDataRow(header);
            PrintMiddleBorder();

            foreach (WeatherData daily in dailyData)
            {
                WeatherData apiData = null;
                foreach (WeatherData data in YRWeatherData)
                {
                    if (data.Date.Date == daily.Date.Date)
                    {
                        apiData = data;
                        break;
                    }
                }

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
    }
}