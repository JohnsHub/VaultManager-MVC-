namespace VaultManagerV1.Models
{
    public class Dweller
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

        // Foreign Key
        public int VaultId { get; set; }

        // Navigation Property
        public Vault Vault { get; set; }

        // Computed Property for Location (Not mapped in the database)
        public string VaultLocation => Vault?.Location ?? "Unknown";
    }
}
