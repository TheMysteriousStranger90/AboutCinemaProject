using Core.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;

public class AuthenticationStateService : IAuthenticationStateService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUnitOfWork _unitOfWork;

    public AuthenticationStateService(IHttpContextAccessor httpContextAccessor,
        IUnitOfWork unitOfWork)
    {
        _httpContextAccessor = httpContextAccessor;
        _unitOfWork = unitOfWork;
    }

    public async Task<string> GetCurrentUserId()
    {
        if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
        {
            return null;
        }

        var user = await _unitOfWork.UserManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
        return user.Id;
    }
}