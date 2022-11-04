using BettingAPI.Infrastructure.Data.Query.Championship;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingAPI.Infrastructure.Data.Query.Queries.v1.Championship
{
    public class GetChampionshipQuery : IRequest<List<GetChampionshipQueryResponse>>
    {
    }
}
