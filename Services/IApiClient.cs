using System.Collections.Generic;
using System.Threading.Tasks;
using TriviaGame.Models;

namespace TriviaGame.Services
{
    public interface IApiClient
    {
        Task<IEnumerable<TriviaCategory>> GetCategoriesAsync();
        Task<IEnumerable<Result>> GetQuestionsAsync();
        Task<IEnumerable<Result>> GetQuestionsAsync(QueryOptions options);
    }
}