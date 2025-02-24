using Book_Management_API.Models;

namespace Book_Management_API.DTOs
{
    public class BookAddRequest
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int Year { get; set; }

        public Book ToBook()
        {
            return new Book
            {
                Id = Guid.NewGuid(),
                Title = Title,
                Author = Author,
                Year = Year
            };
        }
    }
}
