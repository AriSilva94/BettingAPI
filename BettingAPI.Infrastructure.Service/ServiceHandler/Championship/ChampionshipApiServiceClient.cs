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
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BettingAPI.Infrastructure.Service.ServiceHandler.Championship
{
    public class ChampionshipApiServiceClient : IChampionshipApiService
    {
        readonly RestClient _baseUrl;
        readonly string _authorization;

        public ChampionshipApiServiceClient()
        {
            _authorization = "test_494299fadd099ba29bdfcb2391dace";
            _baseUrl = new RestClient("https://api.api-futebol.com.br/v1")
                .AddDefaultHeader(KnownHeaders.Authorization, $"Bearer {_authorization}");
        }
        public async Task<List<GetChampionshipServiceResponse>> GetAllChampionshipAsync()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("bearer", _authorization);
                    var request = await httpClient.GetAsync(_baseUrl + "/campeonatos");
                    var content = await request.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<GetChampionshipServiceResponse>>(content);
                }
                var response = await _baseUrl.GetJsonAsync<List<GetChampionshipServiceResponse>>("/campeonatos");

                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
