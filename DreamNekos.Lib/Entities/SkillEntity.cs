using DreamNekos.Common.Enums;
using DreamNekos.Core.Entities.Activity;

namespace DreamNekos.Core.Entities
{
    public class SkillEntity : BasicEntity
    {
        public required string Name { get; set; }
        public required SkillType SkillType { get; set; }

        public List<ActivityEntity> RelatedActivities { get; set; } = new List<ActivityEntity> { };

        public List<UserEntity> Users { get; set; } = new List<UserEntity> { };
    }
}
