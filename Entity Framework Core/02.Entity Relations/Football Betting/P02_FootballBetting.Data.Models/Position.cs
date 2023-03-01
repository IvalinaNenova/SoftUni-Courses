namespace P02_FootballBetting.Data.Models
{
    using Common;
    using System.ComponentModel.DataAnnotations;
    public class Position
    {
        public Position()
        {
            this.Players = new HashSet<Player>();
        }

        [Key]
        public int PositionId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PositionNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Player> Players { get; set; }
    }
}
