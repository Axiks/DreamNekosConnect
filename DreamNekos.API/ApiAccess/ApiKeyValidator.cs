using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace DreamNekos.API.Helpers
{
    public class ApiKeyValidator : IApiKeyValidator
    {
        private IConfiguration _config;

        public ApiKeyValidator(IConfiguration config)
        {
            _config = config;
        }

        public bool IsValid(string token)
        {
            if (token == null) return false;

            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _config["Jwt:Issuer"],
                ValidateAudience = true,
                ValidAudience = _config["Jwt:Audience"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKeys = [securityKey],
                ValidateLifetime = true
            };

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                return true;
            }
            catch (SecurityTokenValidationException ex)
            {
                // Log the reason why the token is not valid
                return false;
            }
        }
    }

    public interface IApiKeyValidator
    {
        bool IsValid(string token);
    }
}