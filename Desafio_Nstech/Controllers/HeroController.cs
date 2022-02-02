using Desafio_Nstech.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Nstech.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeroController : ControllerBase
    {

        private IHeroService _heroService;
        private readonly ILogger<HeroController> _logger;

        public HeroController(ILogger<HeroController> logger, IHeroService heroService)
        {
            _logger = logger;
            _heroService = heroService;
        }

        [HttpGet("/")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_heroService.FindAll());
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("/powerstat/{powerstat}")]
        public IActionResult Get(string powerstat)
        {
            try
            {
                if (powerstat != "intelligence" && powerstat != "strength" && powerstat != "speed" && powerstat != "durability" && powerstat != "power" && powerstat != "combat")
                {
                    return BadRequest("Validation fails");
                }
                else
                {
                    return Ok(_heroService.FindByPowerStat(powerstat));
                }
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        } 
    }
}