using EmployeeLeaveManagement.Data;
using EmployeeLeaveManagement.DTO;
using EmployeeLeaveManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLeaveManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LeaveController(AppDbContext context)
        {
            _context = context;
        }

        //apply leave 
        [HttpPost("apply")]
        public IActionResult ApplyLeave([FromBody] LeaveRequestdto req)
        {
            //validate assosiate id
            if (string.IsNullOrEmpty(req.AssociateId))
                return BadRequest("associateId is Required ");
            //check employee exists 
            var employeeExists = _context.Employees.Any(e => e.AssociateId == req.AssociateId);

            if (!employeeExists)
                return BadRequest("Invalid Associate Id ");


            //prevent duplicate leave


            var exists = _context.LeaveRequest.Any(l =>
                   l.AssociateId == req.AssociateId &&
                   l.LeaveDate.Date == req.LeaveDate.Date);


            if (exists)
                return BadRequest("Leave already appllied");

            var leav = new LeaveRequest
            {

                AssociateId = req.AssociateId,
                LeaveDate = req.LeaveDate,
                AbsenceType = req.AbsenceType

            };

            //save the leave
            _context.LeaveRequest.Add(leav);
            _context.SaveChanges();
            return Ok("leave Applied");

        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_context.LeaveRequest.ToList());
        }
    }
}
