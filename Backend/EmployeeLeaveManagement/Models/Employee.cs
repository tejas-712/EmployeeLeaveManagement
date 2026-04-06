using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaveManagement.Models
{
    public class Employee
    {
        [Key]
        [Required(ErrorMessage = "AssociateId is required")]
        [MinLength(1, ErrorMessage = "AssociateId cannot be empty")]
        public string AssociateId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }

        public int RoleId { get; set; }
        public Role? Role { get; set; }

        public int LocationId { get; set; }
        public Location? Location { get; set; }

        //NEW: One-to-One Relationship ---
        public LeaveBalance? LeaveBalance { get; set; }
    }
}
