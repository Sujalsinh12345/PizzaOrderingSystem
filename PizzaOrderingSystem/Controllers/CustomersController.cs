using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaOrderingSystem.Models;
using PizzaOrderingSystem.Models.DtoClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//om coment
namespace PizzaOrderingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly PizzaOrderingSystemContext _context;

        public CustomersController(PizzaOrderingSystemContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<object>> PostCustomer(Customer customer)
        {
            // Add the customer to the database
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            // Generate a token (you'll need to implement this based on your auth logic)
            var token = GenerateToken(customer); // Implement this method for token generation

            // Generate the response
            var response = new
            {
                success = true,
                message = "Customer created successfully.",
                token = token, // Include the token in the response
                user = customer, // Include user information
                role = "customer" // Assign a default role for a new customer
            };

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, response);
        }


        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }

        //[HttpPost("login")]
        //public async Task<ActionResult> Login([FromBody] CustomerEmployeeLoginDto customerLoginDto)
        //{
        //    if (customerLoginDto.Email == "" || customerLoginDto.Password == "")
        //    {
        //        return BadRequest("Email and Password are required.");
        //    }
        //    if (await _context.Customers
        //        .FirstOrDefaultAsync(c => c.Email == customerLoginDto.Email && c.PassWord == customerLoginDto.Password) != null)
        //    {
        //        return Ok("Login successful.");
        //    }

        //    return Unauthorized("Unauthorized access");

        //}
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] CustomerEmployeeLoginDto customerLoginDto)
        {
            if (string.IsNullOrEmpty(customerLoginDto.Email) || string.IsNullOrEmpty(customerLoginDto.Password))
            {
                return BadRequest(new { message = "Email and Password are required." });
            }

            var customero = await _context.Customers
                .FirstOrDefaultAsync(c => c.Email == customerLoginDto.Email && c.PassWord == customerLoginDto.Password);

            if (customero != null)
            {
                // Assuming you have a Role property in your Customer model
                var role = "customer"; // Get the user's role

                // Generate a token (this is just a placeholder, implement your token generation logic)
                var token = GenerateToken(customero); // Implement this method to generate a JWT or any token

                return Ok(new
                {
                    success = true,
                    message = "Login successful.",
                    token = token, // Include the token in the response
                    user = customero, // Include user information
                    role = role // Include the user's role
                });
            }

            return Unauthorized(new { success = false, message = "Unauthorized access" });
        }

        // Placeholder for token generation logic
        private string GenerateToken(Customer customer)
        {
            // Implement your token generation logic here
            return "your_generated_token"; // Replace with actual token
        }
    }
}
