using EmployeeLeaveManagement.DTO;
using EmployeeLeaveManagement.Models;
using EmployeeLeaveManagement.Repositories;
using EmployeeLeaveManagement.Repositories.Interfaces;
using EmployeeLeaveManagement.Services.Interfaces;

namespace EmployeeLeaveManagement.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly ILeaveRepository _repository;

        public LeaveService(ILeaveRepository repository)
        {
            _repository = repository;
        }

        public async Task<object?> GetBalancesAsync(string associateId)
        {
            var employee = await _repository.GetEmployeeWithBalancesAsync(associateId);

            if (employee == null) return null;

            if (employee.LeaveBalance == null)
            {
                return new { sickLeave = 0, casualLeave = 0, earnedLeave = 0 };
            }

            return new
            {
                sickLeave = employee.LeaveBalance.SickLeave,
                casualLeave = employee.LeaveBalance.CasualLeave,
                earnedLeave = employee.LeaveBalance.EarnedLeave
            };
        }

        public async Task<(bool Success, string Message)> ApplyLeaveAsync(LeaveRequestdto req)
        {
            if (string.IsNullOrEmpty(req.AssociateId))
                return (false, "AssociateId is Required");

            // 1. Fetch the employee AND their current balances
            var employee = await _repository.GetEmployeeWithBalancesAsync(req.AssociateId);

            if (employee == null)
                return (false, "Invalid Associate Id");

            if (employee.LeaveBalance == null)
                return (false, "Leave balances not set up for this employee.");

            // 2. Prevent duplicate leave
            var exists = await _repository.CheckDuplicateLeaveAsync(req.AssociateId, req.LeaveDate);
            if (exists)
                return (false, "Leave already applied for this date");

            // 3. DEDUCT THE BALANCE (and prevent negative balances!)
            if (req.AbsenceType == "S")
            {
                if (employee.LeaveBalance.SickLeave < 1)
                    return (false, "Insufficient Sick Leave balance.");

                employee.LeaveBalance.SickLeave -= 1; // Subtract 1 day
            }
            else if (req.AbsenceType == "C")
            {
                if (employee.LeaveBalance.CasualLeave < 1)
                    return (false, "Insufficient Casual Leave balance.");

                employee.LeaveBalance.CasualLeave -= 1; // Subtract 1 day
            }
            else if (req.AbsenceType == "V") // "V" for Vacation/Earned in your HTML
            {
                if (employee.LeaveBalance.EarnedLeave < 1)
                    return (false, "Insufficient Earned Leave balance.");

                employee.LeaveBalance.EarnedLeave -= 1; // Subtract 1 day
            }
            else
            {
                return (false, "Invalid Leave Type.");
            }

            // 4. Create the Leave Request record
            var newLeave = new LeaveRequest
            {
                AssociateId = req.AssociateId,
                LeaveDate = req.LeaveDate,
                AbsenceType = req.AbsenceType
            };

            // 5. Save everything to the database
            // Because EF Core tracks changes, this will save the new request AND the updated balance simultaneously!
            await _repository.AddLeaveRequestAsync(newLeave);

            return (true, "Leave Applied Successfully");
        }

        public async Task<List<LeaveRequest>> GetAllLeavesAsync()
        {
            return await _repository.GetAllLeaveRequestsAsync();
        }
    }
}