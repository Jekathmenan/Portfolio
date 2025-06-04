using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PortfolioApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
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
    }
}
