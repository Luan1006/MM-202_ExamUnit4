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

        // UserInput
        public static readonly string airTemperaturePrompt = "Enter the air temperature: ";
        public static readonly string relativeHumidityPrompt = "Enter the relative humidity: ";
        public static readonly string windFromDirectionPrompt = "Enter the wind from direction: ";
        public static readonly string windSpeedPrompt = "Enter the wind speed: ";
        public static readonly string invalidInput = "Invalid input, please try again.";
        
    }
}