using DDStartProjectBackEnd.Common.Dto.Responses;

namespace DDStartProjectBackEnd.Auth.Dto.Responses
{
    public class LoginResponse : BaseResponse
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }
        public bool RememberMe { get; set; }
        public bool IsBlocked { get; set; }
    }
}
