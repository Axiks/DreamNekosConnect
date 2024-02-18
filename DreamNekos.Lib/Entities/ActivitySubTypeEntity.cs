namespace DreamNekos.Core.Entities
{
    public class ActivitySubTypeEntity : BasicEntity
    {
        public required string Name { get; set; }
        public required ActivityTypeEntity TypeEntity { get; set; }

        public List<ActivityEntity> Activities { get; set; } = new List<ActivityEntity> { };
    }
}
