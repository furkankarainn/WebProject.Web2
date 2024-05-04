using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class HttpRequestHelper
    {
        private readonly HttpClient _client;

        public HttpRequestHelper(HttpClient client,IConfiguration configuration)
        {
            _client = client;
            _client.BaseAddress = new Uri(configuration["ApiConstants:baseLink"]);
        }

        public async Task<T> GetAsync<T>(string url,string? token=null)
        {
            if (!string.IsNullOrEmpty(token))
            {
                _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            }
            HttpResponseMessage response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                T model = JsonSerializer.Deserialize<T>(result,new JsonSerializerOptions { PropertyNameCaseInsensitive=true});
                return model;
            }
            else
            {
                throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");
            }
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest data,string? token=null)
        {
            if (!string.IsNullOrEmpty(token))
            {
                _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            }
            HttpResponseMessage response = await _client.PostAsync(url, new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                TResponse model = JsonSerializer.Deserialize<TResponse>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return model;
            }
            else
            {
                throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");
            }
        }
    }
}
