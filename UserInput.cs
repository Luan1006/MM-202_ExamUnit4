namespace Luan1006.MM202.ExamUnit4
{
    public class UserInput
    {
        private static double GetUserInput(string prompt)
        {
            Console.WriteLine(prompt);
            double userInput;
            while (!double.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine(Constants.invalidInput);
            }

            return userInput;
        }

        public static double GetAirTemperature()
        {
            return GetUserInput(Constants.airTemperaturePrompt);
        }

        public static double GetRelativeHumidity()
        {
            return GetUserInput(Constants.relativeHumidityPrompt);
        }

        public static double GetWindFromDirection()
        {
            return GetUserInput(Constants.windFromDirectionPrompt);
        }

        public static double GetWindSpeed()
        {
            return GetUserInput(Constants.windSpeedPrompt);
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