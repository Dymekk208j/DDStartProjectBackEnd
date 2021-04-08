using DDStartProjectBackEnd.Auth.Dto.Requests;
using DDStartProjectBackEnd.Auth.Dto.Responses;
using System.Threading.Tasks;

namespace DDStartProjectBackEnd.Auth.Data.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest request);

        Task<RegisterResponse> Register(RegisterRequest request);

        Task<IsEmailAvailableResponse> IsEmailAvailable(IsEmailAvailableRequest request);

        Task<IsUsernameAvailableResponse> IsUsernameAvailable(IsUsernameAvailableRequest request);

    }
}
