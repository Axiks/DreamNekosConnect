using DreamNekos.Core.Services;
using DreamNekosConnect.Lib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DreamNekos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SeedDataController : ControllerBase
    {
        private readonly SeederService _seeder;
        private readonly ApplicationDbContext _dbContext;

        public SeedDataController(SeederService seeder, ApplicationDbContext dbContext)
        {
            _seeder = seeder;
            _dbContext = dbContext;
        }

        [HttpPost]
        public void RunSeed()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
            _dbContext.Database.Migrate();

            _seeder.RunSeed();
        }
    }
}
