using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Data;
using PortfolioApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioApp.Pages
{
    public class ProjectsModel : PageModel
    {
        private readonly PortfolioDbContext _context;

        public ProjectsModel(PortfolioDbContext context)
        {
            _context = context;
        }

        public List<Project> Projects { get; set; }

        public async Task OnGetAsync()
        {
            Projects = await _context.Projects.ToListAsync();
        }
    }
}
