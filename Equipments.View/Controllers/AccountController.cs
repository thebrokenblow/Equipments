using Equipments.View.Helper;
using Equipments.View.Services.Interfaces;
using Equipments.View.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Equipments.View.Controllers;

/// <summary>
/// Контроллер для управления аутентификацией и авторизацией пользователей
/// </summary>
public class AccountController(IAuthService authService) : Controller
{
    /// <summary>
    /// Отображает страницу входа в систему
    /// </summary>
    /// <param name="returnUrl">URL для перенаправления после успешного входа</param>
    /// <returns>Страница входа</returns>
    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        if (authService.IsAuthenticated())
        {
            return RedirectToHomePage();
        }

        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    /// <summary>
    /// Выполняет аутентификацию пользователя
    /// </summary>
    /// <param name="loginViewModel">Данные для входа</param>
    /// <param name="returnUrl">URL для перенаправления после успешного входа</param>
    /// <returns>Результат аутентификации</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel, string? returnUrl = null)
    {
        var success = await authService.LoginAsync(loginViewModel.Password);

        if (success)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction(nameof(FacilityController.Index), "Facility");
        }

        ModelState.AddModelError(string.Empty, "Неверный пароль");

        return View(loginViewModel);
    }

    /// <summary>
    /// Выполняет выход пользователя из системы
    /// </summary>
    /// <returns>Результат выхода</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await authService.LogoutAsync();

        return RedirectToHomePage();
    }

    /// <summary>
    /// Перенаправляет на домашнюю страницу приложения - список объектов
    /// </summary>
    /// <returns>Результат перенаправления на страницу списка объектов</returns>
    public IActionResult RedirectToHomePage()
    {
        return RedirectToAction(
                        nameof(FacilityController.Index),
                        NameController.GetControllerName(nameof(FacilityController)));
    }
}