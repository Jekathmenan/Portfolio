using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Data;
using PortfolioApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioApp.Pages.Admin
{
    [Authorize]
    public class ProjectsModel : PageModel
    {
        private readonly PortfolioContext _context;

        public ProjectsModel(PortfolioContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Project NewProject { get; set; } = new Project();

        public List<Project> Projects { get; set; }

        
        public async Task OnGetAsync()
        {
            Projects = await _context.Projects.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            /*if (!ModelState.IsValid)
            {
                Projects = await _context.Projects.ToListAsync();
                return Page();
            }*/

            _context.Projects.Add(NewProject);
            await _context.SaveChangesAsync();

            return RedirectToPage(); // Refresh
        }
    }
}
