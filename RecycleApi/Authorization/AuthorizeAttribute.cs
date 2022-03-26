using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Recycle.Models;
using System;

namespace RecycleApi.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly int _roleId;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Items["Client"] as Client;
            if (user == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" })
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                };
            }
        }
        public AuthorizeAttribute(int roleId)
        {
            _roleId = roleId;
        }

        public AuthorizeAttribute()
        {

        }
    }
}