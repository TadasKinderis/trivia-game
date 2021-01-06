using Microsoft.Extensions.DependencyInjection;
using TriviaGame.Models;
using TriviaGame.Services;

namespace TriviaGame
{
    class Program
    {
        private static IApiClient _api;
        // random comment

        public static void Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IApiClient, ApiClient>()
                .BuildServiceProvider();
            _api = serviceProvider.GetService<IApiClient>();
            RunGame();
        }

        private static void RunGame()
        {
            // Examples
            // Single parameterless query
            var noparams = _api.GetQuestionsAsync().GetAwaiter().GetResult();

            // Get available categories
            var categories = _api.GetCategoriesAsync().GetAwaiter().GetResult();

            // Query with parameters
            var options = new QueryOptions()
            {
                Amount = 3,
                Category = new TriviaCategory() { Id = 11, Name = "Entertainment: Film" },
                Difficulty = Difficulty.Easy,
                MultipleChoice = true,
            };
            var questions = _api.GetQuestionsAsync(options).GetAwaiter().GetResult();
        }
    }
}
