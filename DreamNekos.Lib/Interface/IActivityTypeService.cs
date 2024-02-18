using DreamNekos.Core.Entities;
using DreamNekos.Core.Models.DTO;

namespace DreamNekos.Core.Interface
{
    public interface IActivityTypeService
    {
        public ActivityTypeEntity GetActivityTypeById(Guid ActivityTypeId);
        public List<ActivityTypeEntity> GetAllActivityType();
        public ActivityTypeEntity CreateActivityType(ActivityTypeDTO activityTypeDTO);
        public ActivityTypeEntity UpdateActivityType(Guid ActivityTypeId, ActivityTypeDTO activityTypeDTO);
        public void DeleteActivityType(Guid ActivityTypeId);
    }
}
