using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Data;
using PortfolioApp.Models;

namespace PortfolioApp.Pages.Admin
{
    public class EducationModel : PageModel
    {
        private readonly PortfolioContext _context;

        public EducationModel(PortfolioContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Education NewEducation { get; set; } = new Education();

        public List<Education> Educations { get; set; }


        public async Task OnGetAsync()
        {
            Educations = await _context.Educations.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Educations = await _context.Educations.ToListAsync();
                return Page();
            }

            _context.Educations.Add(NewEducation);
            await _context.SaveChangesAsync();

            return RedirectToPage(); // Refresh
        }
    }
}
