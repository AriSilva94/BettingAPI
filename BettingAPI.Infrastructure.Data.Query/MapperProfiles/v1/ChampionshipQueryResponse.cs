using AutoMapper;
using BettingAPI.Infrastructure.Data.Query.Championship;
using BettingAPI.Infrastructure.Data.Query.Queries.v1.Championship;
using BettingAPI.Infrastructure.Service.Services.Championship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingAPI.Infrastructure.Data.Query.MapperProfiles.v1
{
    public class ChampionshipQueryResponse : Profile
    {
        public ChampionshipQueryResponse()
        {
            CreateMap<GetChampionshipServiceResponse, GetChampionshipQueryResponse>();
            CreateMap<Service.Services.Championship.EdicaoAtual, Championship.EdicaoAtual>();
            CreateMap<Service.Services.Championship.FaseAtual, Championship.FaseAtual>();
        }
    }
}
