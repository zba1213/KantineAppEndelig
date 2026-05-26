using KantineApp.Models;
using KantineApp.Repository;

namespace KantineApp.Services
{
    public class WeeklyOfferService
    {
        private readonly IWeeklyOfferRepository _offerRepo;
        private readonly IEmployeeRepository _employeeRepo;

        public WeeklyOfferService(IWeeklyOfferRepository offerRepo, IEmployeeRepository employeeRepo)
        {
            _offerRepo = offerRepo;
            _employeeRepo = employeeRepo;
        }

        public List<WeeklyOffer> GetAll() => _offerRepo.GetAll();
        public WeeklyOffer? GetCurrentOffer() => _offerRepo.GetCurrentOffer();
        public void AddOffer(WeeklyOffer offer) => _offerRepo.Add(offer);
        public void UpdateOffer(WeeklyOffer offer) => _offerRepo.Update(offer);
        public void DeleteOffer(int id) => _offerRepo.Delete(id);

        public void SendWeeklyOfferEmail(string subject, string body)
        {
            var employees = _employeeRepo.GetAll();
            foreach (var emp in employees)
            {
                Console.WriteLine($"EMAIL til {emp.Email}: {subject} - {body}");
            }
        }
    }
}