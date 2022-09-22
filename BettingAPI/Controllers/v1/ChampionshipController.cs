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

        public ChampionshipController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetChampionshipAsync()
        {
            var response = await _mediator.Send(new GetChampionshipQuery());
            return Ok(response);
        }
    }
}
