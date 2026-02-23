using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Models;
using MyPortfolio.Services;
using Microsoft.AspNetCore.Authorization;

[Authorize]
public class AdminController : Controller
{
    private readonly IPortfolioService _portfolioService;
    // Constructor injection of the portfolio service

    
    public AdminController(IPortfolioService portfolioService)
    {
        _portfolioService = portfolioService;
    }

    //Profile related methods
    public async Task<IActionResult> Index()
    {
        var profile = await _portfolioService.GetProfileAsync();
        return View(profile);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Profile updatedProfile)
    {
        var success = await _portfolioService.UpdateProfileAsync(updatedProfile);

        if (!success) return NotFound();

        TempData["SuccessMessage"] = "Profile updated successfully!";
        return RedirectToAction("Index");
    }

    //Experience related methods
    [HttpGet]
    public async Task<IActionResult> Experience()
    {
        var experiences = await _portfolioService.GetAllExperiencesAsync();
        return View(experiences);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateExperience(Experience experience)
    {
        if (ModelState.IsValid)
        {
            await _portfolioService.CreateExperienceAsync(experience);
            return RedirectToAction(nameof(Experience));
        }
        return View(experience);
    }

    [HttpGet]

    public IActionResult CreateExperience()
    {
        // We pass a new object so the form is empty
        return View(new Experience { Company = string.Empty, StartDate = DateOnly.FromDateTime(DateTime.Now) });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteExperience(int id)
    {
        var success = await _portfolioService.DeleteExperienceAsync(id);

        if (success)
        {
            TempData["Success"] = "Experience deleted successfully!";
        }

        return RedirectToAction(nameof(Experience));
    }


    [HttpGet]
    public async Task<IActionResult> EditExperience(int id)
    {
        var experience = await _portfolioService.GetExperienceByIdAsync(id);
        if (experience == null) return NotFound();
        return View(experience);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditExperience(Experience experience)
    {
        if (ModelState.IsValid)
        {
            await _portfolioService.UpdateExperienceAsync(experience);
            return RedirectToAction(nameof(Experience));
        }
        return View(experience);
    }

    // Education related methods
    [HttpGet]
    public async Task<IActionResult> Education()
    {
        var educationList = await _portfolioService.GetAllEducationAsync();
        return View(educationList);
    }
    public IActionResult CreateEducation()
    {
        // We pass a new object so the form is empty
        return View(new Education());
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateEducation(Education education)
    {
        if (ModelState.IsValid)
        {
            await _portfolioService.CreateEducationAsync(education);
            return RedirectToAction(nameof(Education));
        }
        return View(education);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteEducation(int id)
    {
        var success = await _portfolioService.DeleteEducationAsync(id);
        if (success)
        {
            TempData["Success"] = "Education entry deleted successfully!";
        }
        return RedirectToAction(nameof(Education));

    }
    [HttpGet]
    public async Task<IActionResult> EditEducation(int id)
    {
        var education = await _portfolioService.GetEducationByIdAsync(id);
        if (education == null) return NotFound();
        return View(education);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditEducation(Education education)
    {
        if (ModelState.IsValid)
        {
            await _portfolioService.UpdateEducationAsync(education);
            return RedirectToAction(nameof(Education));
        }
        return View(education);

    }

    // Skill related methods
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateSkill(Skill skill)
    {
        if (ModelState.IsValid)
        {
            await _portfolioService.CreateSkillAsync(skill);
            return RedirectToAction(nameof(Skill));
        }
        return View(skill);
    }
     [HttpGet]
     public IActionResult CreateSkill() 
     {
        // We pass a new object so the form is empty
        return View(new Skill { Expertise = String.Empty});
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteSkill(int id)
    {
        var success = await _portfolioService.DeleteSkillAsync(id);
        if (success)
        {
            TempData["Success"] = "Skill entry deleted successfully!";
        }
        return RedirectToAction(nameof(Skill));
    }

     [HttpGet]
    public async Task<IActionResult> EditSkill(int id)
     {
        var skill = await _portfolioService.GetSkillByIdAsync(id);
        if (skill == null) return NotFound();
        return View(skill);
     }
     [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditSkill(Skill skill)
     {
        if (ModelState.IsValid)
        {
            await _portfolioService.UpdateSkillAsync(skill);
            return RedirectToAction(nameof(Skill));
        }
        return View(skill);
     }
     [HttpGet]
     public async Task<IActionResult> Skill()
     {
        var skills = await _portfolioService.GetAllSkillsAsync();
        return View(skills);
    }


}
