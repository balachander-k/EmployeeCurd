using EmployeeCurd.Dtos;
using EmployeeCurd.Models;
using EmployeeCurd.Repository.Contracts;
using EmployeeCurd.Services.Contracts;

namespace EmployeeCurd.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto dto)
        {
            var employee = new Employee
            {
                Name = dto.Name,
                Role = dto.Role,
                Salary = dto.Salary,
                Department = dto.Department,
            };

            var createEmployee = await _employeeRepository.CreateEmployeeAsync(employee);

            return new EmployeeDto
            {
                Id=createEmployee.Id,
                Name = createEmployee.Name,
                Role = createEmployee.Role,
                Salary = createEmployee.Salary,
                Department = createEmployee.Department
            };
        }

        public async Task<bool> DeletebyAsync(int id)
        {
           return await _employeeRepository.DeleteByIdAsync(id);

        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();

            return employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                Salary = e.Salary,
                Role = e.Role,
                Department = e.Department
            }).ToList();
        }

        public async Task<EmployeeDto?> GetEmployeeByIdAsync(int id)
        {
            var employeeById = await _employeeRepository.GetByIdAsync(id);

            return new EmployeeDto
            {
                Id = employeeById.Id,
                Name = employeeById.Name,
                Salary = employeeById.Salary,
                Role = employeeById.Role,
                Department = employeeById.Department
            };
        }

        public async Task<EmployeeDto?> UpdateEmployeeAsync(int id, EmployeeDto dto)
        {
            var update = new Employee
            {
                Name = dto.Name,
                Salary = dto.Salary,
                Role = dto.Role,
                Department = dto.Department
            };

            var Updateemployee = await _employeeRepository.UpdateByIdAsync(id, update);

            return new EmployeeDto
            {
                Id = Updateemployee.Id,
                Name = Updateemployee.Name,
                Salary = Updateemployee.Salary,
                Role = Updateemployee.Role,
                Department = Updateemployee.Department
            };
        }
    }
}
