namespace Luan1006.MM202.ExamUnit4
{
    public class LogTodaysWeather
    {
        public static void Run()
        {
            Console.Clear();
            double latitude = 58.20; // grimstad latitude
            double longitude = 8.35; // grimstad longitude

            MetApiHandler metApiHandler = new MetApiHandler(latitude, longitude);

            WeatherData weatherData = metApiHandler.GetWeatherData();
            WeatherReport.PrintWeatherData(weatherData, Constants.api);
            WeatherLog weatherLog = new WeatherLog(isUser: false);
            weatherLog.AddData(weatherData);
            weatherLog.SaveToJson("JsonFiles/WeatherLogFromAPI.json");

            Console.Clear();

            WeatherData userWeatherData = UserInput.GetWeatherData(latitude, longitude);
            WeatherLog userWeatherLog = new WeatherLog(isUser: true);
            userWeatherLog.AddData(userWeatherData);
            userWeatherLog.SaveToJson("JsonFiles/WeatherLogFromUser.json");

            Console.WriteLine("Weather data for today has been logged.");
            WeatherReport.PrintWeatherData(userWeatherData, Constants.user);
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();

            MainMenu userInterface = new MainMenu();
            userInterface.NavigateMenu();
        }
    }
}