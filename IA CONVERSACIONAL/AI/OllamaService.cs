using System;
using System.Net.Http;
using System.Text;
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
            var url = "http://localhost:11434/api/generate";

            var json = "{ \"model\": \"mistral\", \"prompt\": \""
                       + prompt.Replace("\"", "\\\"") +
                       "\", \"stream\": false }";

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                return "Error al conectar con Ollama.";
            }

            var result = await response.Content.ReadAsStringAsync();

            return result; // Devuelve JSON crudo
        }
    }
}