using System.ComponentModel.DataAnnotations;

namespace DreamNekos.API.Response.Link
{
    public class LinkResponse
    {
        [Required]
        public Guid LinkId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
    }
}
