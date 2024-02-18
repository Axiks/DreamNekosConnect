using DreamNekos.Common.Enums;
using DreamNekos.Core.Entities;

namespace DreamNekos.Core.Models.DTO
{
    public class SkillDTO
    {
        public string? Name { get; set; }
        public SkillType? SkillType { get; set; }

        public List<ActivityEntity>? RelatedActivities { get; set; } //test
    }
}
