

using Finsmart_final.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Finsmart_v19.Data
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts)
        {
            
        }

        #region Dbset
        public DbSet<AppUser> appUsers { get; set; }
        public DbSet<Transaction>? Transaction { get; set; }
        #endregion
    }
}
