using KantineApp.Models;
using KantineApp.Repository;

namespace KantineApp.Services
{
    // Service for handling business logic related to WeeklyOffers
    public class WeeklyOfferService
    {
        private readonly IWeeklyOfferRepository _offerRepo;
        private readonly IEmployeeRepository _employeeRepo;

        // Constructor: injects the required repositories
        public WeeklyOfferService(IWeeklyOfferRepository offerRepo, IEmployeeRepository employeeRepo)
        {
            _offerRepo = offerRepo;
            _employeeRepo = employeeRepo;
        }

        // Returns all weekly offers
        public List<WeeklyOffer> GetAll() => _offerRepo.GetAll();

        // Returns the current weekly offer (if any)
        public WeeklyOffer? GetCurrentOffer() => _offerRepo.GetCurrentOffer();

        // Adds a new weekly offer
        public void AddOffer(WeeklyOffer offer) => _offerRepo.Add(offer);

        // Updates an existing weekly offer
        public void UpdateOffer(WeeklyOffer offer) => _offerRepo.Update(offer);

        // Deletes a weekly offer by ID
        public void DeleteOffer(int id) => _offerRepo.Delete(id);

        // Simulates sending a weekly offer email to all employees
        public void SendWeeklyOfferEmail(string subject, string body)
        {
            var employees = _employeeRepo.GetAll();
            foreach (var emp in employees)
            {
                // In a real application, replace this with actual email sending logic
                Console.WriteLine($"EMAIL til {emp.Email}: {subject} - {body}");
            }
        }
    }
}