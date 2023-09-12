using System;
using Microsoft.AspNetCore.Mvc;
using CodeChallenge.Models.Employee;

namespace CodeChallenge.Controllers.IController
{
    public interface ICompensationController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="compensationEmployee"></param>
        /// <returns></returns>
        public IActionResult CreateCompensationEmployee([FromBody] Compensation compensationEmployee);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult getCompensationEmployeeById(String id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newEmployee"></param>
        /// <returns></returns>
        public IActionResult ReplaceCompensation(String id, [FromBody] Compensation newEmployee);
    }
}
