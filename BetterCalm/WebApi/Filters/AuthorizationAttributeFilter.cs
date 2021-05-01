using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SessionInterface;
using System;

namespace WebApi.Filters
{
    public class AuthorizationAttributeFilter : Attribute, IAuthorizationFilter
    {
        private readonly ISessionLogic sessions;

        public AuthorizationAttributeFilter(ISessionLogic sessionsLogic)
        {
            this.sessions = sessionsLogic;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"];

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
