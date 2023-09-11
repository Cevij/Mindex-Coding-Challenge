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

        public CompensationEmployeeRespository(ILogger<ICompensationEmployeeRepository> logger, CompensationEmployeeContext compensationEmployeeContext)
        {
            _compensationEmployeeContext = compensationEmployeeContext ?? throw new ArgumentNullException(nameof(compensationEmployeeContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
        }


        public Compensation AddCompensationEmployee(Compensation compensationEmployee)
        {
            if(compensationEmployee.CompensationId == null) compensationEmployee.CompensationId = Guid.NewGuid().ToString();

            _compensationEmployeeContext.CompensationEmployees.Add(compensationEmployee);
            return compensationEmployee;
        }

        public Compensation GetCompensationEmployeeById(string id) => 
            _compensationEmployeeContext.CompensationEmployees.Include(x => x.Employee).Include(x => x.Employee.DirectReports)
            .FirstOrDefault(e => e.Employee.EmployeeId == id);

        public Compensation Remove(Compensation employee) => _compensationEmployeeContext.Remove(employee).Entity;

        public Task SaveAsync() => _compensationEmployeeContext.SaveChangesAsync();
    }
}
