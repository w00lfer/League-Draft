using System.Threading.Tasks;
using LeagueDraft_API.DTO;

namespace LeagueDraft_API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<JwtToken> SignUpUserAsync(SignUpUser signUpUser);
        Task<JwtToken> SignInUserAsync(SignInUser signInUser);
        Task LogoutAsync();
    }
}