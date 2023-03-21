using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer.DTOs.Import
{
    public class ImportPartDtos
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("supplierId")]
        public int SupplierId { get; set; }
    }
}
