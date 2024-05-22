using iLG.WPF.Infrastructure.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace iLG.WPF.Infrastructure.Repositories
{
    public class BaseHttpRepository<T> : IBaseHttpRepository<T> where T : class
    {
        private readonly HttpClient _httpClient;
        public BaseHttpRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task DeleteAsync(string url)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Request to '{url}' failed with status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while making DELETE request: {ex.Message}");
                throw;
            }
        }

        public async Task<T> GetAsync(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Request to '{url}' failed with status code: {response.StatusCode}");
                }
                var result = await response.Content.ReadAsStringAsync();
                var deserializedResult = JsonSerializer.Deserialize<T>(result);
                if (deserializedResult == null)
                {
                    throw new Exception($"The result from the URL '{url}' is null.");
                }

                return deserializedResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while making GET request: {ex.Message}");
                throw;
            }
        }

        public async Task<T> PostAsync(string url, T entity)
        {
            try
            {
                var content = new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Request to '{url}' failed with status code: {response.StatusCode}");
                }

                var result = await response.Content.ReadAsStringAsync();
                var deserializedResult = JsonSerializer.Deserialize<T>(result);
                if (deserializedResult == null)
                {
                    throw new Exception($"The result from the URL '{url}' is null.");
                }

                return deserializedResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while making POST request: {ex.Message}");
                throw;
            }
        }

        public async Task<T> PutAsync(string url, T entity)
        {
            try
            {
                var content = new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(url, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Request to '{url}' failed with status code: {response.StatusCode}");
                }
                var result = await response.Content.ReadAsStringAsync();
                var deserializedResult = JsonSerializer.Deserialize<T>(result);
                if (deserializedResult == null)
                {
                    throw new Exception($"The result from the URL '{url}' is null.");
                }

                return deserializedResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while making PUT request: {ex.Message}");
                throw;
            }
        }
    }
}
