using BettingAPI.Infrastructure.Data.Query.Championship;
using BettingAPI.Infrastructure.Service.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BettingAPI.Infrastructure.Data.Query.Queries.v1.Championship
{
    public class GetChampionshipQueryHandler : IRequestHandler<GetChampionshipQuery, GetChampionshipQueryResponse>
    {
        private readonly IChampionshipApiService _championshipApiService;
        public GetChampionshipQueryHandler(IChampionshipApiService championshipApiService)
        {
            _championshipApiService = championshipApiService;
        }

        public async Task<GetChampionshipQueryResponse> Handle(GetChampionshipQuery request, CancellationToken cancellationToken)
        {
            var response = await _championshipApiService.GetAllChampionshipAsync();

            return new GetChampionshipQueryResponse();
        }
    }
}
