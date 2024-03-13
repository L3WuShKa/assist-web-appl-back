// EmployeeController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YourBackendProject.Models;
using YourBackendProject.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YourBackendProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Asigură că doar utilizatorii autentificați pot accesa acest controller
    public class EmployeeController : ControllerBase
    {
        private readonly CosmosDbContext _cosmosDbContext;

        public EmployeeController(CosmosDbContext cosmosDbContext)
        {
            _cosmosDbContext = cosmosDbContext;
        }

        /// <summary>
        /// Endpoint pentru obținerea listei de angajați.
        /// </summary>
        [HttpGet("list")]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            var employees = _cosmosDbContext.GetEmployees();
            return Ok(employees);
        }

        /// <summary>
        /// Endpoint pentru obținerea unui angajat după ID.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = _cosmosDbContext.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound(new { Message = $"Employee with ID {id} not found" });
            }

            return Ok(employee);
        }

        /// <summary>
        /// Endpoint pentru adăugarea unui nou angajat.
        /// </summary>
        [HttpPost("add")]
        public ActionResult AddEmployee([FromBody] Employee employee)
        {
            _cosmosDbContext.AddEmployee(employee);
            return Ok(new { Message = "Employee added successfully" });
        }

        /// <summary>
        /// Endpoint pentru actualizarea datelor unui angajat existent.
        /// </summary>
        [HttpPut("update/{id}")]
        public ActionResult UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            var existingEmployee = _cosmosDbContext.GetEmployeeById(id);

            if (existingEmployee == null)
            {
                return NotFound(new { Message = $"Employee with ID {id} not found" });
            }

            _cosmosDbContext.UpdateEmployee(id, updatedEmployee);
            return Ok(new { Message = $"Employee with ID {id} updated successfully" });
        }

        /// <summary>
        /// Endpoint pentru ștergerea unui angajat după ID.
        /// </summary>
        [HttpDelete("delete/{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var existingEmployee = _cosmosDbContext.GetEmployeeById(id);

            if (existingEmployee == null)
            {
                return NotFound(new { Message = $"Employee with ID {id} not found" });
            }

            _cosmosDbContext.DeleteEmployee(id);
            return Ok(new { Message = $"Employee with ID {id} deleted successfully" });
        }
    }
}
