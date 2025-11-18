using PremiumCalculator.Domain.Entities;
using PremiumCalculator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculator.Infrastructure.Repositories
{
    public class OccupationRepository : IOccupationRepository
    {
        private readonly List<OccupationRating> _ratings = new()
    {
        new() { Id = 1, OccupationName = "Cleaner",        RatingName = "Light Manual",   Factor = 1.50m },
        new() { Id = 2, OccupationName = "Doctor",         RatingName = "Professional",   Factor = 1.0m },
        new() { Id = 3, OccupationName = "Author",         RatingName = "White Collar",   Factor = 1.25m },
        new() { Id = 4, OccupationName = "Farmer",         RatingName = "Heavy Manual",   Factor = 1.75m },
        new() { Id = 5, OccupationName = "Mechanic",       RatingName = "Heavy Manual",   Factor = 1.75m },
        new() { Id = 6, OccupationName = "Florist",        RatingName = "Light Manual",   Factor = 1.50m },
    };

        public Task<IReadOnlyList<OccupationRating>> GetAllAsync()
            => Task.FromResult<IReadOnlyList<OccupationRating>>(_ratings);
    }
}
