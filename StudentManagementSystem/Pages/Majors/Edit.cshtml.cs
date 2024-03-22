using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.Majors
{
    public class EditModel : PageModel
    {

        private readonly StudentManagementSystem.Models.PRN221_StudentManagementSystemContext _context;

        public EditModel(StudentManagementSystem.Models.PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Major Major { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Majors == null)
            {
                return NotFound();
            }

            var major = await _context.Majors.FirstOrDefaultAsync(m => m.MajorId == id);
            if (major == null)
            {
                return NotFound();
            }
            Major = major;

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Major).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LectureExists(Major.MajorId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LectureExists(string id)
        {
            return (_context.Majors?.Any(e => e.MajorId == id)).GetValueOrDefault();
        }
    }
}
