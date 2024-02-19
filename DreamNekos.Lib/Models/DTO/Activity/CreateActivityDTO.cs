namespace DreamNekos.Core.Models.DTO.Activity
{
    public class CreateActivityDTO
    {
        public required string Name { get; set; }
        public required Guid SubTypeId { get; set; }
    }
}
