using EmployeeLeaveManagement.Data;
using EmployeeLeaveManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLeaveManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        // For login
        [HttpPost("login")]
        public IActionResult Login(string associateId, string password)
        {
            var user = _context.Employees.FirstOrDefault(e =>
            e.AssociateId == associateId &&
            e.Password == password);

            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }
            return Ok(user);
        }
        // to add employee
        [HttpPost("add")]
        public IActionResult AddEmployee(Employee emp)
        {

            // Validate model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Employees.Add(emp);
            _context.SaveChanges();

            return Ok(new { message = "Employee added successfully" });
        }

        //all employee
        [HttpGet("all")]
        public IActionResult GetAllEmployee()
        {
            return Ok(_context.Employees.ToList());
        }
    }
}
