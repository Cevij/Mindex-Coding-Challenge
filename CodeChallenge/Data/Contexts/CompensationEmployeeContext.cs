using CodeChallenge.Models.Employee;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Data.Contexts
{
    public class CompensationEmployeeContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public CompensationEmployeeContext(DbContextOptions<CompensationEmployeeContext> options) : base(options)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Compensation> CompensationEmployees { get; set; }
    }
}
