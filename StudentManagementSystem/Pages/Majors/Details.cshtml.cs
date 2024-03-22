using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.Majors
{
    public class DetailsModel : PageModel
    {
        
            private readonly StudentManagementSystem.Models.PRN221_StudentManagementSystemContext _context;

            public DetailsModel(StudentManagementSystem.Models.PRN221_StudentManagementSystemContext context)
            {
                _context = context;
            }

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
                else
                {
                    Major = major;
                }
                return Page();
            }
        }
    }
