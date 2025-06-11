using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Data;
using PortfolioApp.Models;

namespace PortfolioApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly PortfolioContext _context;
    public List<Career> careers { get; set; }
    public List<Education> educations { get; set; }
    public IndexModel(ILogger<IndexModel> logger, PortfolioContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task OnGetAsync()
    {
        var datetime = DateTime.Now;
        string greeting;


        if (datetime.Hour > 2 && datetime.Hour < 11)
        {
            greeting = "Guten Morgen! ";
        }
        else if (datetime.Hour < 17)
        {
            greeting = "Guten Tag! ";
        }
        else if (datetime.Hour < 17 || datetime.Hour < 2)
        {
            greeting = "Guten Abend! ";
        }
        else
        {
            greeting = "";
        }
        greeting += "Willkommen zu meiner Portfolio Seite!";

        ViewData["Greeting"] = greeting;
        this.careers = await _context.Careers.OrderByDescending(i => i.Period).ToListAsync();
        this.educations = await _context.Educations.OrderByDescending(i => i.Period).ToListAsync();
        
    }
}
