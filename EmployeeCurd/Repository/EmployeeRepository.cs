using EmployeeCurd.Data;
using EmployeeCurd.Models;
using EmployeeCurd.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCurd.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Employee> CreateEmployeeAsync(Employee emp)
        {
            _context.Employees.Add(emp);

            await _context.SaveChangesAsync();

            return emp;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id==id);

            if (employee == null)
                return false;

            _context.Employees.RemoveRange(employee);

            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id==id);
        }

        public async Task<Employee?> UpdateByIdAsync(int id, Employee emp)
        {
            var existingEmployee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if (existingEmployee == null)
                return null;

            existingEmployee.Name = emp.Name;
            existingEmployee.Role = emp.Role;
            existingEmployee.Salary = emp.Salary;
            existingEmployee.Department = emp.Department;

            await _context.SaveChangesAsync();

            return existingEmployee;

        }
    }
}
