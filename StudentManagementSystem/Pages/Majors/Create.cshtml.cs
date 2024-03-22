using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.Majors
{
    public class CreateModel : PageModel
    {
        private readonly StudentManagementSystem.Models.PRN221_StudentManagementSystemContext _context;

        public CreateModel(StudentManagementSystem.Models.PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {

            return Page();
        }

        [BindProperty]
        public Major major { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Majors == null || _context.Majors == null)
            {
                return Page();
            }

            _context.Majors.Add(major);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        
         }
    }
}
