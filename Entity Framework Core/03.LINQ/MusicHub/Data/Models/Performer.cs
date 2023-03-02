using System.ComponentModel.DataAnnotations;
using MusicHub.Common;

namespace MusicHub.Data.Models
{
    public class Performer
    {
        public Performer()
        {
            this.PerformerSongs = new HashSet<SongPerformer>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(GlobalConstants.PerformerFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [MaxLength(GlobalConstants.PerformerLastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        public int Age { get; set; }

        [Required]
        public decimal NetWorth { get; set; }

        public ICollection<SongPerformer> PerformerSongs { get; set; }
    }
}
