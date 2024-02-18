using DreamNekos.Common.Enums;

namespace DreamNekos.Core.Entities
{
    public class UserSkillEntity : BasicEntity
    {
        //public Guid UserId { get; set; }
        public required UserEntity User { get; set; }
        //public Guid SkillId { get; set; }
        public required SkillEntity Skill { get; set; }

        public FamiliarizationLevel FamiliarizationLevel { get; set; }
    }
}
