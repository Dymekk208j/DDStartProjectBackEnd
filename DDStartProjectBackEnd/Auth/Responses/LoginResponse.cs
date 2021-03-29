using DDStartProjectBackEnd.Common.Dto.Responses;

namespace DDStartProjectBackEnd.Auth.Responses
{
    public class LoginResponse : BaseResponse
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }
    }
}
