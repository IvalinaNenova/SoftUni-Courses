namespace P02_FootballBetting.Data.Models
{
    using Common;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    public class Color
    {
        public Color()
        {
            this.PrimaryKitTeams = new HashSet<Team>();
            this.SecondaryKitTeams = new HashSet<Team>();
        }
        [Key]
        public int ColorId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ColorNameMaxLength)]
        public string Name { get; set; }

        [InverseProperty(nameof(Team.PrimaryKitColor))]
        public virtual HashSet<Team> PrimaryKitTeams { get; set; }

        [InverseProperty(nameof(Team.SecondaryKitColor))]
        public virtual HashSet<Team> SecondaryKitTeams { get; set; }
    }
}
