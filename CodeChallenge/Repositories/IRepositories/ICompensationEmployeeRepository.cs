using CodeChallenge.Models.Employee;
using System.Threading.Tasks;
using CodeChallenge.Data.Contexts;

namespace CodeChallenge.Repositories
{
    public interface ICompensationEmployeeRepository
    {
        /// <summary>
        /// Adds <see cref="Compensation"/> employee to <see cref="CompensationEmployeeContext"/>
        /// </summary>
        /// <param name="compensationEmployee">New Compensation employee </param>
        /// <returns></returns>
        Compensation AddCompensationEmployee(Compensation compensationEmployee);

        /// <summary>
        /// Gets <see cref="Compensation"/> employee by using <see cref="Employee.EmployeeId"/>
        /// </summary>
        /// <param name="employeeId">Employee Id. </param>
        /// <returns></returns>
        Compensation GetCompensationEmployeeById(string employeeId);

        /// <summary>
        /// Apply changes made to <see cref="CompensationEmployeeContext"/>
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();
    }
}