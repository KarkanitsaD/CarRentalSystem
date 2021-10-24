using System;
using System.Collections.Generic;
using System.Linq;
using Business.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _roles;

        public AuthorizeAttribute(params string[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if ((bool)context.HttpContext.Items["Authorized"])
            {
                var userRoles = (IEnumerable<string>) context.HttpContext.Items["UserRoles"];

                if (!userRoles.Intersect(_roles).Any())
                {
                    throw new NotAuthorizedException("The user does not have access rights to this functionality.");
                }
                return;
            }
            throw new NotAuthorizedException("User is not authorized.");
        }
    }
}
