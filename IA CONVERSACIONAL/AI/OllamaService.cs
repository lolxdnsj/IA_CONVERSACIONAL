using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IA_CONVERSACIONAL
{
    public class OllamaService
    {
        private readonly HttpClient _httpClient;

        public OllamaService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<string> GenerateResponse(string prompt)
        {
            var requestData = new
            {
                model = "mistral",
                prompt = prompt,
                stream = false
            };
            var json = JsonSerializer.Serialize(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:11434/api/generate", content);
            var responseString = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(responseString);
            return doc.RootElement.GetProperty("response").GetString();
        }
    }
}