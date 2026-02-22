using MyPortfolio.Models;

namespace MyPortfolio.Services
{
    public interface IPortfolioService
    {
        //profile related methods
        Task<Profile?> GetProfileAsync();
        Task<bool> UpdateProfileAsync(Profile updatedProfile);

        //Experience related methods
        Task<List<Experience>> GetAllExperiencesAsync();
        Task CreateExperienceAsync(Experience experience);
        Task<bool> DeleteExperienceAsync(int id);
        Task<bool> UpdateExperienceAsync(Experience updatedExperience);
        Task<Experience?> GetExperienceByIdAsync(int id);
        Task<List<Experience>> GetExperienceByType(string type);


        //Education related methods
        Task<List<Education>> GetAllEducationAsync();
        Task CreateEducationAsync(Education education);
        Task<bool> DeleteEducationAsync(int id);
        Task<bool> UpdateEducationAsync(Education updatedEducation);
        Task<Education?> GetEducationByIdAsync(int id);

        //Skill related methods
        Task<List<Skill>> GetAllSkillsAsync();
        Task CreateSkillAsync(Skill skill);
        Task<bool> DeleteSkillAsync(int id);
        Task<bool> UpdateSkillAsync(Skill updatedSkill);
        Task<Skill?> GetSkillByIdAsync(int id);


    }
}