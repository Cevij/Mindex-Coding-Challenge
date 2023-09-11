using System;
using Microsoft.AspNetCore.Mvc;
using CodeChallenge.Models.Employee;

namespace CodeChallenge.Controllers.IController
{
    public interface IEmployeeController
    {

        public IActionResult CreateEmployee([FromBody] Employee employee);

        public IActionResult GetEmployeeById(String id);

        public IActionResult ReplaceEmployee(String id, [FromBody] Employee newEmployee);
    }
}
