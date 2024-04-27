namespace Luan1006.MM202.ExamUnit4
{
    public class WeatherData
    {
        public DateTime Date { get; set; }
        public double AirTemperature { get; set; }
        public double PrecipitationAmount { get; set; }
        public double RelativeHumidity { get; set; }
        public double WindFromDirection { get; set; }
        public double WindSpeed { get; set; }

        public WeatherData(DateTime date, double air_temperature, double precipitation_amount, double relative_humidity, double wind_from_direction, double wind_speed)
        {
            Date = date;
            AirTemperature = air_temperature;
            PrecipitationAmount = precipitation_amount;
            RelativeHumidity = relative_humidity;
            WindFromDirection = wind_from_direction;
            WindSpeed = wind_speed;
        }
}