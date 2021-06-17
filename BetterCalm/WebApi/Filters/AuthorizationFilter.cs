using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SessionInterface;

namespace WebApi.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        private readonly ISessionLogic sessions;

        public AuthorizationFilter(ISessionLogic sessionsLogic)
        {
            this.sessions = sessionsLogic;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token = context.HttpContext.Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Must contain a token to access Api"
                };
            }
            else
            {
                if (!sessions.IsValidToken(token))
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = 403,
                        Content = "Forbidden, ask for permission"
                    };
                }
            }
        }
    }
}
