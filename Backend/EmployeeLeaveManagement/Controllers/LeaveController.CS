using ClosedXML.Excel;
using EmployeeLeaveManagement.DTO;
using EmployeeLeaveManagement.Services;
using EmployeeLeaveManagement.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLeaveManagement.Controllers
{
    [Route("api/[controller]")] // Becomes "api/Leave"
    [ApiController]
    // 🚨 IMPORTANT: Make sure this is named LeaveController, NOT LeaveBalance! 🚨
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveService _leaveService;

        public LeaveController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }

        [HttpGet("balances/{associateId}")]
        public async Task<IActionResult> GetLeaveBalances(string associateId)
        {
            var balances = await _leaveService.GetBalancesAsync(associateId);

            if (balances == null)
                return NotFound(new { message = "Employee not found." });

            return Ok(balances);
        }

        [HttpPost("apply")]
        public async Task<IActionResult> ApplyLeave([FromBody] LeaveRequestdto req)
        {
            var result = await _leaveService.ApplyLeaveAsync(req);

            if (!result.Success)
                return BadRequest(result.Message); // Returns the specific error from the service

            return Ok(result.Message);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var leaves = await _leaveService.GetAllLeavesAsync();
            return Ok(leaves);
        }

        [HttpGet("download")]
        public async Task<IActionResult> DownloadExcel()
        {
            var leaves = await _leaveService.GetAllLeavesAsync();

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("LeaveReport");

            // Headers
            worksheet.Cell(1, 1).Value = "Associate ID";
            worksheet.Cell(1, 2).Value = "Date";
            worksheet.Cell(1, 3).Value = "Type";

            // Data rows
            for (int i = 0; i < leaves.Count; i++)
            {
                worksheet.Cell(i + 2, 1).Value = leaves[i].AssociateId;
                worksheet.Cell(i + 2, 2).Value = leaves[i].LeaveDate.ToString("yyyy-MM-dd");
                worksheet.Cell(i + 2, 3).Value = leaves[i].AbsenceType;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();

            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "LeaveTracker.xlsx");
        }
    }
}