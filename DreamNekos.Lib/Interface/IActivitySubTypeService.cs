using DreamNekos.Core.Entities;
using DreamNekos.Core.Models.DTO;

namespace DreamNekos.Core.Interface
{
    public interface IActivitySubTypeService
    {
        public ActivitySubTypeEntity GetActivitySubTypeById(Guid ActivitySubTypeId);
        public List<ActivitySubTypeEntity> GetAllActivitySubType();
        public ActivitySubTypeEntity CreateActivitySubType(ActivitySubTypeDTO activitySubTypeDTO);
        public ActivitySubTypeEntity UpdateActivitySubType(Guid ActivitySubTypeId, ActivitySubTypeDTO activitySubTypeDTO);
        public void DeleteActivitySubType(Guid ActivitySubTypeId);
    }
}
