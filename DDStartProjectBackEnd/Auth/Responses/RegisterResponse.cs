using System.Collections.Generic;

namespace DDStartProjectBackEnd.Auth.Responses
{
    public class RegisterResponse
    {
        public bool IsSuccess { get; set; }
        public IList<string> Errors { get; set; }
    }
}
