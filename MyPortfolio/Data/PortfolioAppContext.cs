using Microsoft.EntityFrameworkCore;
namespace MyPortfolio.Data
{
    public class PortfolioAppContext : DbContext
    {
        public PortfolioAppContext (DbContextOptions<PortfolioAppContext> options)
            : base(options)
        {
        }

        public DbSet<MyPortfolio.Models.Experience> Experience { get; set; }
        public DbSet<MyPortfolio.Models.Skill> Skill { get; set; }
        public DbSet<MyPortfolio.Models.Education> Education { get; set; }
        public DbSet<MyPortfolio.Models.Profile> Profile { get; set; }

                
    }
}
