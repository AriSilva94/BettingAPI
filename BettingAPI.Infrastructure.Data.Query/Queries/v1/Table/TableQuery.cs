using MediatR;
using System.Collections.Generic;

namespace BettingAPI.Infrastructure.Data.Query.Queries.v1.Table
{
    public class TableQueryBydId : IRequest<TableRequest> 
    {
        public TableQueryBydId(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
