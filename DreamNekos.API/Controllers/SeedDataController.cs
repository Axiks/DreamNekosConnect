using DreamNekos.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DreamNekos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SeedDataController : ControllerBase
    {
        private readonly SeederService _seeder;

        public SeedDataController(SeederService seeder)
        {
            _seeder = seeder;
        }

        [HttpPost]
        public void RunSeed()
        {
            _seeder.RunSeed();
        }
    }
}
