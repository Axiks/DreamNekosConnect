using DreamNekosConnect.Lib.Entities;

namespace DreamNekos.Core.Entities
{
    public class UserEntity : BasicEntity
    {
        public required long TgId { get; set; }
        public required string Name { get; set; }
        public string? About { get; set; }

        public List<LinkEntity> Links { get; set; } = new List<LinkEntity>();

        //public List<ActivityEntity> Interest { get; set; } = new List<ActivityEntity>();

        /*public List<UserActivityEntity> Activities { get; set; } = new List<UserActivityEntity> { };
        public List<UserSkillEntity> Skills { get; set; } = new List<UserSkillEntity> { };*/

        public List<ActivityEntity> Activities { get; set; } = new List<ActivityEntity> { };
        public List<SkillEntity> Skills { get; set; } = new List<SkillEntity> { };
    }
}