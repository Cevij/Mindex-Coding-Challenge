using CodeChallenge.Models.Employee;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Data.Contexts
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
