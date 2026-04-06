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

        public DbSet<Role> Roles { get; set; }

        public DbSet<Holiday> Holidays { get; set; }

        
        public DbSet<LeaveBalance> LeaveBalances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- NEW: Explicitly define the One-to-One relationship ---
            modelBuilder.Entity<Employee>()
                        .HasOne(e => e.LeaveBalance)
                        .WithOne(lb => lb.Employee)
                        .HasForeignKey<LeaveBalance>(lb => lb.AssociateId);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Associate" },
                new Role { Id = 2, RoleName = "Senior Associate" },
                new Role { Id = 3, RoleName = "Manager" },
                new Role { Id = 4, RoleName = "Admin" }
            );

            modelBuilder.Entity<Location>().HasData(
            new Location { Id = 1, CityName = "Pune" },
            new Location { Id = 2, CityName = "Hyderabad" },
            new Location { Id = 3, CityName = "Chennai" },
            new Location { Id = 4, CityName = "Kolkata" },
            new Location { Id = 5, CityName = "Bangalore" }
            );

            modelBuilder.Entity<Holiday>().HasData(
    // NATIONAL HOLIDAYS 
    new Holiday { Id = 1, Name = "Republic Day", Type = "National", Date = new DateTime(2026, 1, 26), LocationId = 1 },
    new Holiday { Id = 2, Name = "Republic Day", Type = "National", Date = new DateTime(2026, 1, 26), LocationId = 2 },
    new Holiday { Id = 3, Name = "Republic Day", Type = "National", Date = new DateTime(2026, 1, 26), LocationId = 3 },
    new Holiday { Id = 4, Name = "Republic Day", Type = "National", Date = new DateTime(2026, 1, 26), LocationId = 4 },
    new Holiday { Id = 5, Name = "Republic Day", Type = "National", Date = new DateTime(2026, 1, 26), LocationId = 5 },

    new Holiday { Id = 6, Name = "May Day", Type = "National", Date = new DateTime(2026, 5, 1), LocationId = 1 },
    new Holiday { Id = 7, Name = "May Day", Type = "National", Date = new DateTime(2026, 5, 1), LocationId = 2 },
    new Holiday { Id = 8, Name = "May Day", Type = "National", Date = new DateTime(2026, 5, 1), LocationId = 3 },
    new Holiday { Id = 9, Name = "May Day", Type = "National", Date = new DateTime(2026, 5, 1), LocationId = 4 },
    new Holiday { Id = 10, Name = "May Day", Type = "National", Date = new DateTime(2026, 5, 1), LocationId = 5 },

    new Holiday { Id = 11, Name = "Gandhi Jayanti", Type = "National", Date = new DateTime(2026, 10, 2), LocationId = 1 },
    new Holiday { Id = 12, Name = "Gandhi Jayanti", Type = "National", Date = new DateTime(2026, 10, 2), LocationId = 2 },
    new Holiday { Id = 13, Name = "Gandhi Jayanti", Type = "National", Date = new DateTime(2026, 10, 2), LocationId = 3 },
    new Holiday { Id = 14, Name = "Gandhi Jayanti", Type = "National", Date = new DateTime(2026, 10, 2), LocationId = 4 },
    new Holiday { Id = 15, Name = "Gandhi Jayanti", Type = "National", Date = new DateTime(2026, 10, 2), LocationId = 5 },

    new Holiday { Id = 16, Name = "Christmas", Type = "National", Date = new DateTime(2026, 12, 25), LocationId = 1 },
    new Holiday { Id = 17, Name = "Christmas", Type = "National", Date = new DateTime(2026, 12, 25), LocationId = 2 },
    new Holiday { Id = 18, Name = "Christmas", Type = "National", Date = new DateTime(2026, 12, 25), LocationId = 3 },
    new Holiday { Id = 19, Name = "Christmas", Type = "National", Date = new DateTime(2026, 12, 25), LocationId = 4 },
    new Holiday { Id = 20, Name = "Christmas", Type = "National", Date = new DateTime(2026, 12, 25), LocationId = 5 },

    // REGIONAL HOLIDAYS 
    new Holiday { Id = 21, Name = "New Year", Type = "Regional", Date = new DateTime(2026, 1, 1), LocationId = 1 },
    new Holiday { Id = 22, Name = "New Year", Type = "Regional", Date = new DateTime(2026, 1, 1), LocationId = 3 },
    new Holiday { Id = 23, Name = "New Year", Type = "Regional", Date = new DateTime(2026, 1, 1), LocationId = 5 },

    new Holiday { Id = 24, Name = "Pongal/Sankranti", Type = "Regional", Date = new DateTime(2026, 1, 15), LocationId = 2 },
    new Holiday { Id = 25, Name = "Pongal/Sankranti", Type = "Regional", Date = new DateTime(2026, 1, 15), LocationId = 3 },
    new Holiday { Id = 26, Name = "Pongal/Sankranti", Type = "Regional", Date = new DateTime(2026, 1, 15), LocationId = 5 },

    new Holiday { Id = 27, Name = "Holi", Type = "Regional", Date = new DateTime(2026, 3, 3), LocationId = 1 },
    new Holiday { Id = 28, Name = "Doljatra", Type = "Regional", Date = new DateTime(2026, 3, 3), LocationId = 4 },

    new Holiday { Id = 29, Name = "Ugadi", Type = "Regional", Date = new DateTime(2026, 3, 19), LocationId = 2 },
    new Holiday { Id = 30, Name = "Ugadi", Type = "Regional", Date = new DateTime(2026, 3, 19), LocationId = 5 },

    new Holiday { Id = 31, Name = "Ramzan", Type = "Regional", Date = new DateTime(2026, 3, 20), LocationId = 1 },
    new Holiday { Id = 32, Name = "Ramzan", Type = "Regional", Date = new DateTime(2026, 3, 20), LocationId = 2 },
    new Holiday { Id = 33, Name = "Ramzan", Type = "Regional", Date = new DateTime(2026, 3, 20), LocationId = 3 },
    new Holiday { Id = 34, Name = "Ramzan", Type = "Regional", Date = new DateTime(2026, 3, 20), LocationId = 4 },
    new Holiday { Id = 35, Name = "Ramzan", Type = "Regional", Date = new DateTime(2026, 3, 20), LocationId = 5 },

    new Holiday { Id = 36, Name = "Tamil New Year", Type = "Regional", Date = new DateTime(2026, 4, 14), LocationId = 3 },
    new Holiday { Id = 37, Name = "Bengali New Year", Type = "Regional", Date = new DateTime(2026, 4, 15), LocationId = 4 },
    new Holiday { Id = 38, Name = "Telangana Formation", Type = "Regional", Date = new DateTime(2026, 6, 2), LocationId = 2 },

    new Holiday { Id = 39, Name = "Ganesh Chaturthi", Type = "Regional", Date = new DateTime(2026, 9, 14), LocationId = 1 },
    new Holiday { Id = 40, Name = "Ganesh Chaturthi", Type = "Regional", Date = new DateTime(2026, 9, 14), LocationId = 3 },
    new Holiday { Id = 41, Name = "Ganesh Chaturthi", Type = "Regional", Date = new DateTime(2026, 9, 14), LocationId = 5 },

    new Holiday { Id = 42, Name = "VijayaDasami", Type = "Regional", Date = new DateTime(2026, 10, 20), LocationId = 1 },
    new Holiday { Id = 43, Name = "VijayaDasami", Type = "Regional", Date = new DateTime(2026, 10, 20), LocationId = 3 },
    new Holiday { Id = 44, Name = "Durga Puja", Type = "Regional", Date = new DateTime(2026, 10, 21), LocationId = 4 }
);
        }
    }
}
