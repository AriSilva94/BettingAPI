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

        public ChampionshipApiServiceClient(HttpClient httpClient)
        {
            _authorization = "live_06b26b0954286ef021464d5bbd044c";
            _baseUrl = new RestClient("https://api.api-futebol.com.br/v1")
                .AddDefaultHeader(KnownHeaders.Authorization, $"Bearer {_authorization}");
        }
        public async Task<List<GetChampionshipServiceResponse>> GetAllChampionshipAsync()
        {
            try
            {
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
