using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Finsmart_final.Entities
{
    public class AppUser
    {
        [Key]
        public int UserId { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public string Others { get; set; } = null!;

        public double Balance { get; set; }


        public virtual ICollection<Transaction>? transactions { get; set; }
    }
}
