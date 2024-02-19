using DreamNekos.Core.Entities;

namespace DreamNekos.Core.Models.DTO.ActivitySubType
{
    public class UpdateActivitySubTypeDTO
    {
        public string? Name { get; set; }
        public Guid? ActivityTypeId { get; set; }
    }
}
