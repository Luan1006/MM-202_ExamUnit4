namespace Luan1006.MM202.ExamUnit4
{
    public class WeatherData
    {
        public DateTime Date { get; set; }
        public double Temperature { get; set; }

        // Constructor
        public WeatherData(DateTime date, double temperature)
        {
            Date = date;
            Temperature = temperature;
        }
    }
}