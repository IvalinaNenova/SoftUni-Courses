using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class Album
    {
        public Album()
        {
            this.Songs = new HashSet<Song>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.AlbumNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public DateTime ReleaseDate { get; set; }

        //TODO: Price - calculated property

        [NotMapped]
        public decimal Price => this.Songs.Count > 0 ? Songs.Sum(x => x.Price) : 0m;

        [ForeignKey(nameof(Producer))]
        public int? ProducerId { get; set; }
        public virtual Producer? Producer { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
