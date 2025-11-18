using System.ComponentModel.DataAnnotations;

namespace PremiumCalculator.Domain.Entities
{
    public class PremiumRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required, Range(1, int.MaxValue)]
        public int AgeNextBirthday { get; set; }

        [Required]
        public string DateOfBirth { get; set; } = string.Empty;

        [Required]
        public string Occupation { get; set; } = string.Empty;

        [Required, Range(0.01, double.MaxValue)]
        public decimal DeathSumInsured { get; set; }
    }
}