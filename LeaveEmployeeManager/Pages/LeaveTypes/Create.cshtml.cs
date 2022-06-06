
using LeaveEmployeeManager.Data;
using LeaveEmployeeManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LeaveEmployeeManager.Pages.LeaveTypes
{
    public class CreateModel : PageModel
    {
        private ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public LeaveType LeaveType { get; set; } = new();
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                LeaveType.DateCreated = DateTime.Now;
                LeaveType.DateModified = DateTime.Now;
                _context?.LeaveTypes?.Add(LeaveType);
                await _context!.SaveChangesAsync();

            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("LeaveType.Name", "Connecting to DB failed");
            }
            return RedirectToPage("Index");
        }
    }
}
