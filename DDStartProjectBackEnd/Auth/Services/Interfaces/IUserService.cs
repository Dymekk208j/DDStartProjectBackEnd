using DDStartProjectBackEnd.Auth.Requests;
using DDStartProjectBackEnd.Auth.Responses;
using System.Threading.Tasks;

namespace DDStartProjectBackEnd.Auth.Services.Interfaces
{
    public interface IUserService
    {
        Task<LoginResponse> Login(LoginRequest request);

        Task<RegisterResponse> Register(RegisterRequest request);

        Task<IsEmailAvailableResponse> IsEmailAvailable(IsEmailAvailableRequest request);

        Task<IsUsernameAvailableResponse> IsUsernameAvailable(IsUsernameAvailableRequest request);

    }
}
