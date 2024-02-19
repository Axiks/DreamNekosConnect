using DreamNekos.Core.Entities.Activity;
using DreamNekos.Core.Models.DTO.ActivitySubType;

namespace DreamNekos.Core.Interface
{
    public interface IActivitySubTypeService
    {
        public Task<ActivitySubTypeEntity> GetActivitySubTypeById(Guid ActivitySubTypeId);
        public Task<List<ActivitySubTypeEntity>> GetAllActivitySubType();
        public Task<ActivitySubTypeEntity> CreateActivitySubType(CreateActivitySubTypeDTO create);
        public Task<ActivitySubTypeEntity> UpdateActivitySubType(Guid ActivitySubTypeId, UpdateActivitySubTypeDTO update);
        public Task DeleteActivitySubType(Guid ActivitySubTypeId);
    }
}
