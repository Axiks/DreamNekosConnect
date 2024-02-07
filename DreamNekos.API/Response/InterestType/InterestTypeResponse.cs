using System.ComponentModel.DataAnnotations;

namespace DreamNekos.API.Response.InterestType
{
    public class InterestTypeResponse
    {
        [Required]
        public required Guid InterestTypeId { get; set; }
        [Required]
        public required string Name { get; set;}
    }
}
