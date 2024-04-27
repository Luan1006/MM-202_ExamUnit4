using System.Text.Json;

namespace Luan1006.MM202.ExamUnit4
{
    public class Program
    {
        public static void Main()
        {
            double latitude = 58.20; // grimstad latitude
            double longitude = 8.35; // grimstad longitude

            MetApiHandler metApiHandler = new MetApiHandler();
            JsonDocument data = metApiHandler.HandleRequest(latitude, longitude).Result;
            Console.WriteLine(data.RootElement.GetProperty("properties").GetProperty("timeseries")[0].GetProperty("data").GetProperty("instant").GetProperty("details").GetProperty("air_temperature").GetDouble());
            Console.WriteLine(data.RootElement.GetProperty("properties").GetProperty("timeseries")[0].GetProperty("data").GetProperty("instant").GetProperty("details").GetProperty("relative_humidity").GetDouble());
            Console.WriteLine(data.RootElement.GetProperty("properties").GetProperty("timeseries")[0].GetProperty("data").GetProperty("instant").GetProperty("details").GetProperty("wind_from_direction").GetDouble());
            Console.WriteLine(data.RootElement.GetProperty("properties").GetProperty("timeseries")[0].GetProperty("data").GetProperty("instant").GetProperty("details").GetProperty("wind_speed").GetDouble());
        }
    }
}