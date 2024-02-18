namespace DreamNekos.Core.Entities
{
    public class ActivityTypeEntity : BasicEntity
    {
        public required string Name { get; set; }

        public List<ActivitySubTypeEntity> SubTypes { get; set; } = new List<ActivitySubTypeEntity>();
    }
}