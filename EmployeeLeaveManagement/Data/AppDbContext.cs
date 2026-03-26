using EmployeeLeaveManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLeaveManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<LeaveRequest> LeaveRequest => Set<LeaveRequest>();
    }
}
