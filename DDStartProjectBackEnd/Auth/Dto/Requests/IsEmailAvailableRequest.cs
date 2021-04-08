using DDStartProjectBackEnd.Common.Dto.Requests;

namespace DDStartProjectBackEnd.Auth.Dto.Requests
{
    public class IsEmailAvailableRequest : BaseRequest
    {
        public string Email { get; set; }
    }
}
