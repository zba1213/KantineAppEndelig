using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using KantineApp.Models;
using KantineApp.Services;

namespace KantineApp.Pages
{
    // PageModel for managing weekly offers in the Razor Page
    public class WeeklyOfferModel : PageModel
    {
        private readonly WeeklyOfferService _offerService;

        // List of past weekly offers (where ValidTo < today)
        public List<WeeklyOffer> PastOffers { get; set; } = new();

        // The current weekly offer (if any, where ValidFrom <= today && ValidTo >= today)
        public WeeklyOffer? CurrentOffer { get; set; }

        // Bound property for creating a new weekly offer via the form
        [BindProperty] public WeeklyOffer NewOffer { get; set; } = new();

        // Constructor: injects the WeeklyOfferService
        public WeeklyOfferModel(WeeklyOfferService offerService) => _offerService = offerService;

        // Handles GET requests: loads all offers, determines the current and past offers
        public void OnGet()
        {
            var all = _offerService.GetAll();
            var today = DateTime.Today;
            // Find the current offer (valid today)
            CurrentOffer = all.FirstOrDefault(o => o.ValidFrom <= today && o.ValidTo >= today);
            // Find all past offers (already expired), ordered by most recent
            PastOffers = all.Where(o => o.ValidTo < today).OrderByDescending(o => o.ValidTo).ToList();
        }

        // Handles POST requests: adds a new offer and optionally sends an email
        public IActionResult OnPost(string action)
        {
            // If the model state is invalid, reload offers and return to the page
            if (!ModelState.IsValid)
            {
                OnGet();
                return Page();
            }
            // Add the new offer
            _offerService.AddOffer(NewOffer);
            // If the action is "SendEmail", send the weekly offer email to all employees
            if (action == "SendEmail")
                _offerService.SendWeeklyOfferEmail(NewOffer.Title, NewOffer.Description);
            return RedirectToPage();
        }

        // Handles POST requests for deleting an offer by ID
        public IActionResult OnPostDelete(int id)
        {
            _offerService.DeleteOffer(id);
            return RedirectToPage();
        }
    }
}