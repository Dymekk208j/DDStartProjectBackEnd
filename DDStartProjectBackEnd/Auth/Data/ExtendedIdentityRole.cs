using Microsoft.AspNetCore.Identity;

namespace DDStartProjectBackEnd.Auth.Data
{
    public class ExtendedIdentityRole : IdentityRole<string>
    {
        public ExtendedIdentityRole() { }

        public string Description { get; set; }
    }
}
