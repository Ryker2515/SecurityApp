﻿using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using SecurityApp.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace SecurityApp.DAL
{
    public class ManufacturerService : IManufacturer
    {
        private readonly IMemoryCache _memoryCache;

        public ManufacturerService(IMemoryCache memoryCache) 
        {
            _memoryCache = memoryCache;
        }
        public async Task<List<ManufacturerDto>> getList(int pageNumber, string filter, string search)
        {
            List<ManufacturerDto> manufacturerDto = new List<ManufacturerDto>();

            try
            {
                string token = _memoryCache.Get<string>("AuthToken") ?? "";
                if(string.IsNullOrEmpty(token))
                {
                    token = await getToken();
                    _memoryCache.Set("AuthToken", token, TimeSpan.FromMinutes(18)); // Set the token in the cache for 30 minutes
                }
                
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var apiUrl = $"http://localhost:5263/api/WeatherForecast/GetManufacturersData?PageNumber={pageNumber}" +
                        $"&Filter={filter}&SearchText={search}"; // Replace with your API URL

                var response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var manufacturerDto1 = JsonSerializer.Deserialize<List<ManufacturerDto>>(content);
                    return manufacturerDto1 ?? manufacturerDto;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occur while getting getList data");
            }

            return manufacturerDto;
        }
        private async Task<string> getToken()
        {
            try
            {
                using var client = new HttpClient();
                var apiUrl = $"http://localhost:5263/api/WeatherForecast/GenerateToken"; // Replace with your API URL

                var response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    return(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occur while getting getList data");
            }
            
            return "";
        }
    }
}
