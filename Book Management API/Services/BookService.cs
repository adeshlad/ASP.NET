using Book_Management_API.Data;
using Book_Management_API.DTOs;
using Book_Management_API.Models;
using System;

namespace Book_Management_API.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _dbContext;

        public BookService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BookResponse AddBook(BookAddRequest request)
        {
            Book book = request.ToBook();
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

            return new BookResponse(book);
        }

        public List<BookResponse> GetAllBooks()
        {
            return _dbContext.Books.Select(book => new BookResponse(book)).ToList();
        }

        public BookResponse? GetBookById(Guid id)
        {
            Book? book = _dbContext.Books.FirstOrDefault(book => book.Id == id);

            if (book == null)
            {
                return null;
            }

            return new BookResponse(book);
        }

        public List<BookResponse> GetBooksByTitle(string title)
        {
            List<BookResponse> books = _dbContext.Books.Where(book => book.Title == title).Select(book => new BookResponse(book)).ToList();

            return books;
        }

        public List<BookResponse> GetBooksByAuthor(string author)
        {
            List<BookResponse> books = _dbContext.Books.Where(book => book.Author == author).Select(book => new BookResponse(book)).ToList();

            return books;
        }

        public List<BookResponse> GetBooksByYear(int year)
        {
            List<BookResponse> books = _dbContext.Books.Where(book => book.Year == year).Select(book => new BookResponse(book)).ToList();

            return books;
        }

        public BookResponse? UpdateBookById(Guid id, BookUpdateRequest request)
        {
            Book? book = _dbContext.Books.FirstOrDefault(book => book.Id == id);

            if (book == null)
            {
                return null;
            }

            book.Title = request.Title ?? book.Title;
            book.Author = request.Author ?? book.Author;
            book.Year = request.Year != 0 ? request.Year : book.Year;

            _dbContext.SaveChanges();

            return new BookResponse(book);
        }

        public bool DeleteBookById(Guid id)
        {
            Book? book = _dbContext.Books.FirstOrDefault(book => book.Id == id);

            if (book == null)
            {
                return false;
            }

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
