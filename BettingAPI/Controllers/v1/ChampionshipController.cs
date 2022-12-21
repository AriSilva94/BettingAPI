using BettingAPI.Infrastructure.Data.Query.Queries.v1.Championship;
using BettingAPI.Infrastructure.Data.Query.Queries.v1.Table;
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

        public ChampionshipController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChampionships()
        {
            var response = await _mediator.Send(new ChampionshipQueryList());
            return Ok(response);
        }

        [HttpGet, Route("championship/{id}")]
        public async Task<IActionResult> GetChampionshipById(string id)
        {
            var response = await _mediator.Send(new ChampionshipQueryBydId(id));
            return Ok(response);
        }

        [HttpGet, Route("/tabela/{id}")]
        public async Task<IActionResult> GetTableById(string id)
        {
            var response = await _mediator.Send(new TableQueryBydId(id));
            return Ok(response);
        }
    }
}
