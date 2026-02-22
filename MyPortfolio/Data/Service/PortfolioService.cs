using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using MyPortfolio.Models;

namespace MyPortfolio.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly PortfolioAppContext _context;

        // Constructor injection of the database context
        public PortfolioService(PortfolioAppContext context)
        {
            _context = context;
        }

        //profile related methods
        public async Task<Profile?> GetProfileAsync()
        {
            return await _context.Profile.FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateProfileAsync(Profile updatedProfile)
        {
            var profile = await _context.Profile.FirstOrDefaultAsync();
            if (profile == null) return false;

            profile.FullName = updatedProfile.FullName;
            profile.AddressLine1 = updatedProfile.AddressLine1;
            profile.AddressLine2 = updatedProfile.AddressLine2;
            profile.AddressLine3 = updatedProfile.AddressLine3;
            profile.HomePhone = updatedProfile.HomePhone;
            profile.Mobile = updatedProfile.Mobile;
            profile.Email = updatedProfile.Email;

            await _context.SaveChangesAsync();
            return true;
        }

        //Experience related methods
        public async Task<List<Experience>> GetAllExperiencesAsync()
        {
            return await _context.Experience.ToListAsync();
        }

        public async Task CreateExperienceAsync(Experience experience)
        {
            _context.Add(experience);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteExperienceAsync(int id)
        {
            var experience = await _context.Experience.FindAsync(id);
            if (experience == null) return false;

            _context.Experience.Remove(experience);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Experience?> GetExperienceByIdAsync(int id)
        {
            return await _context.Experience.FindAsync(id);
        }

        public async Task<List<Experience>> GetExperienceByType(string type)
        {
            return await _context.Experience.Where(e => e.ExperienceType == type).ToListAsync();
        }

        public async Task<bool> UpdateExperienceAsync(Experience updatedExperience)
        {
            try
            {
                _context.Experience.Update(updatedExperience);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // Returns false if database update fails (e.g., record was deleted)
                return false;
            }
        }

        public async Task<List<Education>> GetAllEducationAsync()
        {
            return await _context.Education.ToListAsync();
        }

        public async Task CreateEducationAsync(Education education)
        {
            _context.Add(education);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteEducationAsync(int id)
        {
            var education = await _context.Education.FindAsync(id);
            if (education == null) return false;
            _context.Education.Remove(education);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Education?> GetEducationByIdAsync(int id)
        {
            return await _context.Education.FindAsync(id);
        }
        public async Task<bool> UpdateEducationAsync(Education updatedEducation)
        {
            try
            {
                _context.Education.Update(updatedEducation);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // Returns false if database update fails (e.g., record was deleted)
                return false;
            }
        }

        //Skill related methods
        public async Task<List<Skill>> GetAllSkillsAsync()
        {
            return await _context.Skill.ToListAsync();
        }
        public async Task CreateSkillAsync(Skill skill)
        {
            _context.Add(skill);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteSkillAsync(int id)
        {
            var skill = await _context.Skill.FindAsync(id);
            if (skill == null) return false;
            _context.Skill.Remove(skill);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Skill?> GetSkillByIdAsync(int id)
        {
            return await _context.Skill.FindAsync(id);
        }
        public async Task<bool> UpdateSkillAsync(Skill updatedSkill)
        {
            try
            {
                _context.Skill.Update(updatedSkill);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // Returns false if database update fails (e.g., record was deleted)
                return false;
            }
        }
    }
}