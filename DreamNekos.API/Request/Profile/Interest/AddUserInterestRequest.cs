using DreamNekos.Common.Enums;

namespace DreamNekos.API.Request.Profile.Interest
{
    public class AddUserInterestRequest
    {
        public required Guid interestId { get; set; }
        public FamiliarizationLevel? familiarizationLevel { get; set; }
    }
}
