namespace Luan1006.MM202.ExamUnit4
{
    public class UserInput
    {
        public static double GetAirTemperature()
        {
            Console.WriteLine("Enter the air temperature: ");
            double userAirTemperature;
            while (!double.TryParse(Console.ReadLine(), out userAirTemperature))
            {
                Console.WriteLine("Invalid input, please try again.");
            }

            return userAirTemperature;
        }

        public static double GetRelativeHumidity()
        {
            Console.WriteLine("Enter the relative humidity: ");
            double userRelativeHumidity;
            while (!double.TryParse(Console.ReadLine(), out userRelativeHumidity))
            {
                Console.WriteLine("Invalid input, please try again.");
            }

            return userRelativeHumidity;
        }

        public static double GetWindFromDirection()
        {
            Console.WriteLine("Enter the wind from direction: ");
            double userWindFromDirection;
            while (!double.TryParse(Console.ReadLine(), out userWindFromDirection))
            {
                Console.WriteLine("Invalid input, please try again.");
            }

            return userWindFromDirection;
        }

        public static double GetWindSpeed()
        {
            Console.WriteLine("Enter the wind speed: ");
            double userWindSpeed;
            while (!double.TryParse(Console.ReadLine(), out userWindSpeed))
            {
                Console.WriteLine("Invalid input, please try again.");
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