using CodeChallenge.Data.Contexts;
using CodeChallenge.Models.Constants;
using CodeChallenge.Models.Employee;
using CodeChallenge.Services;
using CodeChallenge.Services.IServices;
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

        public EmployeeDataSeeder(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext ?? throw new ArgumentNullException(nameof(employeeContext));
        }

        public async Task Seed()
        {
            if (!_employeeContext.Employees.Any())
            {
                List<Employee> employees = LoadEmployees();
                _employeeContext.Employees.AddRange(employees);

                await _employeeContext.SaveChangesAsync();
            }
        }

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
