using DreamNekos.Core.Models.Parser;
using DreamNekosConnect.Lib.Services;
using Newtonsoft.Json;
using System.Reflection;

namespace DreamNekos.Core.Services
{
    public class SeederService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly InterestTypeService _interestTypeService;
        private readonly InterestService _interestService;

        private SeedData _data;

        public SeederService(ApplicationDbContext dbContext, InterestTypeService interestTypeService, InterestService interestService)
        {
            _dbContext = dbContext;
            _interestTypeService = interestTypeService;
            _interestService = interestService;
            LoadData();
        }

        private void LoadData()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data/SeedData.json");
            string json = File.ReadAllText(path);
            _data = JsonConvert.DeserializeObject<SeedData>(json);
        }

        public async void RunSeed()
        {
            SeedInetestTypes();
            SeedInterests();
        }

        private void SeedInetestTypes()
        {
            List<string> interestTypes = _data.Interests.Select(x => x[1]).Distinct().ToList();

            foreach (var interestType in interestTypes)
            {
                _interestTypeService.CreateInterestType(interestType);
            }
        }

        private void SeedInterests()
        {
            var interestTypes = _interestTypeService.GetAllInterestType();

            foreach (var interest in _data.Interests)
            {
                var name = interest[0];
                var typeName = interest[1];
                var interestId = interestTypes.Where(x => x.Name == typeName).Select(x => x.Id).FirstOrDefault();
                _interestService.CreateInterest(name, interestId);
            }
        }

    }
}
