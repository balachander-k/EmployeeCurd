using EmployeeCurd.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCurd.Data
{
    public class ApplicationDbContext:DbContext
    {
     
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Employee> Employees{ get; set; }
    }
}
