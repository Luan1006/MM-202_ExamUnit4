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
                LoadFromJson("JsonFiles/WeatherLogFromUser.json");
            }
            else
            {
                LoadFromJson("JsonFiles/WeatherLogFromAPI.json");
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
                Console.WriteLine("Data for this date already exists in the log, do you want to overwrite it? (y/n)");
                string answer = Console.ReadKey().KeyChar.ToString().ToLower();

                while (answer != "y" && answer != "n")
                {
                    Console.WriteLine("Invalid input, please try again.");
                    answer = Console.ReadKey().KeyChar.ToString().ToLower();
                }

                if (answer == "y")
                {
                    Data.Remove(existingData);
                    Data.Add(weatherData);
                }
            }
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