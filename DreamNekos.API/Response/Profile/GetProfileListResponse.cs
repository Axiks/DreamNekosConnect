namespace DreamNekos.API.Response.Profile
{
    public class GetProfileListResponse
    {
        public List<GetProfileResponse> Profiles { get; set; }
        public int Count { get => Profiles.Count(); }
    }
}
