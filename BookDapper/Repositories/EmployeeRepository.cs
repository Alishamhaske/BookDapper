using Dapper;
using BookDapper.Data;
using BookDapper.Models;

namespace BookDapper.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> AddEmployee(Employee1 employee)
        {
            int result = 0;
            var query = "insert into Employee1 values(@id,@name,@salary,@city)";
            var parameters = new DynamicParameters();
            parameters.Add("@id", employee.Id);
            parameters.Add("@name", employee.Name);
            parameters.Add("@salary", employee.Salary);
            parameters.Add("@city", employee.City);
            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, parameters);
            }
            return result;
        }

        public async Task<int> DeleteEmployee(int id)
        {
            int result = 0;
            var query = "delete from Employee1 where id=@id";

            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, new { id });
            }
            return result;
        }

        public async Task<Employee1> GetEmployeeById(int id)
        {
            var qry = "select * from Employee1 where id=@id";
            using (var connection = context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<Employee1>(qry, new { id });
                return result;
            }
        }

        public async Task<IEnumerable<Employee1>> GetEmployees()
        {
            var qry = "select * from Employee1";
            using (var connection = context.CreateConnection())
            {
                var result = await connection.QueryAsync<Employee1>(qry);
                return result.ToList();
            }
        }

        public async Task<int> UpdateEmployee(Employee1 employee)
        {
            int result = 0;
            var query = "update Employee1 set name=@name,salary=@salary,city=@city where id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@name", employee.Name);
            parameters.Add("@salary", employee.Salary);
            parameters.Add("@city", employee.City);
            parameters.Add("@id", employee.Id);
            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, parameters);
            }
            return result;
        }
    }
}
