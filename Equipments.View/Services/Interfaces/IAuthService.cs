namespace Equipments.View.Services.Interfaces;

public interface IAuthService
{
    Task<bool> LoginAsync(string password);
    Task LogoutAsync();
    bool IsAuthenticated();
    bool IsInRole(string role);
}