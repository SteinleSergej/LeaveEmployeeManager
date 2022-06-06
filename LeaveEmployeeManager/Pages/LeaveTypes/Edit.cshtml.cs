
using LeaveEmployeeManager.Data;
using LeaveEmployeeManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LeaveEmployeeManager.Pages.LeaveTypes
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public LeaveType LeaveType { get; set; } = new();
        public void OnGet(int? id)
        {
            LeaveType = _context.LeaveTypes.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
              
                LeaveType.DateModified = DateTime.Now;
                _context?.LeaveTypes?.Update(LeaveType);
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
