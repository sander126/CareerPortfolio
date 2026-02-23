using MyPortfolio.Models;

namespace MyPortfolio.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<Experience> WorkExperiences { get; set; } = new();
        public List<Experience> FreelanceExperiences { get; set; } = new();
        public List<Education> Educations { get; set; } = new();
    }
}
