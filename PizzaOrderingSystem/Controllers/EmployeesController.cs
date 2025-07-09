using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaOrderingSystem.Models;
using PizzaOrderingSystem.Models.DtoClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly PizzaOrderingSystemContext _context;

        public EmployeesController(PizzaOrderingSystemContext context)
        {
            _context = context;
        }

        // GET: api/Employees1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/Employees1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/Employees1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }

        //[HttpPost("login")]
        //public async Task<ActionResult> Login([FromBody] CustomerEmployeeLoginDto customerLoginDto)
        //{
        //    if (customerLoginDto.Email == "" || customerLoginDto.Password == "")
        //    {
        //        return BadRequest("Email and Password are required.");
        //    }
        //    if (await _context.Employees
        //        .FirstOrDefaultAsync(c => c.Email == customerLoginDto.Email && c.PassWord == customerLoginDto.Password) != null)
        //    {
        //        return Ok("Login successful.");
        //    }

        //    return Unauthorized("Unauthorized access");

        //}
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] CustomerEmployeeLoginDto customerLoginDto)
        {
            // Validate input
            if (string.IsNullOrEmpty(customerLoginDto.Email) || string.IsNullOrEmpty(customerLoginDto.Password))
            {
                return BadRequest(new { message = "Email and Password are required." });
            }

            // Fetch user from the database
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Email == customerLoginDto.Email && e.PassWord == customerLoginDto.Password);

            // Check if user exists
            if (employee != null)
            {
                // Generate a JWT token or any authentication token
                var token = GenerateToken(employee); // Implement this method for token generation
                var role = "employee"; // Set user role

                return Ok(new
                {
                    success = true,
                    message = "Login successful.",
                    token, // Include token
                    user = employee
                });
            }

            // Unauthorized response
            return Unauthorized(new { success = false, message = "Unauthorized access" });
        }
        private string GenerateToken(Employee employee)
        {
            // Implement your token generation logic here
            return "your_generated_token"; // Replace with actual token
        }

    }
}
