using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CodeChallenge.Data.Contexts;
using CodeChallenge.Models.Employee;

namespace CodeChallenge.Repositories
{
    public class CompensationEmployeeRespository : ICompensationEmployeeRepository
    {
        private readonly CompensationEmployeeContext _compensationEmployeeContext;
        private readonly ILogger<ICompensationEmployeeRepository> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="compensationEmployeeContext"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public CompensationEmployeeRespository(ILogger<ICompensationEmployeeRepository> logger, CompensationEmployeeContext compensationEmployeeContext)
        {
            _compensationEmployeeContext = compensationEmployeeContext ?? throw new ArgumentNullException(nameof(compensationEmployeeContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
        }

        /// <inheritdoc cref="ICompensationEmployeeRepository"/>
        public Compensation AddCompensationEmployee(Compensation compensationEmployee)
        {
            if(compensationEmployee.CompensationId == null) compensationEmployee.CompensationId = Guid.NewGuid().ToString();
            _logger.LogInformation($"Compensation Employee Repository: Adding Compensation employee with employee id:{compensationEmployee.Employee.EmployeeId} " +
                $"and compensationId:{compensationEmployee.CompensationId} to DB");
            _compensationEmployeeContext.CompensationEmployees.Add(compensationEmployee);
            return compensationEmployee;
        }

        /// <inheritdoc cref="ICompensationEmployeeRepository"/>
        public Compensation GetCompensationEmployeeById(string employeeId)
        {
            _logger.LogInformation($"Compensation Employee Repository: Retrieving Compensation employee with employee id:{employeeId} from DB");

           return _compensationEmployeeContext.CompensationEmployees.Include(x => x.Employee).Include(x => x.Employee.DirectReports)
            .FirstOrDefault(e => e.Employee.EmployeeId == employeeId);

        }

        /// <inheritdoc cref="ICompensationEmployeeRepository"/>
        public Task SaveAsync() {
            _logger.LogInformation($"Compensation Employee Repository: Save changes to Compensation employee DB");
            return _compensationEmployeeContext.SaveChangesAsync(); }
        }
}
