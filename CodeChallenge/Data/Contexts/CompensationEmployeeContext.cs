using CodeChallenge.Models.Employee;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Data.Contexts
{
    public class CompensationEmployeeContext : DbContext
    {
        /// <summary>
        /// Consturctor
        /// </summary>
        /// <param name="options"></param>
        public CompensationEmployeeContext(DbContextOptions<CompensationEmployeeContext> options) : base(options)
        {

        }

        /// <summary>
        /// Db set containing compensation employees
        /// </summary>
        public DbSet<Compensation> CompensationEmployees { get; set; }
    }
}
