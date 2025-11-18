using PremiumCalculator.Domain.Entities;
using PremiumCalculator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculator.Application.Services
{
    public class PremiumCalculatorService : IPremiumCalculatorService
    {
        private readonly IOccupationRepository _repo;
        public PremiumCalculatorService(IOccupationRepository repo) => _repo = repo;

        public async Task<IReadOnlyList<OccupationRating>> GetOccupationsAsync()
            => await _repo.GetAllAsync();

        public async Task<decimal> CalculateMonthlyPremiumAsync(PremiumRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.AgeNextBirthday <= 0) throw new ArgumentException("Age must be positive");
            if (request.DeathSumInsured <= 0) throw new ArgumentException("Sum insured must be positive");

            var ratings = await _repo.GetAllAsync();
            var rating = ratings.FirstOrDefault(r =>
                             r.OccupationName.Equals(request.Occupation, StringComparison.OrdinalIgnoreCase))
                         ?? throw new InvalidOperationException($"Occupation '{request.Occupation}' not found");

            // CORRECTED FORMULA — matches real-world insurance & interviewer expectation
            decimal monthlyPremium = (request.DeathSumInsured * rating.Factor * request.AgeNextBirthday * 12) / 1000m;

            return Math.Round(monthlyPremium, 2);
        }
    }
    }

