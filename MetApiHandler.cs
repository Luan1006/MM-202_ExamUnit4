using System.Net;
using System.Text.Json;
using System.Globalization;

namespace Luan1006.MM202.ExamUnit4
{
    public class MetApiHandler
    {
        private WeatherData weatherData;
        private string sitename = Constants.sitename;
        private string locationForecastUrl = Constants.locationForecastUrl;
        private HttpClient client;
        private DateTimeOffset lastModified;
        private DateTimeOffset expires;
        private JsonDocument storedData;
        private double Latitude { get; set; }
        private double Longitude { get; set; }

        public MetApiHandler(double latitude, double longitude)
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd(string.Format(Constants.RequestHeader, sitename));
            Latitude = latitude;
            Longitude = longitude;
            HandleRequest().Wait();
            client.Dispose();
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

            string requestUrl = string.Format(Constants.requestUrl, locationForecastUrl, Latitude.ToString(CultureInfo.InvariantCulture), Longitude.ToString(CultureInfo.InvariantCulture));

            HttpResponseMessage response = await client.GetAsync(requestUrl);

            if (response.StatusCode == HttpStatusCode.NotModified)
            {
                return storedData;
            }

            if (response.IsSuccessStatusCode)
            {
                lastModified = response.Content.Headers.LastModified ?? DateTimeOffset.UtcNow;

                if (response.Headers.TryGetValues(Constants.expires, out IEnumerable<string> values))
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

            throw new Exception(string.Format(Constants.requestFailed, response.StatusCode));
        }

        private double GetAirTemperature()
        {
            return storedData.RootElement.GetProperty(Constants.properties).GetProperty(Constants.timeseries)[0].GetProperty(Constants.data).GetProperty(Constants.instant).GetProperty(Constants.details).GetProperty(Constants.air_temperature).GetDouble();
        }

        private double GetRelativeHumidity()
        {
            return storedData.RootElement.GetProperty(Constants.properties).GetProperty(Constants.timeseries)[0].GetProperty(Constants.data).GetProperty(Constants.instant).GetProperty(Constants.details).GetProperty(Constants.relative_humidity).GetDouble();
        }

        private double GetWindFromDirection()
        {
            return storedData.RootElement.GetProperty(Constants.properties).GetProperty(Constants.timeseries)[0].GetProperty(Constants.data).GetProperty(Constants.instant).GetProperty(Constants.details).GetProperty(Constants.wind_from_direction).GetDouble();
        }

        private double GetWindSpeed()
        {
            return storedData.RootElement.GetProperty(Constants.properties).GetProperty(Constants.timeseries)[0].GetProperty(Constants.data).GetProperty(Constants.instant).GetProperty(Constants.details).GetProperty(Constants.wind_speed).GetDouble();
        }

        private DateTime GetDateTime()
        {
            return storedData.RootElement.GetProperty(Constants.properties).GetProperty(Constants.timeseries)[0].GetProperty(Constants.time).GetDateTime();
        }
    }
}