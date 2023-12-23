namespace DreamNekos.API.Request.Profile
{
    public class CreateProfileRequest
    {
        public int TgId {  get; set; }
        public string Name { get; set; }
        public string? About { get; set; }
    }
}
