using DreamNekos.Core.Entities.Activity;
using DreamNekos.Core.Models.DTO.Activity;

namespace DreamNekos.Core.Interface
{
    public interface IActivityService
    {
        public Task<List<ActivityEntity>> ActivityGetAll();
        public Task<ActivityEntity> ActivityGetById(Guid ActvityId);
        public Task<ActivityEntity> ActivityCreate(CreateActivityDTO activityDTO);
        public Task<ActivityEntity> ActivityUpdate(Guid ActvityId, UpdateActivityDTO activityDTO);
        public Task ActivityDelete(Guid ActvityId);
    }
}
