using AutoMapper;
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
            CreateMap<ChampionshipResponse, ChampionshipRequest>();
            CreateMap<Service.Services.Championship.EdicaoAtual, Queries.v1.Championship.EdicaoAtual>();
            CreateMap<Service.Services.Championship.FaseAtual, Queries.v1.Championship.FaseAtual>();
        }
    }
}
