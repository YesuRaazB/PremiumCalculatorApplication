using PremiumCalculator.Application.Services;
using PremiumCalculator.Domain.Entities;
using PremiumCalculator.Domain.Interfaces;
using PremiumCalculator.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculator.Tests
{
    public class PremiumServiceTests
    {
        private readonly IOccupationRepository _repo;
        private readonly PremiumCalculatorService _service;

        public PremiumServiceTests()
        {
            _repo = new OccupationRepository(); // in-memory
            _service = new PremiumCalculatorService(_repo);
        }

        [Fact]
        public async Task Calculate_Doctor_30Years_1000000_ShouldReturn_2500()
        {
            var request = new PremiumRequest
            {
                Name = "Test",
                AgeNextBirthday = 30,
                DateOfBirth = "01/1996",
                Occupation = "Doctor",
                DeathSumInsured = 1_000_000
            };

            var result = await _service.CalculateMonthlyPremiumAsync(request);
            Assert.Equal(2500m, result);
        }

        // Add more edge case tests...
    }
}
