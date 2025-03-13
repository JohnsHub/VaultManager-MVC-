namespace VaultManagerV1.Models
{
    public class Dweller
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;

        // Stats
        public int Strength { get; set; }
        public int Perception { get; set; }
        public int Endurance { get; set; }
        public int Charisma { get; set; }
        public int Intelligence { get; set; }
        public int Agility { get; set; }
        public int Luck { get; set; }

        // Foreign Key
        public int VaultId { get; set; }
        public Vault? Vault { get; set; }
    }

}
