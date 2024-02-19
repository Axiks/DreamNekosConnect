using DreamNekos.Core.Entities;

namespace DreamNekos.Core.Models.DTO.ActivitySubType
{
    public class CreateActivitySubTypeDTO
    {
        public required string Name { get; set; }
        public required Guid ActivityTypeId { get; set; }
    }
}
