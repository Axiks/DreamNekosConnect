using DreamNekos.Core.Entities.Activity;
using DreamNekos.Core.Models.DTO.ActivityType;

namespace DreamNekos.Core.Interface
{
    public interface IActivityTypeService
    {
        public Task<ActivityTypeEntity> GetActivityTypeById(Guid ActivityTypeId);
        public Task<List<ActivityTypeEntity>> GetAllActivityType();
        public Task<ActivityTypeEntity> CreateActivityType(CreateActivityTypeDTO create);
        public Task<ActivityTypeEntity> UpdateActivityType(Guid ActivityTypeId, UpdateActivityTypeDTO update);
        public Task DeleteActivityType(Guid ActivityTypeId);
    }
}
