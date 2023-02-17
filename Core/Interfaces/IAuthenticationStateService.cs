namespace Core.Interfaces;

public interface IAuthenticationStateService
{
    Task<string> GetCurrentUserId();
}