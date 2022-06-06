namespace LeaveEmployeeManager.Models
{
    public class LeaveAllocation
    {
        public int Id { get; set; }

        public int NumberOfDays { get; set; }

        public int LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; } = new();

        public string EmployeeId { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
