using DreamNekos.Common.Enums;
using DreamNekos.Core.Entities.Activity;

namespace DreamNekos.Core.Models.DTO.Skill
{
    public class UpdateSkillDTO
    {
        public string? Name { get; set; }
        public SkillType? SkillType { get; set; }

        public List<Guid>? RelatedActivitiesId { get; set; }
        //public List<ActivityEntity> RelatedActivities { get; set; } = new List<ActivityEntity>(); //test
    }
}
