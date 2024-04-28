using System.Net;
using System.Text.Json;
using System.Globalization;
using System.Dynamic;

namespace Luan1006.MM202.ExamUnit4
{
    public class MetApiHandler
    {
        private WeatherData weatherData;
        private string sitename = "https://github.com/Luan1006";
        private string locationForecastUrl = "https://api.met.no/weatherapi/locationforecast/2.0/compact";
        private HttpClient client;
        private DateTimeOffset lastModified;
        private DateTimeOffset expires;
        private JsonDocument storedData;
        private double Latitude { get; set; }
        private double Longitude { get; set; }

        public MetApiHandler(double latitude, double longitude)
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd($"MM-202_ExamUnit4/1.0 ({sitename})");
            Latitude = latitude;
            Longitude = longitude;
            HandleRequest().Wait();
        }

        public WeatherData GetWeatherData()
        {
            weatherData = new WeatherData(GetDateTime(), Longitude, Latitude, GetAirTemperature(), GetRelativeHumidity(), GetWindFromDirection(), GetWindSpeed());
            return weatherData;
        }

        private async Task<JsonDocument> HandleRequest()
        {
            if (storedData != null && DateTimeOffset.UtcNow <= expires)
            {
                return storedData;
            }

            client.DefaultRequestHeaders.IfModifiedSince = lastModified;

            string requestUrl = $"{locationForecastUrl}?lat={Latitude.ToString(CultureInfo.InvariantCulture)}&lon={Longitude.ToString(CultureInfo.InvariantCulture)}";

            HttpResponseMessage response = await client.GetAsync(requestUrl);

            if (response.StatusCode == HttpStatusCode.NotModified)
            {
                return storedData;
            }

            if (response.IsSuccessStatusCode)
            {
                lastModified = response.Content.Headers.LastModified ?? DateTimeOffset.UtcNow;

                if (response.Headers.TryGetValues("Expires", out System.Collections.Generic.IEnumerable<string> values))
                {
                    string expiresValue = values.FirstOrDefault();
                    DateTimeOffset.TryParse(expiresValue, out expires);
                }
                else
                {
                    expires = DateTimeOffset.UtcNow.AddHours(1);
                }

                string json = await response.Content.ReadAsStringAsync();
                storedData = JsonDocument.Parse(json);

                return storedData;
            }

            throw new Exception($"Request failed with status code {response.StatusCode}");
        }

        private double GetAirTemperature()
        {
            return storedData.RootElement.GetProperty("properties").GetProperty("timeseries")[0].GetProperty("data").GetProperty("instant").GetProperty("details").GetProperty("air_temperature").GetDouble();
        }

        private double GetRelativeHumidity()
        {
            return storedData.RootElement.GetProperty("properties").GetProperty("timeseries")[0].GetProperty("data").GetProperty("instant").GetProperty("details").GetProperty("relative_humidity").GetDouble();
        }

        private double GetWindFromDirection()
        {
            return storedData.RootElement.GetProperty("properties").GetProperty("timeseries")[0].GetProperty("data").GetProperty("instant").GetProperty("details").GetProperty("wind_from_direction").GetDouble();
        }

        private double GetWindSpeed()
        {
            return storedData.RootElement.GetProperty("properties").GetProperty("timeseries")[0].GetProperty("data").GetProperty("instant").GetProperty("details").GetProperty("wind_speed").GetDouble();
        }

        private DateTime GetDateTime()
        {
            return storedData.RootElement.GetProperty("properties").GetProperty("timeseries")[0].GetProperty("time").GetDateTime();
        }


    }
}