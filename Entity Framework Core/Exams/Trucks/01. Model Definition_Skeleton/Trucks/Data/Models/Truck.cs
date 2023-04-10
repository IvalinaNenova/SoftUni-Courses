using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trucks.Data.Models.Enums;

namespace Trucks.Data.Models
{
    public class Truck
    {
        public Truck()
        {
            this.ClientsTrucks = new HashSet<ClientTruck>();
        }
        [Key]
        public int Id { get; set; }

        [MaxLength(8)]
        public string? RegistrationNumber { get; set; }

        [Required] 
        [MaxLength(17)] 
        public string VinNumber { get; set; } = null!;

        public int TankCapacity { get; set; }
        public int CargoCapacity { get; set; }
        public CategoryType CategoryType { get; set; }
        public MakeType MakeType { get; set; }

        [ForeignKey(nameof(Despatcher))]
        public int DespatcherId { get; set; }
        public virtual Despatcher Despatcher { get; set; } = null!;

        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }
    }
}
