namespace VaultManagerV1.Models
{
    public class Vault
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        // Navigation Property
        public List<Dweller> Dwellers { get; set; } = new();
    }

}
