using DreamNekos.API.Helpers;
using DreamNekos.Core.Entities.Activity;
using DreamNekos.Core.Interface;
using DreamNekos.Core.Models.DTO.ActivitySubType;
using Microsoft.EntityFrameworkCore;

namespace DreamNekos.Core.Services
{
    public class ActivitySubTypeService : IActivitySubTypeService
    {
        private readonly string _notFoundMessage = "A activity sub type with such an ID does not exist.";
        private readonly string _notFoundActivityTypeMessage = "A activity type with such an ID does not exist.";

        private ApplicationDbContext _dbContext { get; set; }

        public async Task<ActivitySubTypeEntity> CreateActivitySubType(CreateActivitySubTypeDTO create)
        {
            var activityType = await _dbContext.ActivityType.FirstOrDefaultAsync(x => x.Id == create.ActivityTypeId);
            if (activityType == null) throw new ElementNotFoundException(_notFoundActivityTypeMessage);

            var entity = new ActivitySubTypeEntity()
            {
                Name = create.Name,
                TypeEntity = activityType
            };

            await _dbContext.ActivitySubType.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteActivitySubType(Guid ActivitySubTypeId)
        {
            var result = await _dbContext.ActivitySubType
                .Include(x => x.Activities)
                .FirstOrDefaultAsync(x => x.Id == ActivitySubTypeId);
            if (result == null) throw new ElementNotFoundException(_notFoundMessage);
            _dbContext.Remove(result);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<ActivitySubTypeEntity> GetActivitySubTypeById(Guid ActivitySubTypeId)
        {
            var activityType = await _dbContext.ActivitySubType.FirstOrDefaultAsync(x => x.Id == ActivitySubTypeId);
            if (activityType == null) throw new ElementNotFoundException(_notFoundMessage);
            return activityType;
        }

        public async Task<List<ActivitySubTypeEntity>> GetAllActivitySubType()
        {
            return await _dbContext.ActivitySubType
                .Include(x => x.Activities).ToListAsync();
        }

        public async Task<ActivitySubTypeEntity> UpdateActivitySubType(Guid ActivitySubTypeId, UpdateActivitySubTypeDTO update)
        {
            var result = await _dbContext.ActivitySubType
                .Include(x => x.Activities)
                .FirstOrDefaultAsync(x => x.Id == ActivitySubTypeId);
            if (result == null) throw new ElementNotFoundException(_notFoundMessage);

            if (update.Name != null) result.Name = update.Name;
            if (update.ActivityTypeId != null)
            {
                var activityType = await _dbContext.ActivityType.FirstOrDefaultAsync(x => x.Id == update.ActivityTypeId);
                if (activityType == null) throw new ElementNotFoundException(_notFoundActivityTypeMessage);
                result.TypeEntity = activityType;
            }
            await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
