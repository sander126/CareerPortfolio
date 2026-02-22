using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models;
using MyPortfolio.Services;
using MyPortfolio.ViewModels;
using System.Diagnostics;

namespace MyPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private  readonly IPortfolioService _portfolioService;

 
        public HomeController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task<IActionResult> Index()
        {
  
            var model = new HomeIndexViewModel
            {
                WorkExperiences = await _portfolioService.GetExperienceByType("Work"),
                FreelanceExperiences = await _portfolioService.GetExperienceByType("Freelance")
            };

            return View(model);
        }

        public IActionResult Careers()
        {
            return View();
        }

        public IActionResult AdminHome()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> GetExperience(int id)
        {
            var experience = await _portfolioService.GetExperienceByIdAsync(id);

            if (experience == null)
                return NotFound();

            return PartialView("_ExperienceModal", experience);
        }
    }
}
