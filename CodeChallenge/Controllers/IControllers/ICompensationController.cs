using System;
using Microsoft.AspNetCore.Mvc;
using CodeChallenge.Models.Employee;

namespace CodeChallenge.Controllers.IController
{
    public interface ICompensationController
    {

        public IActionResult CreateCompensationEmployee([FromBody] Compensation compensationEmployee);

        public IActionResult getCompensationEmployeeById(String id);

        public IActionResult ReplaceCompensation(String id, [FromBody] Compensation newEmployee);
    }
}
