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

        public EmployeeRespository(ILogger<IEmployeeRepository> logger, EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
            _logger = logger;
        }

        public Employee Add(Employee employee)
        {
            if(employee.EmployeeId == null) employee.EmployeeId = Guid.NewGuid().ToString();

            _employeeContext.Employees.Add(employee);
            return employee;
        }

        public Employee GetById(string id) => _employeeContext.Employees.Include(x => x.DirectReports)
            .SingleOrDefault(e => e.EmployeeId == id);

        public Task SaveAsync() => _employeeContext.SaveChangesAsync();

        public Employee Remove(Employee employee) => _employeeContext.Remove(employee).Entity;
    }
}
