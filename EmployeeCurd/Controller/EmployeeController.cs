using EmployeeCurd.Dtos;
using EmployeeCurd.Models;
using EmployeeCurd.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCurd.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _employeeService.GetAllAsync();

            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employeebyId = await _employeeService.GetEmployeeByIdAsync(id);

            if (employeebyId is null)
                return NotFound();
            return Ok(employeebyId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeDto emp)
        {
            var createemployee = await _employeeService.CreateEmployeeAsync(emp);

            return Ok(createemployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeDto emp)
        {
            var updateEmployee = await _employeeService.UpdateEmployeeAsync(id, emp);

            return Ok(updateEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var deleteEmployee = await _employeeService.DeletebyAsync(id);

            if (!deleteEmployee)
                return NotFound();

            return NoContent();
        }

    }
}
