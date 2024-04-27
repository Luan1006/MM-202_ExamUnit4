namespace Luan1006.MM202.ExamUnit4
{
    public class WeatherData
    {
        private DateTime Date { get; set; }
        private double Longitude { get; set; }
        private double Latitude { get; set; }
        private double AirTemperature { get; set; }
        private double PrecipitationAmount { get; set; }
        private double RelativeHumidity { get; set; }
        private double WindFromDirection { get; set; }
        private double WindSpeed { get; set; }

        public WeatherData(DateTime date, double longitude, double latitude, double air_temperature, double precipitation_amount, double relative_humidity, double wind_from_direction, double wind_speed)
        {
            Longitude = longitude;
            Latitude = latitude;
            Date = date;
            AirTemperature = air_temperature;
            PrecipitationAmount = precipitation_amount;
            RelativeHumidity = relative_humidity;
            WindFromDirection = wind_from_direction;
            WindSpeed = wind_speed;
        }
    }