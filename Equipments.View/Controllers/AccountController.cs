using Equipments.View.Helper;
using Equipments.View.Services.Interfaces;
using Equipments.View.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Equipments.View.Controllers;

[AllowAnonymous]
public class AccountController(IAuthService authService) : Controller
{

    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        if (authService.IsAuthenticated())
        {
            return RedirectToAction(
                        nameof(FacilityController.Index), 
                        NameController.GetControllerName(nameof(FacilityController)));
        }

        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel, string? returnUrl = null)
    {
        if (!ModelState.IsValid)
        {
            return View(loginViewModel);
        }

        var success = await authService.LoginAsync(loginViewModel.Password);

        if (success)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction(
                        nameof(FacilityController.Index),
                        NameController.GetControllerName(nameof(FacilityController)));
        }

        ModelState.AddModelError("", "Неверный пароль");
        return View(loginViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await authService.LogoutAsync();

        return RedirectToAction(
                        nameof(FacilityController.Index),
                        NameController.GetControllerName(nameof(FacilityController)));
    }
}