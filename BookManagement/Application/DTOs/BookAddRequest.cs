using BookManagement.Domain.Entities;

namespace BookManagement.Application.DTOs
{
    public class BookAddRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
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
