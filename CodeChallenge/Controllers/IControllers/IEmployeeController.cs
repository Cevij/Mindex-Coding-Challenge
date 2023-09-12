using System;
using Microsoft.AspNetCore.Mvc;
using CodeChallenge.Models.Employee;

namespace CodeChallenge.Controllers.IController
{
    public interface IEmployeeController
    {
        /// <summary>
        /// POST method used to create employee.
        /// </summary>
        /// <param name="employee">New employee.</param>
        /// <returns></returns>
        public IActionResult CreateEmployee([FromBody] Employee employee);

        /// <summary>
        /// GET method to retrieve employee.
        /// </summary>
        /// <param name="employeeId">Employee Id.</param>
        /// <returns></returns>
        public IActionResult GetEmployeeById(String employeeId);

        /// <summary>
        /// PUT method to replace old employee with new employee.
        /// </summary>
        /// <param name="employeeId">Old employee Id.</param>
        /// <param name="newEmployee">New employee to be added</param>
        /// <returns></returns>
        public IActionResult ReplaceEmployee(String employeeId, [FromBody] Employee newEmployee);
    }
}
