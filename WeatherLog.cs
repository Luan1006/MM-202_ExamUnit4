namespace Luan1006.MM202.ExamUnit4
{
    public class WeatherLog
    {
        public List<WeatherData> Data { get; set; } = new List<WeatherData>();

        public void AddData(WeatherData data)
        {
            Data.Add(data);
        }

        public WeatherData GetData(DateTime date)
        {
            return Data.FirstOrDefault(d => d.Date.Date == date.Date);
        }
    }
}