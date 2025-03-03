using BookManagement.Domain.Entities;

namespace BookManagement.Infrastructure.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> AddAsync(Book book);

        Task<IEnumerable<Book>> GetAllAsync();

        Task<Book?> GetByIdAsync(Guid id);

        Task<IEnumerable<Book>> GetByAttributesAsync(string? title, string? author, int? year);

        Task<Book?> UpdateAsync(Guid id, string title, string author, int year);

        Task<bool> DeleteAsync(Guid id);
    }
}
