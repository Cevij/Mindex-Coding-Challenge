using CodeChallenge.Models.Employee;
using CodeChallenge.Repositories;

namespace CodeChallenge.Services.IServices
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Gets employee by using <see cref="Employee.EmployeeId"/> from <see cref="EmployeeRepository"/>
        /// </summary>
        /// <param name="employeeId">Employee Id. </param>
        /// <returns></returns>
        Employee GetById(string employeeId);

        /// <summary>
        /// Gets <see cref="Compensation"/> employee by using <see cref="Employee.EmployeeId"/> from <see cref="CompensationEmployeeRepository"/>
        /// </summary>
        /// <param name="employeeId">Employee Id. </param>
        /// <returns></returns>
        Compensation getCompensationEmployeeById(string employeeId);

        /// <summary>
        /// Adds <see cref="Employee"/> employee to <see cref="EmployeeRepository"/>
        /// </summary>
        /// <param name="employee">New employee </param>
        /// <returns></returns>
        Employee Create(Employee employee);

        /// <summary>
        /// Adds <see cref="Compensation"/> employee to <see cref="CompensationEmployeeRepository"/>
        /// </summary>
        /// <param name="compensationEmployee">New Compensation employee </param>
        /// <returns></returns>
        Compensation CreateCompensationEmployee(Compensation employee);

        /// <summary>
        /// Removing employee from <see cref="EmployeeRepository"/>
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Employee Replace(Employee originalEmployee, Employee newEmployee);
    }
}
