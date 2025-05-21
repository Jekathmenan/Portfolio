namespace PortfolioApp.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Proficiency { get; set; } // e.g., Beginner, Intermediate, Expert
        public string ImageUrl { get; set; }
    }
}