using BookDapper.Models;

namespace BookDapper.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee1>> GetEmployees();
        Task<Employee1> GetEmployeeById(int id);
        Task<int> AddEmployee(Employee1 employee);
        Task<int> UpdateEmployee(Employee1 employee);
        Task<int> DeleteEmployee(int id);
    }
}
