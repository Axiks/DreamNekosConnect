using DreamNekos.API.Response;
using DreamNekos.API.Response.Interest;
using DreamNekos.Core.Models;
using DreamNekosConnect.Lib.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace DreamNekos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private StatisticService _statisticService;
        public StatisticController(StatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(StatisticResponse))]
        public async Task<IActionResult> GetStatistic()
        {
            var response = new StatisticResponse() { 
                UserCount = _statisticService.TotalUsers(),
                InterestPopularityByType = await _statisticService.PopularityByTypeAsync(),
            };
            return Ok(response);
        }
    }
}
