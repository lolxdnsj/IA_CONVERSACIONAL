using System.Threading.Tasks;

namespace IA_CONVERSACIONAL
{
    public class ConversationServices
    {
        private readonly OllamaService _ollamaService;

        public ConversationServices()
        {
            _ollamaService = new OllamaService();
        }

        public async Task<string> ProcessInput(string input)
        {
            return await _ollamaService.GenerateResponse(input);
        }
    }
}