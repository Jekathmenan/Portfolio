namespace PortfolioApp.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TechStack { get; set; }
        public string GithubUrl { get; set; }
        public string? DemoUrl { get; set; }
        public string? ImageUrl { get; set; } 
    }
}
