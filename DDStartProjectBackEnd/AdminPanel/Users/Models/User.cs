using DDStartProjectBackEnd.Common.Enums;
using System;

namespace DDStartProjectBackEnd.AdminPanel.Users.Models
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public bool Blocked { get; set; }
        public DateTime RegistrationDateUTC { get; set; }
        public string Role { get; set; }
    }
}
