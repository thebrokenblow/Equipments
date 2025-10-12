using Equipments.View.Controllers;
using Equipments.View.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Equipments.View.Filters;

[AttributeUsage(AttributeTargets.All)]
public class AuthenticationRequiredAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!context.HttpContext.User.Identity?.IsAuthenticated ?? false)
        {
            if (!context.HttpContext.User.Identity?.IsAuthenticated ?? false)
            {
                var returnUrl = context.HttpContext.Request.Path + context.HttpContext.Request.QueryString;

                context.Result = new RedirectToActionResult(
                                        nameof(AccountController.Login),
                                        NameController.GetControllerName(nameof(AccountController)),
                                        new { returnUrl });
            }
        }
    }
}