using DreamNekos.API.Response.Interest;
using DreamNekos.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace DreamNekos.API.Response.Profile.Interest
{
    public class UserInterestLinkResponse
    {
        [Required]
        public required InterestResponse Interest { get; set; }
        public FamiliarizationLevel FamiliarizationLevel { get; set; }
    }
}
