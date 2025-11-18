using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculator.Domain.Entities
{
    public class OccupationRating
    {
        public int Id { get; set; }
        public string OccupationName { get; set; } = string.Empty;
        public string RatingName { get; set; } = string.Empty; // e.g., Professional, White Collar
        public decimal Factor { get; set; }
    }
}