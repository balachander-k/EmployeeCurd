using EmployeeCurd.Models;

namespace EmployeeCurd.Repository.Contracts
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();

        Task<Employee?> GetByIdAsync(int id);

        Task<Employee> CreateEmployeeAsync(Employee emp);

        Task<Employee?> UpdateByIdAsync(int id, Employee emp);

        Task<bool> DeleteByIdAsync(int id);

    }
}
