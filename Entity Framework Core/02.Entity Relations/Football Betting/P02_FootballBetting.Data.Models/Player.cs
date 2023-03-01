namespace P02_FootballBetting.Data.Models
{
    using Common;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Player
    {
        public Player()
        {
            this.PlayersStatistics = new HashSet<PlayerStatistic>();
        }

        [Key]
        public int PlayerId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PlayerNameMaxLength)]
        public string Name { get; set; } = null!;

        public byte SquadNumber { get; set; }

        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; } = null!; 

        [ForeignKey(nameof(Position))]
        public int PositionId { get; set; }

        public virtual Position Position { get; set; } = null!;

        public bool IsInjured { get; set; }

        public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; }
    }
}
