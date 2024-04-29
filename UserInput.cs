using System.Reflection.Metadata;

namespace Luan1006.MM202.ExamUnit4
{
    public class UserInput
    {
        public static double GetAirTemperature()
        {
            Console.WriteLine(Constants.airTemperaturePrompt);
            double userAirTemperature;
            while (!double.TryParse(Console.ReadLine(), out userAirTemperature))
            {
                Console.WriteLine(Constants.invalidInput);
            }

            return userAirTemperature;
        }

        public static double GetRelativeHumidity()
        {
            Console.WriteLine(Constants.relativeHumidityPrompt);
            double userRelativeHumidity;
            while (!double.TryParse(Console.ReadLine(), out userRelativeHumidity))
            {
                Console.WriteLine(Constants.invalidInput);
            }

            return userRelativeHumidity;
        }

        public static double GetWindFromDirection()
        {
            Console.WriteLine(Constants.windFromDirectionPrompt);
            double userWindFromDirection;
            while (!double.TryParse(Console.ReadLine(), out userWindFromDirection))
            {
                Console.WriteLine(Constants.invalidInput);
            }

            return userWindFromDirection;
        }

        public static double GetWindSpeed()
        {
            Console.WriteLine(Constants.windSpeedPrompt);
            double userWindSpeed;
            while (!double.TryParse(Console.ReadLine(), out userWindSpeed))
            {
                Console.WriteLine(Constants.invalidInput);
            }

            return userWindSpeed;
        }

        public static WeatherData GetWeatherData(double latitude, double longitude)
        {
            double userAirTemperature = GetAirTemperature();
            double userRelativeHumidity = GetRelativeHumidity();
            double userWindFromDirection = GetWindFromDirection();
            double userWindSpeed = GetWindSpeed();

            return new WeatherData(DateTime.Now, longitude, latitude, userAirTemperature, userRelativeHumidity, userWindFromDirection, userWindSpeed);
        }
    }
}