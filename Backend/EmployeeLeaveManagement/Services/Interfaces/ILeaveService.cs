using EmployeeLeaveManagement.DTO;
using EmployeeLeaveManagement.Models;

namespace EmployeeLeaveManagement.Services.Interfaces
{
    public interface ILeaveService
    {
        Task<object?> GetBalancesAsync(string associateId);
        Task<(bool Success, string Message)> ApplyLeaveAsync(LeaveRequestdto req);
        Task<List<LeaveRequest>> GetAllLeavesAsync();
    }
}
