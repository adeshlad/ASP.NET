using System.ComponentModel.DataAnnotations;

namespace Book_Management_API.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string? Title { get; set; }

        [Required]
        [StringLength(255)]
        public string? Author { get; set; }

        [Required]
        [Range(1500, 2100)]
        public int Year { get; set; }
    }
}
