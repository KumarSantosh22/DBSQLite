
using System.Text.Json;

namespace DBSQLite.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public HttpService()
        {
            _client = new HttpClient();
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public void SetBaseUri(string baseUri)
        {
            _client.BaseAddress = new Uri(baseUri);
        }

        public async Task<TResponse> GetAsync<TResponse>(string endpoint)
        {
            HttpResponseMessage response = await _client.GetAsync(endpoint);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(responseContent);
            }
            TResponse data = JsonSerializer.Deserialize<TResponse>(responseContent, _options);
            return data;
        }
    }
}
