namespace Luan1006.MM202.ExamUnit4
{
    public class WeatherData
    {
        public bool IsRetriviedFromUser { get; set; }
        public DateTime Date { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double AirTemperature { get; set; }
        public double RelativeHumidity { get; set; }
        public double WindFromDirection { get; set; }
        public double WindSpeed { get; set; }

        public WeatherData() { }

        public WeatherData(bool isRetriviedFromUser, DateTime date, double longitude, double latitude, double air_temperature, double relative_humidity, double wind_from_direction, double wind_speed)
        {
            IsRetriviedFromUser = isRetriviedFromUser;
            Longitude = longitude;
            Latitude = latitude;
            Date = date;
            AirTemperature = air_temperature;
            RelativeHumidity = relative_humidity;
            WindFromDirection = wind_from_direction;
            WindSpeed = wind_speed;
        }
    }
}