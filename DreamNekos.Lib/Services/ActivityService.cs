using DreamNekos.API.Helpers;
using DreamNekos.Core;
using DreamNekos.Core.Entities.Activity;
using DreamNekos.Core.Interface;
using DreamNekos.Core.Models.DTO.Activity;
using Microsoft.EntityFrameworkCore;

namespace DreamNekosConnect.Lib.Services
{
    public class ActivityService : IActivityService
    {
        private readonly string _notFoundMessage = "A activity with such an ID does not exist.";
        private readonly string _notFoundSubtypeMessage = "A subtype with such an ID does not exist.";

        private ApplicationDbContext _dbContext { get; set; }
        public ActivityService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<List<ActivityEntity>> ActivityGetAll()
        {
            return await _dbContext.Activity.ToListAsync();
        }

        public async Task<ActivityEntity> ActivityGetById(Guid ActvityId)
        {
            var result = await _dbContext.Activity.FirstOrDefaultAsync(x => x.Id == ActvityId);
            if (result == null) throw new ElementNotFoundException(_notFoundMessage);
            return result;
        }

        public async Task<ActivityEntity> ActivityCreate(CreateActivityDTO create)
        {
            var subtype = await _dbContext.ActivitySubType.FirstOrDefaultAsync(x => x.Id == create.SubTypeId);
            if (subtype == null) throw new ElementNotFoundException(_notFoundSubtypeMessage);

            var newEntity = new ActivityEntity()
            {
                Name = create.Name,
                ActivitySubType = subtype
            };

            await _dbContext.Activity.AddAsync(newEntity);
            await _dbContext.SaveChangesAsync();

            return newEntity;
        }

        public async Task<ActivityEntity> ActivityUpdate(Guid ActvityId, UpdateActivityDTO update)
        {
            var entity = await _dbContext.Activity.FirstOrDefaultAsync(x => x.Id == ActvityId);
            if (entity == null) throw new ElementNotFoundException(_notFoundMessage);

            if(update.Name != null) entity.Name = update.Name;
            if(update.SubTypeId != null)
            {
                var subtype = await _dbContext.ActivitySubType.FirstOrDefaultAsync(x => x.Id == update.SubTypeId);
                if (subtype == null) throw new ElementNotFoundException(_notFoundSubtypeMessage);

                entity.ActivitySubType = subtype;
            }

            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task ActivityDelete(Guid ActvityId)
        {
            var result = await _dbContext.Activity.FirstOrDefaultAsync(x => x.Id == ActvityId);
            if (result == null) throw new ElementNotFoundException(_notFoundMessage);
            _dbContext.Activity.Remove(result);
            await _dbContext.SaveChangesAsync();
        }
    }
}
