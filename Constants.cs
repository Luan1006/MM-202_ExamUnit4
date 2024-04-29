namespace Luan1006.MM202.ExamUnit4
{
    public class Constants
    {
        // MetApiHandler
        public static readonly string sitename = "https://github.com/Luan1006";
        public static readonly string locationForecastUrl = "https://api.met.no/weatherapi/locationforecast/2.0/compact";
        public static readonly string RequestHeader = "MM-202_ExamUnit4/1.0 ({0})";
        public static readonly string properties = "properties";
        public static readonly string timeseries = "timeseries";
        public static readonly string data = "data";
        public static readonly string instant = "instant";
        public static readonly string details = "details";
        public static readonly string air_temperature = "air_temperature";
        public static readonly string relative_humidity = "relative_humidity";
        public static readonly string wind_from_direction = "wind_from_direction";
        public static readonly string wind_speed = "wind_speed";
        public static readonly string time = "time";
        public static readonly string requestFailed = "Request failed with status code {0}";
        public static readonly string expires = "Expires";
        public static readonly string requestUrl = "{0}?lat={1}&lon={2}";

        // UserInput
        public static readonly string airTemperaturePrompt = "Enter the air temperature: ";
        public static readonly string relativeHumidityPrompt = "Enter the relative humidity: ";
        public static readonly string windFromDirectionPrompt = "Enter the wind from direction: ";
        public static readonly string windSpeedPrompt = "Enter the wind speed: ";
        public static readonly string invalidInput = "Invalid input, please try again.";

        // WeatherReport
        public const int dateWidth = 10;
        public const int longitudeWidth = 9;
        public const int latitudeWidth = 9;
        public const int temperatureWidth = 13;
        public const int humidityWidth = 17;
        public const int windDirWidth = 12;
        public const int windSpeedWidth = 16;
        public const int typeWidth = 5;
        public static readonly char NWChar = '┌';
        public static readonly char NChar = '┬';
        public static readonly char NEChar = '┐';
        public static readonly char WChar = '├';
        public static readonly char MChar = '┼';
        public static readonly char EChar = '┤';
        public static readonly char SWChar = '└';
        public static readonly char SChar = '┴';
        public static readonly char SEChar = '┘';
        public static readonly string[] header = ["Date", "Longitude", "Latitude", "Air Temp (°C)", "Rel. Humidity (%)", "Wind Dir (°)", "Wind Speed (m/s)", "Type"];
        public static readonly string user = "User";
        public static readonly string api = "API";
        public static readonly string diff = "Diff";
        public static readonly string WeatherLogFromAPIPath = "JsonFiles/WeatherLogFromAPI.json";
        public static readonly string WeatherLogFromUserPath = "JsonFiles/WeatherLogFromUser.json";
        public static readonly string NoDataDate = "No data for the date {0}.";
        public static readonly string PressAnyKey = "Press any key to return to go back";
        public static readonly string WeeklyReport = "Weekly report (Showing last 7 days available):";
        public static readonly string MonthlyReport = "Monthly report (Showing last 30 days available):";
    }
}