using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.Extentions
{
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _requiredRole;

        public CustomAuthorizeAttribute(string role = null)
        {
            _requiredRole = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var roleCookie = context.HttpContext.Request.Cookies["role"];

            if (string.IsNullOrEmpty(roleCookie))
            {
                context.Result = new RedirectToActionResult("Login", "Auth", null);
                return;
            }

            string userRoleToString;

            switch (roleCookie)
            {
                case "1":
                    userRoleToString = "User";
                    break;
                case "2":
                    userRoleToString = "Admin";
                    break;
                default:
                    context.Result = new ForbidResult();
                    return;
            }

            if (!string.IsNullOrEmpty(_requiredRole) && userRoleToString != _requiredRole)
            {
                context.Result = new ForbidResult(); 
            }
        }
    }
}
