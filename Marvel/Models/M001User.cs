using Microsoft.AspNetCore.Identity;

namespace Marvel.Models
{
    public class M001User : IdentityUser
    {
        public string Fullname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
