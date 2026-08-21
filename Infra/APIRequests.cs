using Core;
using System.Net.Http.Json;
using System.Text.Json;

namespace Infra
{
    internal class APIRequests
    {
        private readonly HttpClient client;
        private readonly string baseUrl = "https://the-one-api.dev/v2";

        public APIRequests()
        {
            var token = Environment.GetEnvironmentVariable("AUTH_TOKEN") ?? string.Empty;
            if (token.Trim() == string.Empty)
            {
                throw new InvalidOperationException("Authorization token secret is not set.");
            }

            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }

        public async Task<List<Character>> GetCharactersAsync()
        {
            var response = await client.GetAsync($"{baseUrl}/character");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadFromJsonAsync<Dictionary<string, object>?>();
            var characters = (content?["docs"] as JsonElement?)?.Deserialize<List<Character>>();

            return characters ?? [];
        }

        public async Task<List<Quote>> GetQuotesAsync() //Task<List<Quote>> GetQuotesAsync()
        {
            var response = await client.GetAsync($"{baseUrl}/quote");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadFromJsonAsync<Dictionary<string, object>?>();
            var quotes = (content?["docs"] as JsonElement?)?.Deserialize<List<Quote>>();

            return quotes ?? [];
        }
    }
}
