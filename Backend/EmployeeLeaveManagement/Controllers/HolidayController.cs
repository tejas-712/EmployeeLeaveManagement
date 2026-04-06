using EmployeeLeaveManagement.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLeaveManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HolidayController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("upcoming/{associateId}")]
        public async Task<IActionResult> GetUpcomingHolidays(string associateId)
        {
            // 1. Find the employee to get their LocationId
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.AssociateId == associateId);

            if (employee == null)
            {
                return NotFound(new { message = "Employee not found" });
            }

            // 2. Get the next 3 holidays for their location!
            
            var upcomingHolidays = await _context.Holidays
                .Where(h => h.LocationId == employee.LocationId && h.Date >= DateTime.Today)
                .OrderBy(h => h.Date)
                .Take(3)
                .ToListAsync();

            return Ok(upcomingHolidays);
        }
    }
}

