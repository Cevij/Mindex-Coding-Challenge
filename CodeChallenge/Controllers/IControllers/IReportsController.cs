using System;
using Microsoft.AspNetCore.Mvc;
using CodeChallenge.Models.Employee;

namespace CodeChallenge.Controllers.IController
{
    public interface IReportsController
    {
        /// <summary>
        /// GET method get employee and return it as <see cref="ReportingStructure"/>.
        /// </summary>
        /// <param name="employeeId">Employee Id.</param>
        /// <returns><see cref="ReportingStructure"/></returns>
        public IActionResult GetReportsById(String employeeId);
    }
}
