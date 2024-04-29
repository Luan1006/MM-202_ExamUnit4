namespace Luan1006.MM202.ExamUnit4
{
    public class LogTodaysWeather
    {
        private static void FetchAndLogWeatherData(bool isUser, string logPath)
        {
            WeatherData weatherData;

            if (isUser)
            {
                weatherData = UserInput.GetWeatherData(Constants.latitude, Constants.longitude);
            }
            else
            {
                MetApiHandler metApiHandler = new MetApiHandler(Constants.latitude, Constants.longitude);
                weatherData = metApiHandler.GetWeatherData();
            }

            WeatherLog weatherLog = new WeatherLog(isUser);
            weatherLog.AddData(weatherData);
            weatherLog.SaveToJson(logPath);

            if (isUser)
            {
                Console.WriteLine(Constants.WeatherDataLogged);
                WeatherReport.PrintWeatherData(weatherData, Constants.user);
            }
            else
            {
                WeatherReport.PrintWeatherData(weatherData, Constants.api);
            }
        }

        public static void Run()
        {
            Console.Clear();

            FetchAndLogWeatherData(false, Constants.WeatherLogFromAPIPath);

            Console.Clear();

            FetchAndLogWeatherData(true, Constants.WeatherLogFromUserPath);

            Console.WriteLine(Constants.PressAnyKey);
            Console.ReadKey();

            MainMenu userInterface = new MainMenu();
            userInterface.NavigateMenu();
        }
    }
}