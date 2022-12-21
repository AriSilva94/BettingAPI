using BettingAPI.Infrastructure.Service.Interfaces;
using BettingAPI.Infrastructure.Service.Services.Championship;
using BettingAPI.Infrastructure.Service.Services.Table;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BettingAPI.Infrastructure.Service.ServiceHandler.Table
{
    public class TableApiServiceClient : ITableApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TableApiServiceClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<TableResponse> GetTableById(string id)
        {
            try
            {
                using var client = _httpClientFactory.CreateClient("base-url");
                var request = await client.GetAsync(client.BaseAddress + $"/tabela/{id}");
                var content = await request.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TableResponse>(content);

                return result;
            }
            catch (WebException ex)
            {
                throw new WebException("An error has occurred", ex);
            }
        }
    }
}
