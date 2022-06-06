
using LeaveEmployeeManager.Data;
using LeaveEmployeeManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LeaveEmployeeManager.Pages.LeaveTypes
{
    public class DeleteModel : PageModel
    {
        private ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public LeaveType LeaveType { get; set; } = new();
        public void OnGet(int? id)
        {
            LeaveType = _context.LeaveTypes.FirstOrDefault(x => x.Id == id);
        }

        public IActionResult OnPost()
        {
            _context.LeaveTypes.Remove(LeaveType);
            _context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
