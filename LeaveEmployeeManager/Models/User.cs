﻿using LeaveEmployeeManager.Utilities;
using System.ComponentModel.DataAnnotations;

namespace LeaveEmployeeManager.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Role")]
        public CompanyRole Role { get; set; } = CompanyRole.Production;
    }
}
