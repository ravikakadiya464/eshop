using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace EShop.Common.Extensions
{
    public static class SecurityExtension
    {
        public static Guid GetUserId(this IHttpContextAccessor contextAccessor)
        {
            try
            {
                contextAccessor.HttpContext.Request.Headers.TryGetValue("oid", out StringValues userId);
                return new Guid(userId);
            }
            catch (Exception e)
            {
                throw new UnauthorizedAccessException(e.Message);
            }
        }
    }
}
