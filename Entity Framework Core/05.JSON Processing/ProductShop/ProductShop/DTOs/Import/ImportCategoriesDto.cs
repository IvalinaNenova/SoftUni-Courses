using Newtonsoft.Json;

namespace ProductShop.DTOs.Import
{
    public class ImportCategoriesDto
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
