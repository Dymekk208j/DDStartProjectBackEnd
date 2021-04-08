using DDStartProjectBackEnd.Common.Dto.Responses;
using System.Collections.Generic;

namespace DDStartProjectBackEnd.Auth.Dto.Responses
{
    public class RegisterResponse : BaseResponse
    {
        public bool IsSuccess { get; set; }
        public IList<string> Errors { get; set; }
    }
}
