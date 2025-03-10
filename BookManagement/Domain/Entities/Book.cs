using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.Domain.Entities
{
    public class Book
    {
        [Key]
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        [JsonProperty("author")]
        public string Author { get; set; } = string.Empty;

        [Required]
        [Range(1500, 2100)]
        [JsonProperty("year")]
        public int Year { get; set; }
    }
}
