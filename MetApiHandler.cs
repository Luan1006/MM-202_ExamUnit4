using System.Net;
using System.Text.Json;
using System.Globalization;

namespace Luan1006.MM202.ExamUnit4
{
    public class MetApiHandler
    {
        private string sitename = "https://github.com/Luan1006";
        private string locationForecastUrl = "https://api.met.no/weatherapi/locationforecast/2.0/compact";
        private HttpClient client;
        private DateTimeOffset lastModified;
        private DateTimeOffset expires;
        private JsonDocument storedData;

        public MetApiHandler()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd($"MM-202_ExamUnit4/1.0 ({sitename})");
        }

        public async Task<JsonDocument> HandleRequest(double latitude, double longitude)
        {
            if (storedData != null && DateTimeOffset.UtcNow <= expires)
            {
                return storedData;
            }

            client.DefaultRequestHeaders.IfModifiedSince = lastModified;

            string requestUrl = $"{locationForecastUrl}?lat={latitude.ToString(CultureInfo.InvariantCulture)}&lon={longitude.ToString(CultureInfo.InvariantCulture)}";

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
    }
}