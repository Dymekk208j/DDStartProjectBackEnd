using DDStartProjectBackEnd.Common.Dto.Responses;
using System.Collections.Generic;

namespace DDStartProjectBackEnd.Auth.Responses
{
    public class RegisterResponse : BaseResponse
    {
        public bool IsSuccess { get; set; }
        public IList<string> Errors { get; set; }
    }
}
