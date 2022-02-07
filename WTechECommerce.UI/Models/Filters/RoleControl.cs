using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;

namespace WTechECommerce.UI.Models.Filters
{
    public class RoleControl : AuthorizeAttribute, IAuthorizationFilter
    {

        string menuRole = "";

        public RoleControl(string role)
        {
            menuRole = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userRole = context.HttpContext.User.Claims.FirstOrDefault(q => q.Type == ClaimTypes.Role).Value.ToString();


            if (userRole == "SuperAdmin" || userRole == menuRole)
            {

            }
            else
            {
                context.HttpContext.Response.Redirect("/Error/RoleError");
            } 
        }
    }
}
