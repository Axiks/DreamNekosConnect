using Microsoft.AspNetCore.Mvc;

namespace DreamNekos.API.Helpers
{
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        public ApiKeyAttribute()
        : base(typeof(ApiKeyAuthorizationFilter))
        {
        }
    }
}
