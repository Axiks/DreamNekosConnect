using DreamNekos.API.Response.Profile;
using DreamNekos.API.Response.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace DreamNekos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiAccessController : ControllerBase
    {
        private IConfiguration _config;
        public ApiAccessController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(TokenResponse))]
        public IActionResult CreateAccessTocken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, "App ID <- in future"),
                new Claim("CustomerType", "3-party app"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddSeconds(Int32.Parse(_config["Jwt:AliveTime"])),
                signingCredentials: credentials);

            var response = new TokenResponse { Token = new JwtSecurityTokenHandler().WriteToken(token) };

            return Ok(response);
        }
    }
}
