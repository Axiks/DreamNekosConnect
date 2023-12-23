namespace DreamNekosConnect.Lib.Entities
{
    public class InterestTypeEntity : BasicEntity
    {
        public required string Name { get; set; }
        public List<InterestEntity> Interests { get; set; }
    }
}