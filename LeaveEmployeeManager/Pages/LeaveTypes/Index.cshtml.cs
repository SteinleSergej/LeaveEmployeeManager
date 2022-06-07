
using LeaveEmployeeManager.Data;
using LeaveEmployeeManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LeaveEmployeeManager.Pages.LeaveTypes
{
  
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _context;

        public LeaveType? LeaveType { get; set; }

        public IEnumerable<LeaveType>? LeaveTypes { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            LeaveTypes = _context?.LeaveTypes?.ToList();

        }
    }
}
