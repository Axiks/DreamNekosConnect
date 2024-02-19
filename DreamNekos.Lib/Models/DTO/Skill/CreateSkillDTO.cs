using DreamNekos.Common.Enums;
using DreamNekos.Core.Entities.Activity;

namespace DreamNekos.Core.Models.DTO.Skill
{
    public class CreateSkillDTO
    {
        public required string Name { get; set; }
        public required SkillType SkillType { get; set; }

        public List<Guid>? RelatedActivitiesId { get; set; }
        //public List<ActivityEntity>? RelatedActivities { get; set; } //test
    }
}
