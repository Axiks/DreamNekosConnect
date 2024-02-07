using DreamNekos.API.Response.InterestType;
using System.ComponentModel.DataAnnotations;

namespace DreamNekos.API.Response.Interest
{
    public class InterestResponse
    {
        [Required]
        public required Guid InterestId { get; set; }
        [Required]
        public required string Name { get; set; }
        public InterestTypeResponse? InterestType { get; set; }
    }
}
