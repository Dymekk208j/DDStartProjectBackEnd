using DDStartProjectBackEnd.Common.Dto.Responses;

namespace DDStartProjectBackEnd.Auth.Responses
{
    public class IsUsernameAvailableResponse : BaseResponse
    {
        public bool IsUserNameAvailable { get; set; }
    }
}
