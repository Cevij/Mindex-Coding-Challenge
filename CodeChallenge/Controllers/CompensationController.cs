using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodeChallenge.Services.IServices;
using CodeChallenge.Controllers.IController;
using CodeChallenge.Models.Employee;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/compensation")]
    public class CompensationController : ControllerBase, ICompensationController
    {
        private readonly ILogger _logger;
        private readonly IEmployeeService _employeeService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="employeeService"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public CompensationController(ILogger<CompensationController> logger, IEmployeeService employeeService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        /// <inheritdoc cref="ICompensationController"/>
        [HttpPost]
        public IActionResult CreateCompensationEmployee([FromBody] Compensation compensationEmployee)
        {
            if (compensationEmployee == null) { return NotFound("No compensation found!"); }
            try
            {
                _logger.LogDebug($"Received create compensation request for employeeId'{compensationEmployee.Employee.EmployeeId}'");

                var employee = _employeeService.GetById(compensationEmployee.Employee.EmployeeId);
                if (employee == null)
                {
                    _logger.LogDebug($"Can not create compensation because employee with id:'{compensationEmployee.Employee.EmployeeId}' don't exists!");
                    return NotFound("No employee was found!");
                }

                compensationEmployee.Employee = employee;

                _employeeService.CreateCompensationEmployee(compensationEmployee);

                return CreatedAtRoute("getCompensationEmployeeById", new { id = compensationEmployee?.Employee?.EmployeeId }, compensationEmployee);
            } catch (Exception ex)
            {
                _logger.LogError($"Error creating compensation employee'{compensationEmployee.Employee.EmployeeId}'", ex);
            }
           

            return BadRequest();
        }

        /// <inheritdoc cref="ICompensationController"/>
        [HttpGet("{id}", Name = "getCompensationEmployeeById")]
        public IActionResult getCompensationEmployeeById(String id)
        {
            if(id == string.Empty) { return NotFound("No Id was entered!"); }
            try
            {
                _logger.LogDebug($"Received compensation employee get request for '{id}'");

                var employee = _employeeService.getCompensationEmployeeById(id);

                if (employee == null)
                    return NotFound("No employee was found!");

                return Ok(employee);
            } catch (Exception ex)
            {
                _logger.LogError($"Error getting compensation employee:'{id}'", ex);
            }
            
            return BadRequest();
        }
    }
}
