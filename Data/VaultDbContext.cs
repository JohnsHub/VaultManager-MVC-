using Microsoft.EntityFrameworkCore;

namespace VaultManagerV1.Models
{
    public class VaultDbContext : DbContext
    {
        public DbSet<Vault> Vaults { get; set; }

        public VaultDbContext(DbContextOptions<VaultDbContext> options)
            : base(options)
        {
              
        }
    }
}
