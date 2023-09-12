using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CodeChallenge.Repositories.IRepositories;
using CodeChallenge.Data.Contexts;
using CodeChallenge.Models.Employee;

namespace CodeChallenge.Repositories
{
    public class EmployeeRespository : IEmployeeRepository
    {
        private readonly EmployeeContext _employeeContext;
        private readonly ILogger<IEmployeeRepository> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="employeeContext"></param>
        public EmployeeRespository(ILogger<IEmployeeRepository> logger, EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
            _logger = logger;
        }

        /// <inheritdoc cref="IEmployeeRepository"/>
        public Employee Add(Employee employee)
        {
            if (employee.EmployeeId == null) employee.EmployeeId = Guid.NewGuid().ToString();
            _logger.LogInformation($"Employee Repository: Adding Employee with employee id:{employee.EmployeeId} to DB");
            _employeeContext.Employees.Add(employee);
            return employee;
        }

        /// <inheritdoc cref="IEmployeeRepository"/>
        public Employee GetById(string employeeId)
        {
            _logger.LogInformation($"Employee Repository: Retrieving employee with employee id:{employeeId} from DB");
            return _employeeContext.Employees.Include(x => x.DirectReports)
            .FirstOrDefault(e => e.EmployeeId == employeeId);
        }

        /// <inheritdoc cref="IEmployeeRepository"/>
        public Task SaveAsync()
        {
            _logger.LogInformation($"Employee Repository: Save changes to Compensation employee DB");
            return _employeeContext.SaveChangesAsync();
        }

        /// <inheritdoc cref="IEmployeeRepository"/>
        public Employee Remove(Employee employee)
        {
            _logger.LogInformation($"Employee Repository: Removing employee with employee id:{employee.EmployeeId} from DB");
            return _employeeContext.Remove(employee).Entity;
        }
    }
}
