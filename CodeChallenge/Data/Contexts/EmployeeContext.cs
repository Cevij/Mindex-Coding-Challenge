using CodeChallenge.Models.Employee;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Data.Contexts
{
    public class EmployeeContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        /// <summary>
        /// Db set containing employees
        /// </summary>
        public DbSet<Employee> Employees { get; set; }
    }
}
