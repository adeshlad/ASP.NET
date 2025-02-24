using Book_Management_API.DTOs;

namespace Book_Management_API.Services
{
    public interface IBookService
    {
        BookResponse AddBook(BookAddRequest request);

        List<BookResponse> GetAllBooks();
        
        BookResponse GetBookById(Guid id);

        List<BookResponse> GetBooksByTitle(string title);

        List<BookResponse> GetBooksByAuthor(string author);

        List<BookResponse> GetBooksByYear(int year);
    }
}
