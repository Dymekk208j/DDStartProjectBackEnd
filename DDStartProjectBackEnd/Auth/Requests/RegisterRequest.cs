using DDStartProjectBackEnd.Common.Dto.Requests;
using DDStartProjectBackEnd.Common.Enums;

namespace DDStartProjectBackEnd.Auth.Requests
{
    public class RegisterRequest : BaseRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Email { get; set; }
        public string EmailConfirm { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
    }
}
