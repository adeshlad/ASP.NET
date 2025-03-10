using BookManagement.Domain.Entities;
using BookManagement.Infrastructure.Data;
using BookManagement.Infrastructure.Interfaces;
using Microsoft.Azure.Cosmos;

namespace BookManagement.Infrastructure.Repositories
{
    public class CosmosBookRepository : IBookRepository
    {
        private readonly Container _container;

        public CosmosBookRepository(CosmosDbContext cosmosDbContext)
        {
            _container = cosmosDbContext.Container;
        }

        public async Task<Book> AddAsync(Book book)
        {
            await _container.CreateItemAsync(book, new PartitionKey(book.Id.ToString()));
            return book;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var query = _container.GetItemQueryIterator<Book>(new QueryDefinition("SELECT * FROM c"));
            List<Book> results = new();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response);
            }
            return results;
        }

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            try
            {
                ItemResponse<Book> response = await _container.ReadItemAsync<Book>(id.ToString(), new PartitionKey(id.ToString()));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Book>> GetByAttributesAsync(string? title, string? author, int? year)
        {
            return [];
        }
        
        public async Task<Book?> UpdateAsync(Guid id, string title, string author, int year)
        {
            return null;
        }
        
        public async Task<bool> DeleteAsync(Guid id)
        {
            await _container.DeleteItemAsync<Book>(id.ToString(), new PartitionKey(id.ToString()));
            return true;
        }
    }
}
