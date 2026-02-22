using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        public required string Expertise { get; set; }

        [Range(0, 10, ErrorMessage = "Rating must be between 1 and 10.")]
        public int? Rating { get; set; }
        public string? SkillType { get; set; }
    }
}
