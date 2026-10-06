using EmployeeCurd.Dtos;

namespace EmployeeCurd.Services.Contracts
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllAsync();

        Task<EmployeeDto?> GetEmployeeByIdAsync(int id);

        Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto dto);

        Task<EmployeeDto?> UpdateEmployeeAsync(int id, EmployeeDto dto);

        Task<bool> DeletebyAsync(int id);
    }
}
