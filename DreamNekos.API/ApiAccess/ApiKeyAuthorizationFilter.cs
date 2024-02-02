using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DreamNekos.API.Helpers
{
    public class ApiKeyAuthorizationFilter : IAuthorizationFilter
    {
        private readonly IApiKeyValidator _apiKeyValidator;
        public ApiKeyAuthorizationFilter(IApiKeyValidator apiKeyValidator)
        {
            _apiKeyValidator = apiKeyValidator;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //var token = context.HttpContext.GetTokenAsync("access_token").GetAwaiter().GetResult();

            if(context.HttpContext.Request.Headers["Authorization"].FirstOrDefault() == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            //var token = context.HttpContext.Request.Headers["Authorization"].First().Split(" ")[1];
            var token = context.HttpContext.Request.Headers["Authorization"].First();

            if (!_apiKeyValidator.IsValid(token))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}