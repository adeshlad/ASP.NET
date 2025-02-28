using BookManagement.Domain.Entities;
using BookManagement.Infrastructure.Data;
using BookManagement.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Book> AddAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();

            return book;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Books.FindAsync(id);
        }

        public async Task<IEnumerable<Book>> GetByParamsAsync(string? title, string? author, int? year)
        {
            IQueryable<Book> books = _dbContext.Books;

            if (!string.IsNullOrWhiteSpace(title))
                books = books.Where(book => book.Title.Contains(title));

            if (!string.IsNullOrWhiteSpace(author))
                books = books.Where(book => book.Author.Contains(author));

            if (year.HasValue)
                books = books.Where(book => book.Year == year.Value);

            return await books.ToListAsync();
        }

        public async Task<Book?> UpdateAsync(Guid id, string title, string author, int year)
        {
            Book? book = await _dbContext.Books.FindAsync(id);

            if (book == null)
            {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(title))
            {
                book.Title = title;
            }

            if (!string.IsNullOrWhiteSpace(author))
            {
                book.Author = author;
            }

            if (year != 0)
            {
                book.Year = year;
            }

            await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Book? book = await _dbContext.Books.FindAsync(id);

            if (book == null)
                return false;

            _dbContext.Books.Remove(book);

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
