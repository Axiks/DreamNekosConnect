using DreamNekosConnect.Lib.Entities;

namespace DreamNekos.API.Request.Interest
{
    public class UpdateInterestRequest
    {
        public string? Name { get; set; }
        public Guid? InterestTypeId { get; set; }
    }
}
