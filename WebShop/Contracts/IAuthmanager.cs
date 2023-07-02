using Microsoft.AspNetCore.Identity;
using WebShop.Models.Users;

namespace WebShop.Contracts
{
    public interface IAuthmanager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto);
        Task<AuthResponseDto> Login(LoginDto loginDto);
        Task<string> CreateRefreshToken();
        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);
    }
}
