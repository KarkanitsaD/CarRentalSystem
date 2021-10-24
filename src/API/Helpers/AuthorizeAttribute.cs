using System;
using System.Collections.Generic;
using System.Linq;
using Business.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Helpers
{

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

                if (userRoles.Intersect(_roles).Count() != _roles.Length)
                {
                    throw new NotAuthorizedException("The user does not have access rights to this functionality.");
                }
                return;
            }
            throw new NotAuthorizedException("User is not authorized.");
        }
    }
}
