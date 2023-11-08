using BookDapper.Models;
using BookDapper.Repositories;

namespace BookDapper.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository repo;
        public BookService(IBookRepository repo)
        {
            this.repo = repo;
        }
        public async Task<int> AddBook(Book book)
        {
            return await repo.AddBook(book);
        }

        public async Task<int> DeleteBook(int id)
        {
            return await repo.DeleteBook(id);
        }

        public async Task<Book> GetBookById(int id)
        {
            return await repo.GetBookById(id);
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await repo.GetBooks();
        }

        public async Task<int> UpdateBook(Book book)
        {
            return await repo.UpdateBook(book);
        }
    }
}
