using System;
using Microsoft.AspNetCore.Mvc;
using CodeChallenge.Models.Employee;

namespace CodeChallenge.Controllers.IController
{
    public interface IEmployeeController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public IActionResult CreateEmployee([FromBody] Employee employee);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult GetEmployeeById(String id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newEmployee"></param>
        /// <returns></returns>
        public IActionResult ReplaceEmployee(String id, [FromBody] Employee newEmployee);
    }
}
