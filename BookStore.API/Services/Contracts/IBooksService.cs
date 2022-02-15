using BookStore.API.Models;

namespace BookStore.API.Services.Contracts
{
    public interface IBooksService
    {
        public Task<List<Book>> GetAsync();
        public Task<Book?> GetAsync(string id);
        public Task CreateAsync(Book newBook);
        public Task UpdateAsync(string id, Book updatedBook);
        public Task RemoveAsync(string id);
    }
}
