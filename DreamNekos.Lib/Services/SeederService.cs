using DreamNekos.Core.Interface;
using DreamNekos.Core.Models.Parser;
using Newtonsoft.Json;
using System.Reflection;

namespace DreamNekos.Core.Services
{
    public class SeederService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IActivityTypeService _activityTypeService;
        private readonly IActivitySubTypeService _activitySubTypeService;
        private readonly IActivityService _activityService;
        private readonly ISkillService _skillService;

        private SeedData _data;

        public SeederService(ApplicationDbContext dbContext, IActivityTypeService activityTypeService, IActivitySubTypeService activitySubTypeService, IActivityService activityService, ISkillService skillService)
        {
            _dbContext = dbContext;
            _activityTypeService = activityTypeService;
            _activitySubTypeService = activitySubTypeService;
            _activityService = activityService;
            _skillService = skillService;
            LoadData();
        }

        private void LoadData()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data/SeedData.json");
            string json = File.ReadAllText(path);
            _data = JsonConvert.DeserializeObject<SeedData>(json);
        }

        public async Task RunSeed()
        {
            await SeedActivityTypes();
            await SeedActivitySubTypes();
            await SeedActivities();
            await SeedSkills();
        }

        private async Task SeedActivityTypes()
        {

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
