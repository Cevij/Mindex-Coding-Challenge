using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodeChallenge.Services.IServices;
using CodeChallenge.Controllers.IController;
using CodeChallenge.Models.Employee;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportsController : ControllerBase, IReportsController
    {
        private readonly ILogger _logger;
        private readonly IEmployeeService _employeeService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="employeeService"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ReportsController(ILogger<ReportsController> logger, IEmployeeService employeeService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetReportsById(String id)
        {
            if (id == string.Empty) { return NotFound("No Id was entered!"); }

            try
            {
                _logger.LogDebug($"Received Report get request for '{id}'");

                var employee = _employeeService.GetById(id);

                if (employee == null)
                    return NotFound();

                return Ok(new ReportingStructure() { Employee = employee });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting report structure for employee:'{id}'", ex);
            }

            return BadRequest();
        }
    }
}
