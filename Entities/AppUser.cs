using Microsoft.AspNetCore.Identity;

namespace Finsmart_final.Entities
{
    public class AppUser : IdentityUser
    {
        public string Others { get; set; } = null!;
    }
}
