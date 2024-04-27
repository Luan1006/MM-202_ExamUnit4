using System.Text.Json;

namespace Luan1006.MM202.ExamUnit4
{
    public class WeatherLog
    {
        public List<WeatherData> Data { get; set; } = new List<WeatherData>();

        public WeatherLog()
        {
            LoadFromJson("weatherlog.json");
        }

        public void AddData(WeatherData data)
        {
            Data.Add(data);
        }

        public WeatherData GetData(DateTime date)
        {
            return Data.FirstOrDefault(d => d.Date.Date == date.Date);
        }

        private void LoadFromJson(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            Data = JsonSerializer.Deserialize<List<WeatherData>>(jsonData);
        }

        public void SaveToJson(string filePath)
        {
            string jsonData = JsonSerializer.Serialize(Data);
            File.WriteAllText(filePath, jsonData);
        }
    }
}