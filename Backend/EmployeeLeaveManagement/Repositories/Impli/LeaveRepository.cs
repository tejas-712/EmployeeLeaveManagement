using EmployeeLeaveManagement.Data;
using EmployeeLeaveManagement.Models;
using EmployeeLeaveManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLeaveManagement.Repositories
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly AppDbContext _context;

        public LeaveRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Employee?> GetEmployeeWithBalancesAsync(string associateId)
        {
            return await _context.Employees
                .Include(e => e.LeaveBalance)
                .FirstOrDefaultAsync(e => e.AssociateId == associateId);
        }

        public async Task<bool> CheckEmployeeExistsAsync(string associateId)
        {
            return await _context.Employees.AnyAsync(e => e.AssociateId == associateId);
        }

        public async Task<bool> CheckDuplicateLeaveAsync(string associateId, DateTime leaveDate)
        {
            // Note: Make sure _context.LeaveRequest matches your exact AppDbContext DbSet name!
            return await _context.LeaveRequest.AnyAsync(l =>
                l.AssociateId == associateId &&
                l.LeaveDate.Date == leaveDate.Date);
        }

        public async Task AddLeaveRequestAsync(LeaveRequest request)
        {
            _context.LeaveRequest.Add(request);
            await _context.SaveChangesAsync();
        }

        public async Task<List<LeaveRequest>> GetAllLeaveRequestsAsync()
        {
            return await _context.LeaveRequest.ToListAsync();
        }
    }
}