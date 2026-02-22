using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        public required string FullName { get; set; }

        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }

        [Phone]
        public string? Mobile { get; set; }

        [Phone]
        public string? HomePhone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
    }
}
