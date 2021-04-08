using DDStartProjectBackEnd.Common.Dto.Requests;

namespace DDStartProjectBackEnd.Auth.Dto.Requests
{
    public class IsUsernameAvailableRequest : BaseRequest
    {
        public string Username { get; set; }
    }
}
