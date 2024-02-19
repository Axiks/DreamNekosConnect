using DreamNekos.Common.Enums;
using DreamNekos.Core.Entities;
using DreamNekos.Core.Entities.Activity;

namespace DreamNekosConnect.Lib.Entities
{
    public class UserActivityEntity : BasicEntity
    {
        //public Guid UserId { get; set; }
        public required UserEntity User { get; set; }
        //public Guid ActivityId { get; set; }
        public required ActivityEntity Actvity { get; set; }

        public EngagmentLevel EngagmentLevel { get; set; }
    }
}
