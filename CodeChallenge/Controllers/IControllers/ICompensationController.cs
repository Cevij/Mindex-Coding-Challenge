using System;
using Microsoft.AspNetCore.Mvc;
using CodeChallenge.Models.Employee;

namespace CodeChallenge.Controllers.IController
{
    public interface ICompensationController
    {
        /// <summary>
        /// POST method for adding new compensation employee.
        /// </summary>
        /// <param name="compensationEmployee">New compensation employee being added. </param>
        /// <returns></returns>
        public IActionResult CreateCompensationEmployee([FromBody] Compensation compensationEmployee);

        /// <summary>
        /// GET method for retrieving compensation employee by employeeId
        /// </summary>
        /// <param name="employeeId">Employee Id.</param>
        /// <returns></returns>
        public IActionResult getCompensationEmployeeById(String employeeId);
    }
}
