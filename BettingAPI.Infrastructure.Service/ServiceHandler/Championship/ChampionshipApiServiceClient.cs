using BettingAPI.Infrastructure.Service.Interfaces;
using BettingAPI.Infrastructure.Service.Services.Championship;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BettingAPI.Infrastructure.Service.ServiceHandler.Championship
{
    public class ChampionshipApiServiceClient : IChampionshipApiService
    {
        readonly string _baseUrl;
        readonly string _authorization;
        private readonly HttpClient _httpClient;

        public ChampionshipApiServiceClient(HttpClient httpClient)
        {
            _baseUrl = "https://api.api-futebol.com.br/v1";
            _authorization = "test_ed026f9bbe31c19594fc76668c539e";
            _httpClient = httpClient;
        }
        public async Task<GetChampionshipServiceResponse> GetAllChampionshipAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorization);
            var response = await _httpClient.GetAsync($"{_baseUrl}/campeonatos");

            var serializer = new JsonSerializer();
            using var stream = await response.Content.ReadAsStreamAsync();
            using var streamReader = new StreamReader(stream);
            using var jsonTextReader = new JsonTextReader(streamReader);

            return serializer.Deserialize<GetChampionshipServiceResponse>(jsonTextReader);
        }
    }
}
