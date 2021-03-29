using DDStartProjectBackEnd.Common.Dto.Requests;

namespace DDStartProjectBackEnd.Auth.Requests
{
    public class IsUsernameAvailableRequest: BaseRequest
    {
        public string Username { get; set; }
    }
}
