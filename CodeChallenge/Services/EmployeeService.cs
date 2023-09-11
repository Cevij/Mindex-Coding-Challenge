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

        public EmployeeService(ILogger<EmployeeService> logger, IEmployeeRepository employeeRepository, ICompensationEmployeeRepository compensationEmployeeRepository)
        {
            _compensationEmployeeRepository = compensationEmployeeRepository ?? throw new ArgumentNullException(nameof(compensationEmployeeRepository)); ;
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository)); ;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
        }

        public Employee Create(Employee employee)
        {
            if(employee != null)
            {
                _employeeRepository.Add(employee);
                _employeeRepository.SaveAsync().Wait();
            }

            return employee;
        }

        public Compensation CreateCompensationEmployee(Compensation compensationEmployee)
        {
            if (compensationEmployee != null)
            {
                _compensationEmployeeRepository.AddCompensationEmployee(compensationEmployee);
                _compensationEmployeeRepository.SaveAsync().Wait();
            }

            return compensationEmployee;
        }

        public Employee GetById(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                return _employeeRepository.GetById(id);
            }

            return null;
        }

        public Compensation getCompensationEmployeeById(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                return _compensationEmployeeRepository.GetCompensationEmployeeById(id);
            }

            return null;
        }

        public Compensation ReplaceCompensation(Compensation originalCompensation, Compensation newCompensation) 
        {
            if(originalCompensation != null)
            {
                _compensationEmployeeRepository.Remove(originalCompensation);
                if (newCompensation != null)
                {
                    // ensure the original has been removed, otherwise EF will complain another entity w/ same id already exists
                    _compensationEmployeeRepository.SaveAsync().Wait();

                    _compensationEmployeeRepository.AddCompensationEmployee(newCompensation);
                    // overwrite the new id with previous employee id
                    newCompensation.CompensationId = originalCompensation.CompensationId;
                }
                _compensationEmployeeRepository.SaveAsync().Wait();
            }

            return newCompensation;
        }

        public Employee Replace(Employee originalEmployee, Employee newEmployee)
        {
            if(originalEmployee != null)
            {
                _employeeRepository.Remove(originalEmployee);
                if (newEmployee != null)
                {
                    // ensure the original has been removed, otherwise EF will complain another entity w/ same id already exists
                    _employeeRepository.SaveAsync().Wait();

                    _employeeRepository.Add(newEmployee);
                    // overwrite the new id with previous employee id
                    newEmployee.EmployeeId = originalEmployee.EmployeeId;
                }
                _employeeRepository.SaveAsync().Wait();
            }

            return newEmployee;
        }
    }
}
