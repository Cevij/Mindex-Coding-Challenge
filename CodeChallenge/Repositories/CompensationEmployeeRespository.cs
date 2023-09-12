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
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="compensationEmployeeContext"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public CompensationEmployeeRespository(ILogger<ICompensationEmployeeRepository> logger, CompensationEmployeeContext compensationEmployeeContext)
        {
            _compensationEmployeeContext = compensationEmployeeContext ?? throw new ArgumentNullException(nameof(compensationEmployeeContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="compensationEmployee"></param>
        /// <returns></returns>
        public Compensation AddCompensationEmployee(Compensation compensationEmployee)
        {
            if(compensationEmployee.CompensationId == null) compensationEmployee.CompensationId = Guid.NewGuid().ToString();

            _compensationEmployeeContext.CompensationEmployees.Add(compensationEmployee);
            return compensationEmployee;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Compensation GetCompensationEmployeeById(string id) => 
            _compensationEmployeeContext.CompensationEmployees.Include(x => x.Employee).Include(x => x.Employee.DirectReports)
            .FirstOrDefault(e => e.Employee.EmployeeId == id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public Compensation Remove(Compensation employee) => _compensationEmployeeContext.Remove(employee).Entity;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task SaveAsync() => _compensationEmployeeContext.SaveChangesAsync();
    }
}
