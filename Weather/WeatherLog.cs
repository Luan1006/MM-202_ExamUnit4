using System.Text.Json;

namespace Luan1006.MM202.ExamUnit4
{
    public class WeatherLog
    {
        public List<WeatherData> Data { get; set; } = new List<WeatherData>();
        bool IsUser;

        public WeatherLog(bool isUser)
        {
            IsUser = isUser;
            if (IsUser)
            {
                LoadFromJson(Constants.WeatherLogFromUserPath);
            }
            else
            {
                LoadFromJson(Constants.WeatherLogFromAPIPath);
            }
        }

        public void AddData(WeatherData weatherData)
        {
            bool exists = false;
            WeatherData existingData = null;
        
            foreach (var wd in Data)
            {
                if (wd.Date.Date == weatherData.Date.Date)
                {
                    exists = true;
                    existingData = wd;
                    break;
                }
            }
        
            if (!exists)
            {
                Data.Add(weatherData);
            }
            else
            {
                if (UserConfirmsDataReplacement())
                {
                    Data.Remove(existingData);
                    Data.Add(weatherData);
                }
            }
        }
        
        private bool UserConfirmsDataReplacement()
        {
            Console.WriteLine(Constants.DataAlreadyExists);
            string answer = Console.ReadKey().KeyChar.ToString().ToLower();
        
            while (answer != Constants.y && answer != Constants.n)
            {
                Console.WriteLine(Constants.invalidInput);
                answer = Console.ReadKey().KeyChar.ToString().ToLower();
            }
        
            return answer == Constants.y;
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