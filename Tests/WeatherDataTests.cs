using Xunit;
using Luan1006.MM202.ExamUnit4;

namespace WeatherDataTests
{
    public class WeatherDataTest
    {
        [Fact]
        public void Constructor_SetsValuesCorrectly()
        {
            // Arrange
            DateTime date = DateTime.Now;
            double longitude = 10.0;
            double latitude = 20.0;
            double airTemperature = 30.0;
            double relativeHumidity = 40.0;
            double windFromDirection = 50.0;
            double windSpeed = 60.0;

            // Act
            var weatherData = new WeatherData(date, longitude, latitude, airTemperature, relativeHumidity, windFromDirection, windSpeed);

            // Assert
            Assert.Equal(date, weatherData.Date);
            Assert.Equal(longitude, weatherData.Longitude);
            Assert.Equal(latitude, weatherData.Latitude);
            Assert.Equal(airTemperature, weatherData.AirTemperature);
            Assert.Equal(relativeHumidity, weatherData.RelativeHumidity);
            Assert.Equal(windFromDirection, weatherData.WindFromDirection);
            Assert.Equal(windSpeed, weatherData.WindSpeed);
        }
    }
}