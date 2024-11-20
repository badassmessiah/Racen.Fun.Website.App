using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Racen.Fun.Website
{
    public class Country
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }
    }
}