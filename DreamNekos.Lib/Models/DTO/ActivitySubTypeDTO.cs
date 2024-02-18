using DreamNekos.Core.Entities;

namespace DreamNekos.Core.Models.DTO
{
    public class ActivitySubTypeDTO
    {
        public string? Name { get; set; }
        public ActivityTypeEntity? ActivityType { get; set; }
    }
}
