
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LeaveEmployeeManager.Models
{
    public class User: IdentityUser
    {
        public string FirstName { get; set; }= string.Empty;

        public string LastName { get; set; } = string.Empty;
        public Department Department { get; set; } 
    }


    public enum Department
    {
        Production,
        Sale,
        Human_Resources,
        Development 
    }
}
