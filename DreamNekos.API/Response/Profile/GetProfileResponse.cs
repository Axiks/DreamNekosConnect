using DreamNekos.API.Response.Interest;
using DreamNekos.API.Response.Link;
using DreamNekos.API.Response.Profile.Interest;
using System.ComponentModel.DataAnnotations;

namespace DreamNekos.API.Response.Profile
{
    public class GetProfileResponse
    {
        [Required]
        public required Guid Id { get; set; }
        public required long TgId { get; set; }
        public string? About { get; set; }
        public List<UserInterestLinkResponse> Interest { get; set; } = new List<UserInterestLinkResponse>();
        public List<LinkResponse> Links { get; set; } = new List<LinkResponse>();

    }
}
