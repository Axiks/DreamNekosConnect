using DreamNekos.API.Response.InterestType;
using DreamNekosConnect.Lib.Entities;

namespace DreamNekos.API.Request.Interest
{
    public class CreateInterestRequest
    {
        public required string Name { get; set; }
        public Guid? InterestTypeId { get; set; }
    }
}
