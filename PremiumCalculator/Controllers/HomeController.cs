using Microsoft.AspNetCore.Mvc;
using PremiumCalculator.Domain.Entities;
using PremiumCalculator.Application.Services;

namespace PremiumCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPremiumCalculatorService _service;

        public HomeController(IPremiumCalculatorService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Occupations = (await _service.GetOccupationsAsync())
                .Select(o => o.OccupationName).ToList();
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Calculate(PremiumRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new { success = false, message = "Please fill all fields correctly." });

                var premium = await _service.CalculateMonthlyPremiumAsync(request);
                return Json(new { success = true, premium });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}