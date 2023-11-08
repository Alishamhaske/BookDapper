using Microsoft.Data.SqlClient;
using System.Data;
namespace BookDapper.Data
{

    public class ApplicationDbContext
    {
        private readonly IConfiguration _configuration;

        private readonly string _connectionString;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
            
    }
}
