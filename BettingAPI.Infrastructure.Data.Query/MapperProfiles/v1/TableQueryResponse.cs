using AutoMapper;
using BettingAPI.Infrastructure.Data.Query.Queries.v1.Table;
using BettingAPI.Infrastructure.Service.Services.Table;

namespace BettingAPI.Infrastructure.Data.Query.MapperProfiles.v1
{
    public class TableQueryResponse : Profile
    {
        public TableQueryResponse()
        {
            CreateMap<TableResponse, TableRequest>();
            CreateMap<Service.Services.Table.Time, Queries.v1.Table.Time>();
        }
    }
}
