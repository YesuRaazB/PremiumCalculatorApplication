using PremiumCalculator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculator.Application.Services
{
    public interface IPremiumCalculatorService
    {
        Task<decimal> CalculateMonthlyPremiumAsync(PremiumRequest request);
        Task<IReadOnlyList<OccupationRating>> GetOccupationsAsync();
    }
}
