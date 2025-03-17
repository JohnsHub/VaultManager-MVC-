using Microsoft.EntityFrameworkCore;
using VaultManagerV1.Data;

namespace VaultManagerV1.Models
{
    public class VaultDbContext : DbContext
    {
        public DbSet<Vault> Vaults { get; set; }
        public DbSet<Dweller> Dwellers { get; set; } // Your existing tables

        public VaultDbContext(DbContextOptions<VaultDbContext> options)
            : base(options)
        {
        }
    }
}
