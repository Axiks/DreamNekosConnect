using DreamNekos.Core.Entities;
using DreamNekos.Core.Models.DTO;

namespace DreamNekos.Core.Interface
{
    public interface IActivityService
    {
        public List<ActivityEntity> ActivityGetAll();
        public ActivityEntity ActivityGetById(Guid ActvityId);
        public ActivityEntity ActivityCreate(ActivityDTO activityDTO);
        public ActivityEntity ActivityUpdate(Guid ActvityId, ActivityDTO activityDTO);
        public void ActivityDelete(Guid ActvityId);
    }
}
