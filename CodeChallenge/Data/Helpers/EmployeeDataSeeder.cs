using CodeChallenge.Data.Contexts;
using CodeChallenge.Models.Constants;
using CodeChallenge.Models.Employee;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Data.Helpers
{
    public class EmployeeDataSeeder
    {
        private EmployeeContext _employeeContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="employeeContext"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public EmployeeDataSeeder(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext ?? throw new ArgumentNullException(nameof(employeeContext));
        }

        /// <summary>
        /// Populates DB
        /// </summary>
        /// <returns></returns>
        public async Task Seed()
        {
            if (!_employeeContext.Employees.Any())
            {
                List<Employee> employees = LoadEmployees();
                _employeeContext.Employees.AddRange(employees);

                await _employeeContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Gets list of employees from json
        /// </summary>
        /// <returns>List of employees </returns>
        private List<Employee> LoadEmployees()
        {
            using (FileStream fs = new FileStream(CONFIG_CONSTANTS.EMPLOYEE_SEED_DATA_FILE, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            using (JsonReader jr = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();

                List<Employee> employees = serializer.Deserialize<List<Employee>>(jr);
                FixUpReferences(employees);

                return employees;
            }
        }

        /// <summary>
        /// Modifiy DirectReports
        /// </summary>
        /// <param name="employees"></param>
        private void FixUpReferences(List<Employee> employees)
        {
            var employeeIdRefMap = from employee in employees
                                   select new { Id = employee.EmployeeId, EmployeeRef = employee };

            employees.ForEach(employee =>
            {

                if (employee.DirectReports != null)
                {
                    var referencedEmployees = new List<Employee>(employee.DirectReports.Count);
                    employee.DirectReports.ForEach(report =>
                    {
                        var referencedEmployee = employeeIdRefMap.First(e => e.Id == report.EmployeeId).EmployeeRef;
                        referencedEmployees.Add(referencedEmployee);
                    });
                    employee.DirectReports = referencedEmployees;
                }
            });
        }
    }
}
