using EmployeeLeaveManagement.Data;
using EmployeeLeaveManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> AddEmployee([FromBody] Employee request)
        {

            // Validate model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = await _context.Employees
           .FirstOrDefaultAsync(e => e.AssociateId == request.AssociateId);

            if (existingUser != null)
            {
                return BadRequest(new { message = "Associate ID already exists." });
            }

            var roleExists = await _context.Roles.AnyAsync(r => r.Id == request.RoleId);
            if (!roleExists)
            {
                return BadRequest(new { message = "Invalid Role selected." });
            }
            request.LeaveBalance = new LeaveBalance
            {
                SickLeave = 12.00m,
                CasualLeave = 6.00m,
                EarnedLeave = 6.00m
            };

            _context.Employees.Add(request);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Employee added successfully!" });
        }

        //all employee
        [HttpGet("all")]
        public IActionResult GetAllEmployee()
        {
            return Ok(_context.Employees.ToList());
        }
    }
}
