using AutoMapper;
using BettingAPI.Infrastructure.Service.Interfaces;
using BettingAPI.Infrastructure.Service.Services.Table;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace BettingAPI.Infrastructure.Data.Query.Queries.v1.Table
{
    public class TableByIdHandler : IRequestHandler<TableQueryBydId, TableRequest>
    {
        private readonly ITableApiService _tableApiService;
        private readonly IMapper _mapper;

        public TableByIdHandler(
            ITableApiService tableApiService,
            IMapper mapper)
        {
            _tableApiService = tableApiService;
            _mapper = mapper;
        }

        public async Task<TableRequest> Handle(TableQueryBydId request, CancellationToken cancellationToken)
        {
            var championship = await _tableApiService.GetTableById(request.Id);

            var result = _mapper.Map<TableResponse, TableRequest>(championship);

            return result;
        }
    }
}

