using DreamNekos.API.Helpers;
using DreamNekos.Core;
using DreamNekos.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DreamNekos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly SeederService _seeder;
        private readonly ApplicationDbContext _dbContext;

        public AdminController(SeederService seeder, ApplicationDbContext dbContext)
        {
            _seeder = seeder;
            _dbContext = dbContext;
        }

        [ApiKey]
        [HttpPost("RunSeed")]
        public void RunSeed()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
            _dbContext.Database.Migrate();

            _seeder.RunSeed();
        }
    }
}
