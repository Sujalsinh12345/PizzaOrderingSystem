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

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] AdminLoginDto adminLoginDto)
        {
            if (adminLoginDto.UserName == "" || adminLoginDto.Password == "")
            {
                return BadRequest("Username and Password cannot be empty");
            }
            if (await _context.Admins.FirstOrDefaultAsync(a => a.UserName == adminLoginDto.UserName && a.Password == adminLoginDto.Password) != null)
            {
                return Ok("Login Successful");
            }
            else
            {
                return Unauthorized("Invalid Username or Password");
            }
        }

    }
}