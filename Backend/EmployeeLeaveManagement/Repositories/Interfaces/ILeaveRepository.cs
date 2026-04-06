using EmployeeLeaveManagement.Models;

namespace EmployeeLeaveManagement.Repositories.Interfaces
{
    public interface ILeaveRepository
    {
       
        Task<Employee?> GetEmployeeWithBalancesAsync(string associateId);
        Task<bool> CheckEmployeeExistsAsync(string associateId);
        Task<bool> CheckDuplicateLeaveAsync(string associateId, DateTime leaveDate);
        Task AddLeaveRequestAsync(LeaveRequest request);
        Task<List<LeaveRequest>> GetAllLeaveRequestsAsync();
    }
}
