using DreamNekos.API.Helpers;
using DreamNekos.Core.Entities.Activity;
using DreamNekos.Core.Interface;
using DreamNekos.Core.Models.DTO.ActivityType;
using Microsoft.EntityFrameworkCore;

namespace DreamNekos.Core.Services
{
    public class ActivityTypeService : IActivityTypeService
    {
        private readonly string _notFoundMessage = "A activity type with such an ID does not exist.";
        private ApplicationDbContext _dbContext { get; set; }

        public ActivityTypeService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<ActivityTypeEntity> GetActivityTypeById(Guid ActivityTypeId)
        {
            var result = await _dbContext.ActivityType
                .Include(x => x.SubTypes)
                .FirstOrDefaultAsync(x => x.Id == ActivityTypeId);
            if (result == null) throw new ElementNotFoundException(_notFoundMessage);
            return result;
        }

        public async Task<List<ActivityTypeEntity>> GetAllActivityType()
        {
            return await _dbContext.ActivityType
                .Include(x => x.SubTypes)
                .ToListAsync();
        }

        public async Task<ActivityTypeEntity> CreateActivityType(CreateActivityTypeDTO activityTypeDTO)
        {
            var newEntity = new ActivityTypeEntity() {
                Name = activityTypeDTO.Name
            };

            await _dbContext.ActivityType.AddAsync(newEntity);
            await _dbContext.SaveChangesAsync();

            return newEntity;
        }

        public async Task<ActivityTypeEntity> UpdateActivityType(Guid ActivityTypeId, UpdateActivityTypeDTO update)
        {
            var result = await _dbContext.ActivityType
                .Include(x => x.SubTypes)
                .FirstOrDefaultAsync(x => x.Id == ActivityTypeId);
            if (result == null) throw new ElementNotFoundException(_notFoundMessage);

            if(update.Name != null) result.Name = update.Name;

            await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task DeleteActivityType(Guid ActivityTypeId)
        {
            var result = await _dbContext.ActivityType
                .Include(x => x.SubTypes)
                .FirstOrDefaultAsync(x => x.Id == ActivityTypeId);
            if (result == null) throw new ElementNotFoundException(_notFoundMessage);
            _dbContext.Remove(result);
            await _dbContext.SaveChangesAsync();
        }
    }
}