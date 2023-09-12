using CodeChallenge.Models.Employee;
using System.Threading.Tasks;
using CodeChallenge.Data.Contexts;

namespace CodeChallenge.Repositories.IRepositories
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Gets employee by using <see cref="Employee.EmployeeId"/>
        /// </summary>
        /// <param name="employeeId">Employee Id. </param>
        /// <returns></returns>
        Employee GetById(string employeeId);

        /// <summary>
        /// Adds <see cref="Employee"/> employee to <see cref="EmployeeContext"/>
        /// </summary>
        /// <param name="employee">New employee </param>
        /// <returns></returns>
        Employee Add(Employee employee);

        /// <summary>
        /// Removing employee from <see cref="EmployeeContext"/>
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Employee Remove(Employee employee);

        /// <summary>
        /// Apply changes made to <see cref="EmployeeContext"/>
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();
    }
}