using BettingAPI.Infrastructure.Service.Interfaces;
using BettingAPI.Infrastructure.Service.Services.Championship;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BettingAPI.Infrastructure.Service.ServiceHandler.Championship
{
    public class ChampionshipApiServiceClient : IChampionshipApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ChampionshipApiServiceClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<ChampionshipResponse>> GetAllChampionshipAsync()
        {
            try
            {
                using var client = _httpClientFactory.CreateClient("base-url");
                var request = await client.GetAsync(client.BaseAddress + "/campeonatos");
                var content = await request.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ChampionshipResponse>>(content);

                return result;
            }
            catch (WebException ex)
            {
                throw new WebException("An error has occurred", ex);
            }
        }

        public async Task<ChampionshipResponse> GetChampionshipById(string id)
        {
            try
            {
                using var client = _httpClientFactory.CreateClient("base-url");
                var request = await client.GetAsync(client.BaseAddress + $"/campeonatos/{id}");
                var content = await request.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ChampionshipResponse>(content);

                return result;
            }
            catch (WebException ex)
            {
                throw new WebException("An error has occurred", ex);
            }
        }
    }
}
