using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using KantineApp.Models;
using KantineApp.Services;

namespace KantineApp.Pages
{
    public class WeeklyOfferModel : PageModel
    {
        private readonly WeeklyOfferService _offerService;
        public List<WeeklyOffer> PastOffers { get; set; } = new();
        public WeeklyOffer? CurrentOffer { get; set; }
        [BindProperty] public WeeklyOffer NewOffer { get; set; } = new();

        public WeeklyOfferModel(WeeklyOfferService offerService) => _offerService = offerService;

        public void OnGet() { var all = _offerService.GetAll(); var today = DateTime.Today; CurrentOffer = all.FirstOrDefault(o => o.ValidFrom <= today && o.ValidTo >= today); PastOffers = all.Where(o => o.ValidTo < today).OrderByDescending(o => o.ValidTo).ToList(); }

        public IActionResult OnPost(string action) { if (!ModelState.IsValid) { OnGet(); return Page(); } _offerService.AddOffer(NewOffer); if (action == "SendEmail") _offerService.SendWeeklyOfferEmail(NewOffer.Title, NewOffer.Description); return RedirectToPage(); }

        public IActionResult OnPostDelete(int id) { _offerService.DeleteOffer(id); return RedirectToPage(); }
    }
}