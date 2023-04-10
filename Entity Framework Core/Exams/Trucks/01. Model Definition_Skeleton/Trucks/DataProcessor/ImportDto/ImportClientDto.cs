using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Trucks.Data.Models;

namespace Trucks.DataProcessor.ImportDto
{
    public class ImportClientDto
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; } = null!;

        [JsonProperty("Nationality")]
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Nationality { get; set; } = null!;

        [Required]
        public string Type { get; set; } = null!;

        [JsonProperty("Trucks")]
        public int[] TruckIds { get; set; }
    }
}
