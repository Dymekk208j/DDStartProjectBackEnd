using DDStartProjectBackEnd.Common.Dto.Requests;

namespace DDStartProjectBackEnd.Auth.Requests
{
    public class LoginRequest : BaseRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
