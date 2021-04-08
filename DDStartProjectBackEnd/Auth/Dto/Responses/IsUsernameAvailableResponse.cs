using DDStartProjectBackEnd.Common.Dto.Responses;

namespace DDStartProjectBackEnd.Auth.Dto.Responses
{
    public class IsUsernameAvailableResponse : BaseResponse
    {
        public bool IsUserNameAvailable { get; set; }
    }
}
