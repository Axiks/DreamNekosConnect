namespace DreamNekosConnect.Lib.Entities
{
    public class InterestEntity : BasicEntity
    {
        public required string Name { get; set; }
        public Guid? InterestTypeId { get; set; }
        public InterestTypeEntity? InterestType { get; set; }

        public List<UserEntity> Users { get; set; }
        public List<UserInterestEntity> UserInterestEntities { get; }
    }
}