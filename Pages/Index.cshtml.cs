using Microsoft.AspNetCore.Mvc.RazorPages;
using KantineApp.Models;
using KantineApp.Services;

namespace KantineApp.Pages
{
    // PageModel for the Index Razor Page (front page of the application)
    public class IndexModel : PageModel
    {
        private readonly DailySpecialService _dailySpecialService;
        private readonly WeeklyOfferService _weeklyOfferService;

        // Holds today's daily special, if any
        public DailySpecial? TodaysSpecial { get; set; }

        // Holds the current weekly offer, if any
        public WeeklyOffer? WeeklyOffer { get; set; }

        // Constructor: injects the required services
        public IndexModel(DailySpecialService dailySpecialService, WeeklyOfferService weeklyOfferService)
        {
            _dailySpecialService = dailySpecialService;
            _weeklyOfferService = weeklyOfferService;
        }

        // Handles GET requests: loads today's special and the current weekly offer
        public void OnGet()
        {
            TodaysSpecial = _dailySpecialService.GetTodaysSpecial();
            WeeklyOffer = _weeklyOfferService.GetCurrentOffer();
        }
    }
}