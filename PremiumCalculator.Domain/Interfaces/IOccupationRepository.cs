using PremiumCalculator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculator.Domain.Interfaces
{
    public interface IOccupationRepository
    {
        Task<IReadOnlyList<OccupationRating>> GetAllAsync();
    }
}
