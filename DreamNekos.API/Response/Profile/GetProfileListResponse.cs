using System.ComponentModel.DataAnnotations;

namespace DreamNekos.API.Response.Profile
{
    public class GetProfileListResponse
    {
        [Required]
        public List<GetProfileResponse> Profiles { get; set; }
        public int Count { get => Profiles.Count(); }
    }
}
