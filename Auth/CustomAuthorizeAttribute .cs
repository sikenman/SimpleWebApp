using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace SimpleWebApp.Auth
{
    // Custom authorization filter
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _requiredRole;

        public CustomAuthorizeAttribute(string requiredRole)
        {
            _requiredRole = requiredRole;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Check if the user is authenticated
            //if (!context.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    context.Result = new UnauthorizedResult();
            //    return;
            //}

            // Check if the user has the required role
            //if (!context.HttpContext.User.IsInRole(_requiredRole))
            //{
            //    context.Result = new ForbidResult();
            //    return;
            //}

            var userId = "BXPA77";
            if(IsAuthorized(userId))
            {
                return;
            } else
            {
                // Return HTTP status code 401 (Unauthorized) if not authorized
                context.Result = new UnauthorizedResult();
                return;
            }
        }

        private bool IsAuthorized(string userId)
        {
            // Custom logic to validate user permissions
            // For example, check if the user has access to a specific resource
            // Return true if authorized; otherwise, return false
            // We can also check roles, claims, or other security information
            // based on your requirements

            // Example: Assume user with ID "BXPA78" is authorized
            return userId == "BXPA78";
        }
    }

}