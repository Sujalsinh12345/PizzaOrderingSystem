using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaOrderingSystem.Models;
using PizzaOrderingSystem.Models.DtoClasses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaOrderingSystem.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly PizzaOrderingSystemContext _context;
        public AdminController(PizzaOrderingSystemContext context)
        {
            _context = context;
        }

        //[HttpPost("login")]
        //public async Task<ActionResult> Login([FromBody] AdminLoginDto adminLoginDto)
        //{
        //    if (adminLoginDto.Email == "" || adminLoginDto.Password == "")
        //    {
        //        return BadRequest("Username and Password cannot be empty");
        //    }
        //    if (await _context.Admins.FirstOrDefaultAsync(a => a.Email == adminLoginDto.Email && a.Password == adminLoginDto.Password) != null)
        //    {
        //        return Ok("Login Successful");
        //    }
        //    else
        //    {
        //        return Unauthorized("Invalid Username or Password");
        //    }
        //}
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] AdminLoginDto AdminLoginDto)
        {
            // Validate input
            if (string.IsNullOrEmpty(AdminLoginDto.Email) || string.IsNullOrEmpty(AdminLoginDto.Password))
            {
                return BadRequest(new { message = "Email and Password are required." });
            }

            // Fetch user from the database
            var Admin = await _context.Admins
                .FirstOrDefaultAsync(e => e.Email == AdminLoginDto.Email && e.Password == AdminLoginDto.Password);

            // Check if user exists
            if (Admin != null)
            {
                // Generate a JWT token or any authentication token
                var token = GenerateToken(Admin); // Implement this method for token generation
                var role = "Admin"; // Set user role

                return Ok(new
                {
                    success = true,
                    message = "Login successful.",
                    token, // Include token
                    user = Admin
                });
            }

            // Unauthorized response
            return Unauthorized(new { success = false, message = "Unauthorized access" });
        }

        private object GenerateToken(Admin admin)
        {
            return "your_generated_token";
        }


    }
}