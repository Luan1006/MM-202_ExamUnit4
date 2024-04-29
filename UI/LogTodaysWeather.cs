namespace Luan1006.MM202.ExamUnit4
{
    public class LogTodaysWeather
    {
        public static void Run()
        {
            Console.Clear();

            MetApiHandler metApiHandler = new MetApiHandler(Constants.latitude, Constants.longitude);

            WeatherData weatherData = metApiHandler.GetWeatherData();
            WeatherReport.PrintWeatherData(weatherData, Constants.api);
            WeatherLog weatherLog = new WeatherLog(isUser: false);
            weatherLog.AddData(weatherData);
            weatherLog.SaveToJson(Constants.WeatherLogFromAPIPath);

            Console.Clear();

            WeatherData userWeatherData = UserInput.GetWeatherData(Constants.latitude, Constants.longitude);
            WeatherLog userWeatherLog = new WeatherLog(isUser: true);
            userWeatherLog.AddData(userWeatherData);
            userWeatherLog.SaveToJson(Constants.WeatherLogFromUserPath);

            Console.WriteLine(Constants.WeatherDataLogged);
            WeatherReport.PrintWeatherData(userWeatherData, Constants.user);
            Console.WriteLine(Constants.PressAnyKey);
            Console.ReadKey();

            MainMenu userInterface = new MainMenu();
            userInterface.NavigateMenu();
        }
    }
}