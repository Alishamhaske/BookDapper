using BookDapper.Models;
using BookDapper.Repositories;

namespace BookDapper.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository repo;
        public EmployeeService(IEmployeeRepository repo)
        {
            this.repo = repo;
        }
        public async Task<int> AddEmployee(Employee1 employee)
        {
            return await repo.AddEmployee(employee);
        }

        public async Task<int> DeleteEmployee(int id)
        {
            return await repo.DeleteEmployee(id);
        }

        public async Task<Employee1> GetEmployeeById(int id)
        {
            return await repo.GetEmployeeById(id);
        }

        public async Task<IEnumerable<Employee1>> GetEmployees()
        {
            return await repo.GetEmployees();
        }

        public async Task<int> UpdateEmployee(Employee1 employee)
        {
            return await repo.UpdateEmployee(employee);
        }
    }
}
