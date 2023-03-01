namespace P02_FootballBetting.Data.Models
{
    using Common;
    using System.ComponentModel.DataAnnotations;
    public class User
    {
        public User()
        {
            this.Bets = new HashSet<Bet>();
        }
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.UsernameMaxLength)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(GlobalConstants.UserPasswordMaxLength)]
        public string Password { get; set; } = null!;

        [Required]
        [MaxLength(GlobalConstants.UserEmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(GlobalConstants.UserNameMaxLength)]
        public string Name { get; set; } = null!;

        public decimal Balance { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
