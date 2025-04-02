using System.ComponentModel.DataAnnotations;

namespace BookManagement.Book
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string Author { get; set; } = string.Empty;

        [Required]
        [Range(1500, 2100)]
        public int Year { get; set; }
    }
}
