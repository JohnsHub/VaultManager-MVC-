using Microsoft.EntityFrameworkCore;

namespace VaultManagerV1.Models
{
    public class VaultDbContext : DbContext
    {
        public DbSet<Vault> Vaults { get; set; }
        public DbSet<Dweller> Dwellers { get; set; } // Add this line

        public VaultDbContext(DbContextOptions<VaultDbContext> options)
            : base(options)
        {

        }
    }
}
