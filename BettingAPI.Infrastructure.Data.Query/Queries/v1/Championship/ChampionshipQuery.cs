using MediatR;
using System.Collections.Generic;

namespace BettingAPI.Infrastructure.Data.Query.Queries.v1.Championship
{
    public class ChampionshipQueryList : IRequest<List<ChampionshipRequest>> { }
    public class ChampionshipQueryBydId : IRequest<ChampionshipRequest> 
    {
        public ChampionshipQueryBydId(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
