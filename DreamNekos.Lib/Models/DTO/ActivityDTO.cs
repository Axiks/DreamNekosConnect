using DreamNekos.Core.Entities;

namespace DreamNekos.Core.Models.DTO
{
    public class ActivityDTO
    {
        public string? Name { get; set; }
        public ActivitySubTypeEntity? ActivitySubType { get; set; }
    }
}
