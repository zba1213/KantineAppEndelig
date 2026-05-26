using Microsoft.AspNetCore.Mvc.RazorPages;
using KantineApp.Models;
using KantineApp.Services;

namespace KantineApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DailySpecialService _dailySpecialService;
        private readonly WeeklyOfferService _weeklyOfferService;
        public DailySpecial? TodaysSpecial { get; set; }
        public WeeklyOffer? WeeklyOffer { get; set; }

        public IndexModel(DailySpecialService dailySpecialService, WeeklyOfferService weeklyOfferService)
        {
            _dailySpecialService = dailySpecialService;
            _weeklyOfferService = weeklyOfferService;
        }

        public void OnGet()
        {
            TodaysSpecial = _dailySpecialService.GetTodaysSpecial();
            WeeklyOffer = _weeklyOfferService.GetCurrentOffer();
        }
    }
}