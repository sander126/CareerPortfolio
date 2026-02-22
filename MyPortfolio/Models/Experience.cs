using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortfolio.Models
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public required string Company { get; set; }

        [StringLength(250)]
        public string? Address { get; set; }

        [StringLength(100)]
        public string? Position { get; set; }

        [DataType(DataType.Date)]
        public DateOnly StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateOnly? EndDate { get; set; }

        public bool CurrentlyWorking { get; set; }

        [DataType(DataType.MultilineText)]
        [Column(TypeName = "nvarchar(max)")]
        public string? KeyResponsibilities { get; set; }

        [StringLength(50)]
        public string? ExperienceType { get; set; }

        public String? CompanyLogoUrl { get; set; }
        public String? CompanyWebsite { get; set; }
    }
}
