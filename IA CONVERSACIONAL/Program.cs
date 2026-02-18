using System;
using System.Threading.Tasks;

namespace IA_CONVERSACIONAL
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "AI Conversacional";
            Console.WriteLine("=== AI Conversacional ===");
            Console.WriteLine("Type 'exit' to close.\n");
            
            var conversationService = new ConversationServices();

            while (true)
            {
                Console.Write("You: ");
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    continue;

                if (input.ToLower() == "exit")
                    break;

                var response = await conversationService.ProcessInput(input);
                Console.WriteLine($"AI: {response}\n");
            }
        }
    }
}
