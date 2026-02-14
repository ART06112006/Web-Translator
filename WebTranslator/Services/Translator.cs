using Newtonsoft.Json;
using System.Text;
using WebTranslator.Models;

namespace WebTranslator.Services
{
    public class Translator
    {
        private static readonly string key = "F9JYJsEE9fLeIpzbhKPqB20LDYt5SosCvFBjUFC9QQsnMIZvCe6fJQQJ99AKACBsN54XJ3w3AAAbACOGx6D7";
        private static readonly string endpoint = "https://api.cognitive.microsofttranslator.com/";

        // location, also known as region.
        // required if you're using a multi-service or regional (not global) resource. It can be found in the Azure portal on the Keys and Endpoint page.
        private static readonly string location = "canadacentral";

        public async Task<string> TranslateAsync(string text, string from = "en", string to = "en")
        {
            // Input and output languages are defined as parameters.
            string route = $"/translate?api-version=3.0&from={from}&to={to}";
            object[] body = new object[] { new { Text = text } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                // Build the request.
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", key);
                // location required if you're using a multi-service or regional (not global) resource.
                request.Headers.Add("Ocp-Apim-Subscription-Region", location);

                // Send the request and get response.
                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                // Read response as a string.
                return JsonConvert.DeserializeObject<Root>(await response.Content.ReadAsStringAsync())?.FirstOrDefault()?.Translations?.FirstOrDefault()?.Text;
            }
        }
    }
}
