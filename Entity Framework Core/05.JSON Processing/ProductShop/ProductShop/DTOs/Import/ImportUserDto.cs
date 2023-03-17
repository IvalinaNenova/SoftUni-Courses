using Newtonsoft.Json;

namespace ProductShop.DTOs.Import
{
    public class ImportUserDto
    {
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; } = null!;
        [JsonProperty("age")]
        public int? Age { get; set; }
    }
}
