namespace EmployeeLeaveManagement.Models
{
    public class Holiday
    {
        public int Id { get; set; }
        public string Name { get; set; }         
        public DateTime Date { get; set; }       
        public string Type { get; set; }         

        
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
