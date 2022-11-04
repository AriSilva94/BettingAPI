using AutoMapper;
using BettingAPI.Infrastructure.Data.Query.Championship;
using BettingAPI.Infrastructure.Data.Query.Queries.v1.Championship;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BettingAPI.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public class ChampionshipController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ChampionshipController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetChampionshipAsync()
        {
            var response = await _mediator.Send(new GetChampionshipQuery());
            return Ok(response);
        }
    }
}
