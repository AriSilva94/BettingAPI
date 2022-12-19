using AutoMapper;
using BettingAPI.Infrastructure.Service.Interfaces;
using BettingAPI.Infrastructure.Service.Services.Championship;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BettingAPI.Infrastructure.Data.Query.Queries.v1.Championship
{
    public class ChampionshipListHandler : IRequestHandler<ChampionshipQueryList, List<ChampionshipRequest>>
    {
        private readonly IChampionshipApiService _championshipApiService;
        private readonly IMapper _mapper;

        public ChampionshipListHandler(
            IChampionshipApiService championshipApiService,
            IMapper mapper)
        {
            _championshipApiService = championshipApiService;
            _mapper = mapper;
        }

        public async Task<List<ChampionshipRequest>> Handle(ChampionshipQueryList request, CancellationToken cancellationToken)
        {
            var championships = await _championshipApiService.GetAllChampionshipAsync();

            var result = _mapper.Map<List<ChampionshipResponse>, List<ChampionshipRequest>>(championships);

            return championships.Select(item => _mapper.Map<ChampionshipResponse, ChampionshipRequest>(item)).ToList();
        }
    }
}
