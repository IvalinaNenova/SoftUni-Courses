namespace P02_FootballBetting.Data.Models
{
    using Common;
    using System.ComponentModel.DataAnnotations;
    public class Country
    {
        public Country()
        {
            this.Towns = new HashSet<Town>();
        }

        [Key]
        public int CountryId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ColorNameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Town> Towns { get; set; }
    }
}
