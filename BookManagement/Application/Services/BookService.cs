using BookManagement.Application.DTOs;
using BookManagement.Application.Interfaces;
using BookManagement.Domain.Entities;
using BookManagement.Infrastructure.Interfaces;

namespace BookManagement.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRespository;

        public BookService(IBookRepository bookRespository)
        {
            _bookRespository = bookRespository;
        }

        public async Task<BookResponse> AddBook(BookAddRequest request)
        {
            Book book = request.ToBook();
            await _bookRespository.AddAsync(book);

            return new BookResponse(book);
        }

        public async Task<IEnumerable<BookResponse>> GetAllBooks()
        {
            IEnumerable<Book> books = await _bookRespository.GetAllAsync();

            return books.Select(book => new BookResponse(book)).ToList();
        }

        public async Task<BookResponse?> GetBookById(Guid id)
        {
            Book? book = await _bookRespository.GetByIdAsync(id);

            if (book == null)
            {
                return null;
            }

            return new BookResponse(book);
        }

        public async Task<IEnumerable<BookResponse>> GetBooksByParams(string? title, string? author, int? year)
        {
            IEnumerable<Book> books = await _bookRespository.GetByParamsAsync(title, author, year);

            return books.Select(book => new BookResponse(book)).ToList();
        }

        public async Task<BookResponse?> UpdateBook(Guid id, BookUpdateRequest request)
        {
            string title = request.Title;
            string author = request.Author;
            int year = request.Year;

            Book? book = await _bookRespository.UpdateAsync(id, title, author, year);

            if (book == null)
            {
                return null;
            }

            return new BookResponse(book);
        }

        public async Task<bool> DeleteBook(Guid id)
        {
            bool status = await _bookRespository.DeleteAsync(id);

            return status;
        }
    }
}
