using DDStartProjectBackEnd.Common.Dto.Responses;

namespace DDStartProjectBackEnd.Auth.Responses
{
    public class IsEmailAvailableResponse : BaseResponse
    {
        public bool IsEmailAvailable { get; set; }
    }
}
