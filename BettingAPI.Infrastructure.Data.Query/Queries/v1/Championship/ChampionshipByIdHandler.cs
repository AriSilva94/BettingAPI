using AutoMapper;
using BettingAPI.Infrastructure.Service.Interfaces;
using BettingAPI.Infrastructure.Service.Services.Championship;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BettingAPI.Infrastructure.Data.Query.Queries.v1.Championship
{
    public class ChampionshipByIdHandler : IRequestHandler<ChampionshipQueryBydId, ChampionshipRequest>
    {
        private readonly IChampionshipApiService _championshipApiService;
        private readonly IMapper _mapper;

        public ChampionshipByIdHandler(
            IChampionshipApiService championshipApiService,
            IMapper mapper)
        {
            _championshipApiService = championshipApiService;
            _mapper = mapper;
        }

        public async Task<ChampionshipRequest> Handle(ChampionshipQueryBydId request, CancellationToken cancellationToken)
        {
            var championship = await _championshipApiService.GetChampionshipById(request.Id);

            var result = _mapper.Map<ChampionshipResponse, ChampionshipRequest>(championship);

            return result;
        }
    }
}
