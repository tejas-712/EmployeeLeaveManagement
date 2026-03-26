namespace EmployeeLeaveManagement.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public string AssociateId { get; set; }
        public DateTime LeaveDate { get; set; }
        public string AbsenceType { get; set; } // V, S, P
    }
}
