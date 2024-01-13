using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

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

            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault().Split(" ")[1];

            if (!_apiKeyValidator.IsValid(token))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}