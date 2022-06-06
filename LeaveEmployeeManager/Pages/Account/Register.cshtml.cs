using LeaveEmployeeManager.Data;
using LeaveEmployeeManager.Models;
using LeaveEmployeeManager.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeaveEmployeeManager.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private ApplicationDbContext _context;

        [BindProperty]
        public User User { get; set; } = new();
        [BindProperty]
        public string? ValidEmail { get; set; }
        [BindProperty]
        public string? ValidPassword { get; set; }

        public List<SelectListItem> RoleList { get; set; } = new();
        public RegisterModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
           
            RoleList.Add(new SelectListItem { Text = "Sale", Value = CompanyRole.Sale.ToString() });
            RoleList.Add(new SelectListItem { Text = "Human Resources", Value = CompanyRole.Human_Resources.ToString() });
            RoleList.Add(new SelectListItem { Text = "Production", Value = CompanyRole.Production.ToString() });
        }
    }
}
