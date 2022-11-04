using AutoMapper;
using BettingAPI.Infrastructure.Data.Query.Championship;
using BettingAPI.Infrastructure.Service.Interfaces;
using BettingAPI.Infrastructure.Service.Services.Championship;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BettingAPI.Infrastructure.Data.Query.Queries.v1.Championship
{
    public class GetChampionshipQueryHandler : IRequestHandler<GetChampionshipQuery, List<GetChampionshipQueryResponse>>
    {
        private readonly IChampionshipApiService _championshipApiService;
        private readonly IMapper _mapper;
        public GetChampionshipQueryHandler(IChampionshipApiService championshipApiService,
                                           IMapper mapper)
        {
            _championshipApiService = championshipApiService;
            _mapper = mapper;
        }

        public async Task<List<GetChampionshipQueryResponse>> Handle(GetChampionshipQuery request, CancellationToken cancellationToken)
        {
            var championships = await _championshipApiService.GetAllChampionshipAsync();

            var result = _mapper.Map<List<GetChampionshipServiceResponse>, List<GetChampionshipQueryResponse>>(championships);

            return championships.Select(item => _mapper.Map<GetChampionshipServiceResponse, GetChampionshipQueryResponse>(item)).ToList();
        }

    }
}
