using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Data;
using PortfolioApp.Models;

namespace PortfolioApp.Pages.Admin
{
    public class CareerModel : PageModel
    {
        private readonly PortfolioContext _context;

        public CareerModel(PortfolioContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Career NewCareer { get; set; } = new Career();

        public List<Career> Careers { get; set; }


        public async Task OnGetAsync()
        {
            Careers = await _context.Careers.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Careers = await _context.Careers.ToListAsync();
                return Page();
            }

            _context.Careers.Add(NewCareer);
            await _context.SaveChangesAsync();

            return RedirectToPage(); // Refresh
        }
    }
}
