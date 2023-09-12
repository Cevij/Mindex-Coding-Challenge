using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodeChallenge.Services.IServices;
using CodeChallenge.Controllers.IController;
using CodeChallenge.Models.Employee;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase, IEmployeeController
    {
        private readonly ILogger _logger;
        private readonly IEmployeeService _employeeService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="employeeService"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        /// <inheritdoc cref="ICompensationController"/>
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null) { return NotFound("No new compensation found!"); }
            try
            {
                _logger.LogDebug($"Received employee create request for '{employee.FirstName} {employee.LastName}'");

                var employeeExists = _employeeService.GetById(employee.EmployeeId);
                if (employeeExists != null) {
                    _logger.LogWarning($"Employee with Id:'{employee.EmployeeId}' was already created!");

                    return BadRequest();
                }

                _employeeService.Create(employee);

                return CreatedAtRoute("getEmployeeById", new { id = employee.EmployeeId }, employee);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating employee:'{employee.EmployeeId}'", ex);
            }

            return BadRequest();
        }

        /// <inheritdoc cref="ICompensationController"/>
        [HttpGet("{id}", Name = "getEmployeeById")]
        public IActionResult GetEmployeeById(String id)
        {
            if (id == string.Empty) { return NotFound("No Id was entered!"); }
            try
            {
                _logger.LogDebug($"Received employee get request for '{id}'");

                var employee = _employeeService.GetById(id);

                if (employee == null)
                    return NotFound();

                return Ok(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting employee:'{id}'", ex);
            }

            return BadRequest();

        }

        /// <inheritdoc cref="ICompensationController"/>
        [HttpPut("{id}")]
        public IActionResult ReplaceEmployee(String id, [FromBody]Employee newEmployee)
        {
            if (id == string.Empty) { return NotFound("No Id was entered!"); }
            try
            {
                _logger.LogDebug($"Recieved employee update request for '{id}'");

                var existingEmployee = _employeeService.GetById(id);
                if (existingEmployee == null)
                    return NotFound();

                _employeeService.Replace(existingEmployee, newEmployee);

                return Ok(newEmployee);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating employee:'{id}'", ex);
            }

            return BadRequest();
        }
    }
}
