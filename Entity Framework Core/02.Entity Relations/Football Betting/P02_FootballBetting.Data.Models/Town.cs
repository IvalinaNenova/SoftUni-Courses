namespace P02_FootballBetting.Data.Models
{
    using P02_FootballBetting.Data.Common;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Town
    {
        public Town()
        {
            this.Teams = new HashSet<Team>();
        }

        [Key]
        public int TownId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.TownNameMaxLength)]
        public string Name { get; set; } = null!;

        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;

        public virtual ICollection<Team> Teams { get; set; }
    }
}
