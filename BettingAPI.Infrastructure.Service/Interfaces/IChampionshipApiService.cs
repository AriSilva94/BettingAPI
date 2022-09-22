using BettingAPI.Infrastructure.Service.Services.Championship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingAPI.Infrastructure.Service.Interfaces
{
    public interface IChampionshipApiService
    {
        Task<GetChampionshipServiceResponse> GetAllChampionshipAsync();
    }
}
