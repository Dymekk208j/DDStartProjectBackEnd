using DDStartProjectBackEnd.Common.Dto.Responses;

namespace DDStartProjectBackEnd.Auth.Dto.Responses
{
    public class IsEmailAvailableResponse : BaseResponse
    {
        public bool IsEmailAvailable { get; set; }
    }
}
