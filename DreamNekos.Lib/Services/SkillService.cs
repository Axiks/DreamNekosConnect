using DreamNekos.API.Helpers;
using DreamNekos.Core.Entities;
using DreamNekos.Core.Entities.Activity;
using DreamNekos.Core.Interface;
using DreamNekos.Core.Models.DTO.Skill;
using Microsoft.EntityFrameworkCore;

namespace DreamNekos.Core.Services
{
    public class SkillService : ISkillService
    {
        private readonly string _notFoundException = "A skill with such an ID does not exist.";
        private readonly string _activityNotFoundException = "A activity with such an ID does not exist.";

        private ApplicationDbContext _dbContext { get; set; }
        public SkillService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }


        public async Task<SkillEntity> GetSkillById(Guid SkillId)
        {
            var result = await _dbContext.Skill
                .Include(x => x.RelatedActivities)
                .FirstOrDefaultAsync(x => x.Id == SkillId);
            if (result == null) throw new ElementNotFoundException(_notFoundException);
            return result;
        }

        public async Task<List<SkillEntity>> GetAllSkill()
        {
            var result = await _dbContext.Skill
                .Include(x => x.RelatedActivities)
                .ToListAsync();
            return result;
        }

        public async Task<SkillEntity> CreateSkill(CreateSkillDTO create)
        {
            var relatedActivites = new List<ActivityEntity>();

            foreach (var id in create.RelatedActivitiesId)
            {
                var activity = await _dbContext.Activity
                .FirstOrDefaultAsync(x => x.Id == id);

                if (activity == null) throw new ElementNotFoundException(_activityNotFoundException);
                relatedActivites.Add(activity);
            }

            var newEntity = new SkillEntity()
            {
                Name = create.Name,
                SkillType = create.SkillType,
                RelatedActivities = relatedActivites
            };

            await _dbContext.AddAsync(newEntity);
            await _dbContext.SaveChangesAsync();
            return newEntity;
        }

        public async Task<SkillEntity> UpdateSkill(Guid SkillId, UpdateSkillDTO update)
        {
            var entity = await _dbContext.Skill
                .Include(x => x.RelatedActivities)
                .FirstOrDefaultAsync(x => x.Id == SkillId);
            if (entity == null) throw new ElementNotFoundException(_notFoundException);

            if (update.Name != null) entity.Name = update.Name;
            if (update.SkillType != null) entity.SkillType = (Common.Enums.SkillType) update.SkillType;
            if (update.RelatedActivitiesId != null)
            {
                var relatedActivites = new List<ActivityEntity>();
                foreach (var id in update.RelatedActivitiesId)
                {
                    var activity = await _dbContext.Activity
                    .FirstOrDefaultAsync(x => x.Id == id);

                    if (activity == null) throw new ElementNotFoundException(_activityNotFoundException);
                    relatedActivites.Add(activity);
                }
                entity.RelatedActivities = relatedActivites;
            }
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteSkill(Guid SkillId)
        {
            var result = await _dbContext.Skill
                .FirstOrDefaultAsync(x => x.Id == SkillId);
            if (result == null) throw new ElementNotFoundException(_notFoundException);
            _dbContext.Remove(result);
            await _dbContext.SaveChangesAsync();
        }
    }
}
