using BettingAPI.Infrastructure.Service.Interfaces;
using BettingAPI.Infrastructure.Service.Services.Championship;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BettingAPI.Infrastructure.Service.ServiceHandler.Championship
{
    public class ChampionshipApiServiceClient : IChampionshipApiService
    {
        private readonly string _baseUrl;
        private readonly string _authorization;

        public ChampionshipApiServiceClient()
        {
            _authorization = "live_4f0d54926e5c544ffbf45006006e27";
            _baseUrl = "https://api.api-futebol.com.br/v1";
        }
        public async Task<List<GetChampionshipServiceResponse>> GetAllChampionshipAsync()
        {
            try
            {
                using var httpClient = new HttpClient();
                
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + _authorization);
                    var request = await httpClient.GetAsync(_baseUrl + "/campeonatos");
                    var content = await request.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<GetChampionshipServiceResponse>>(content);

                return result;
            }
            catch (WebException ex)
            {
                throw new WebException("An error has occurred");
            }
        }
    }
}
