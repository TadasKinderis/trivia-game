using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TriviaGame.Models;

namespace TriviaGame.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;
        private string _token;
        private const string _tokenUrl = "api_token.php?command=request";
        private const string _categoriesUrl = "api_category.php";

        public ApiClient()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(@"https://opentdb.com/")
            };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            var json = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(json);
            GetTokenAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<TriviaCategory>> GetCategoriesAsync()
        {
            using (var response = _httpClient.GetStringAsync(_categoriesUrl))
            {
                var categories = JsonSerializer.Deserialize<TriviaCategoryCollection>(await response);
                return categories.TriviaCategories;
            }
        }

        public async Task<IEnumerable<Result>> GetQuestionsAsync(QueryOptions options)
        {
            string query = GetQueryString(options);
            using (var response = _httpClient.GetStringAsync(query))
            {
                var queryResponse = JsonSerializer.Deserialize<QueryResponse>(await response);
                return queryResponse.Results;
            }
        }

        public Task<IEnumerable<Result>> GetQuestionsAsync()
        {
            return GetQuestionsAsync(new QueryOptions());
        }

        private string GetQueryString(QueryOptions options)
        {
            var result = new StringBuilder("api.php?");
            var (Amount, Category, Difficulty, MultipleChoice) = options;

            if (Amount != null)
            {
                if (Amount <= 50)
                {
                    if (Amount > 0)
                    {
                        result.Append($"amount={Amount}");
                    }
                    else
                    {
                        result.Append("amount=1");
                    }
                }
                else
                {
                    result.Append("amount=50");
                }
            }
            else
            {
                result.Append("amount=1");
            }

            if (Category != null)
            {
                result.Append($"&category={Category.Id}");
            }

            if (Difficulty != Difficulty.All)
            {
                result.Append($"&difficulty={Difficulty.ToString().ToLower()}");
            }

            if (MultipleChoice != null)
            {
                result.Append($"&type={(MultipleChoice ?? false ? "multiple" : "boolean")}");
            }

            return result.ToString();
        }

        private async Task GetTokenAsync()
        {
            using (var response = _httpClient.GetStringAsync(_tokenUrl))
            {
                var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(await response);
                _token = tokenResponse.Token;
            }
        }
    }
}
