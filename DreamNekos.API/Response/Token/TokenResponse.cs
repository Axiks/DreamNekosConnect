using System.ComponentModel.DataAnnotations;

namespace DreamNekos.API.Response.Token
{
    public class TokenResponse
    {
        [Required]
        public required string Token { get; set; }
    }
}
