using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeLeaveManagement.Models
{
    public class LeaveBalance
    {
        public int Id { get; set; }

        // The actual balances
        // --- ADD THESE 3 LINES ---
        [Column(TypeName = "decimal(18,2)")]
        public decimal SickLeave { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CasualLeave { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal EarnedLeave { get; set; }

        //  Foreign Key to Employee (One-to-One) ---
        public string AssociateId { get; set; }
        public Employee? Employee { get; set; }
    }
}
