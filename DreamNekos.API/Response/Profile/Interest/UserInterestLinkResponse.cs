using DreamNekos.API.Response.Interest;
using DreamNekosConnect.Lib.Enums;

namespace DreamNekos.API.Response.Profile.Interest
{
    public class UserInterestLinkResponse
    {
        public required Guid InterestLinkId { get; set; }
        public required InterestResponse Interest { get; set; }
        public FamiliarizationLevel FamiliarizationLevel { get; set; }
    }
}
