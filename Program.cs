namespace Luan1006.MM202.ExamUnit4
{
    public class Program
    {
        public static void Main()
        {
            UserInterface userInterface = new UserInterface();
            userInterface.NavigateMenu();
        }

        private static void WIP()
        {
            double latitude = 58.20; // grimstad latitude
            double longitude = 8.35; // grimstad longitude

            WeatherData userWeatherData = UserInput.GetWeatherData(latitude, longitude);
            WeatherLog userWeatherLog = new WeatherLog(isUser: true);
            userWeatherLog.AddData(userWeatherData);
            userWeatherLog.SaveToJson("JsonFiles/WeatherLogFromUser.json");

            MetApiHandler metApiHandler = new MetApiHandler(latitude, longitude);

            WeatherData weatherData = metApiHandler.GetWeatherData();
            WeatherLog weatherLog = new WeatherLog(isUser: false);
            weatherLog.AddData(weatherData);
            weatherLog.SaveToJson("JsonFiles/WeatherLogFromAPI.json");
        }
    }
}