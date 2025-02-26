using Book_Management_API.DTOs;

namespace Book_Management_API.Services
{
    public interface IBookService
    {
        public BookResponse AddBook(BookAddRequest request);

        public List<BookResponse> GetAllBooks();

        public BookResponse? GetBookById(Guid id);

        public List<BookResponse> GetBooksByTitle(string title);

        public List<BookResponse> GetBooksByAuthor(string author);

        public List<BookResponse> GetBooksByYear(int year);

        public BookResponse? UpdateBookById(Guid id, BookUpdateRequest request);

        public bool DeleteBookById(Guid id);
    }
}
