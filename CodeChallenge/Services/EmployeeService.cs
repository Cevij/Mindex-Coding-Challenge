using System;
using Microsoft.Extensions.Logging;
using CodeChallenge.Repositories.IRepositories;
using CodeChallenge.Repositories;
using CodeChallenge.Services.IServices;
using CodeChallenge.Models.Employee;

namespace CodeChallenge.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICompensationEmployeeRepository _compensationEmployeeRepository;
        private readonly ILogger<EmployeeService> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="employeeRepository"></param>
        /// <param name="compensationEmployeeRepository"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public EmployeeService(ILogger<EmployeeService> logger, IEmployeeRepository employeeRepository, ICompensationEmployeeRepository compensationEmployeeRepository)
        {
            _compensationEmployeeRepository = compensationEmployeeRepository ?? throw new ArgumentNullException(nameof(compensationEmployeeRepository)); ;
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository)); ;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
        }

        /// <inheritdoc cref="IEmployeeService"/>
        public Employee Create(Employee employee)
        {
            _logger.LogInformation($"Service: Trying to add Employee with employee id:{employee.EmployeeId} to DB");
            if (employee != null)
            {
                _logger.LogInformation($"Service: Adding Employee with employee id:{employee.EmployeeId} to DB");
                _employeeRepository.Add(employee);
                _employeeRepository.SaveAsync().Wait();
            }

            return employee;
        }

        /// <inheritdoc cref="IEmployeeService"/>
        public Compensation CreateCompensationEmployee(Compensation compensationEmployee)
        {
            _logger.LogInformation($"Service: Trying to add Compensation Employee with employee id:{compensationEmployee.Employee.EmployeeId} and" +
                $"CompensationId:{compensationEmployee.CompensationId} to DB");
            if (compensationEmployee != null)
            {
                _logger.LogInformation($"Service: Adding Compensation Employee with employee id:{compensationEmployee.Employee.EmployeeId} and" +
                $"CompensationId:{compensationEmployee.CompensationId} to DB");
                _compensationEmployeeRepository.AddCompensationEmployee(compensationEmployee);
                _compensationEmployeeRepository.SaveAsync().Wait();
            }

            return compensationEmployee;
        }

        /// <inheritdoc cref="IEmployeeService"/>
        public Employee GetById(string employeeId)
        {
            if(!String.IsNullOrEmpty(employeeId))
            {
                _logger.LogInformation($"Service: Retrieving employee with employee id:{employeeId} from DB");
                return _employeeRepository.GetById(employeeId);
            }
            _logger.LogWarning($"Service: Can't retrieve employee with null or empty string Id");

            return null;
        }

        /// <inheritdoc cref="IEmployeeService"/>
        public Compensation getCompensationEmployeeById(string employeeId)
        {
            if (!String.IsNullOrEmpty(employeeId))
            {
                _logger.LogInformation($"Service: Retrieving compensation employee with employee id:{employeeId} from DB");
                return _compensationEmployeeRepository.GetCompensationEmployeeById(employeeId);
            }
            _logger.LogInformation($"Service: Can't retrieving compensation employee with employee id:{employeeId} from DB");

            return null;
        }

        /// <inheritdoc cref="IEmployeeService"/>
        public Employee Replace(Employee originalEmployee, Employee newEmployee)
        {
            if(originalEmployee != null)
            {
                _logger.LogInformation($"Service: Removing employee with employee id:{originalEmployee.EmployeeId} from DB");
                _employeeRepository.Remove(originalEmployee);
                if (newEmployee != null)
                {
                    _logger.LogInformation($"Service: Saving context for DB");
                    // ensure the original has been removed, otherwise EF will complain another entity w/ same id already exists
                    _employeeRepository.SaveAsync().Wait();

                    _logger.LogInformation($"Service: Adding replacement employee with employee id:{newEmployee.EmployeeId} to DB");
                    _employeeRepository.Add(newEmployee);
                    // overwrite the new id with previous employee id
                    newEmployee.EmployeeId = originalEmployee.EmployeeId;
                }
                _employeeRepository.SaveAsync().Wait();
            }
            _logger.LogInformation($"Service: Replacement Complete!");
            return newEmployee;
        }
    }
}
