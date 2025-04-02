using BookManagement.Book.DTOs;

namespace BookManagement.Book.Services
{
    public interface IBookService
    {
        Task<BookResponse> AddBook(BookAddRequest request);

        Task<IEnumerable<BookResponse>> GetAllBooks();

        Task<BookResponse?> GetBookById(Guid id);

        Task<IEnumerable<BookResponse>> GetBooksByAttributes(string? title, string? author, int? year);

        Task<BookResponse?> UpdateBook(Guid id, BookUpdateRequest request);

        Task<bool> DeleteBook(Guid id);
    }
}
