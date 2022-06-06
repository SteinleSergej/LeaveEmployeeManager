using System.ComponentModel.DataAnnotations;

namespace LeaveEmployeeManager.Models
{
    public class LeaveType
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(1,40,ErrorMessage = "Minimum is 1 day and Maximum is 40 days")]
        public int DefaultDays { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
