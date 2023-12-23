using DreamNekos.API.Response.InterestType;

namespace DreamNekos.API.Response.Interest
{
    public class InterestResponse
    {
        public required Guid InterestId { get; set; }
        public required string Name { get; set; }
        public InterestTypeResponse? InterestType { get; set; }
    }
}
