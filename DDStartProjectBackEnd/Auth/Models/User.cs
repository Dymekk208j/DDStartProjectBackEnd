using DDStartProjectBackEnd.Common.Enums;
using Microsoft.AspNetCore.Identity;

namespace DDStartProjectBackEnd.Auth.Models
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Gender Gender { get; set; }
    }
}
