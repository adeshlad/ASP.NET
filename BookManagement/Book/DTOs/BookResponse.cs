namespace BookManagement.Book.DTOs
{
    public class BookResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public BookResponse(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            Author = book.Author;
            Year = book.Year;
        }
    }
}
