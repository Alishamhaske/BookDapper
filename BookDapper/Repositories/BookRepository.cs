
using Dapper;
using BookDapper.Data;
using BookDapper.Models;
using BookDapper.Repositories;


namespace BookDapper.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext context;

        public BookRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> AddBook(Book book)
        {
            int result = 0;
            var query = "insert into Book values(@name,@author,@price)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", book.Name);
            parameters.Add("@author", book.Author);
            parameters.Add("@price", book.Price);
            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, parameters);
            }
            return result;
        }

        public async Task<int> DeleteBook(int id)
        {
            int result = 0;
            var query = "delete from Book where id=@id";

            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, new { id });
            }
            return result;
        }

        public async Task<Book> GetBookById(int id)
        {
            var qry = "select * from Book where id=@id";
            using (var connection = context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<Book>(qry, new { id });
                return result;
            }
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var qry = "select * from Book";
            using (var connection = context.CreateConnection())
            {
                var result = await connection.QueryAsync<Book>(qry);
                return result.ToList();
            }
        }

        public async Task<int> UpdateBook(Book book)
        {
            int result = 0;
            var query = "update Book set name=@name,author=@author,price=@price where id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@name", book.Name);
            parameters.Add("@author", book.Author);
            parameters.Add("@price", book.Price);
            parameters.Add("@id", book.Id);
            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, parameters);
            }
            return result;
        }
    }
}
