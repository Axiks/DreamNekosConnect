namespace DreamNekos.Core.Entities
{
    public class ActivityEntity : BasicEntity
    {
        public required string Name { get; set; }
        public required ActivitySubTypeEntity ActivitySubType { get; set; }

        public List<SkillEntity> RelatedSkills { get; set; } = new List<SkillEntity> { };

        public List<UserEntity> Users { get; set; }
    }
}