using BettingAPI.Infrastructure.Service.Services.Championship;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BettingAPI.Infrastructure.Service.Interfaces
{
    public interface IChampionshipApiService
    {
        Task<List<ChampionshipResponse>> GetAllChampionshipAsync();
        Task<ChampionshipResponse> GetChampionshipById(string id);
    }
}
