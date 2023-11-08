
using Dapper;
using BookDapper.Data;
using BookDapper.Models;

namespace BookDapper.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext context;
        public StudentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> AddStudent(Student student)
        {
            int result = 0;
            var query = "insert into Student values(@name,@percentage,@city)";
            var parameters = new DynamicParameters();

            parameters.Add("@name", student.Name);
            parameters.Add("@percentage", student.Percentage);
            parameters.Add("@city", student.City);
            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, parameters);
            }
            return result;
        }

        public async Task<int> DeleteStudent(int id)
        {
            int result = 0;
            var query = "delete from Student where id=@id";

            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, new { id });
            }
            return result;
        }



        public async Task<Student> GetStudentById(int id)
        {
            var qry = "select * from Student where id=@id";
            using (var connection = context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<Student>(qry, new { id });
                return result;
            }
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            var qry = "select * from Student";
            using (var connection = context.CreateConnection())
            {
                var result = await connection.QueryAsync<Student>(qry);
                return result.ToList();
            }
        }

        public async Task<int> UpdateStudent(Student student)
        {
            int result = 0;
            var query = "update Book set name=@name,percentage=@percentage,city=@city where id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@name", student.Name);
            parameters.Add("@percentage", student.Percentage);
            parameters.Add("@city", student.City);
            parameters.Add("@id", student.Id);
            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, parameters);
            }
            return result;
        }
    }
}
